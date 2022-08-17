using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json.Serialization;

namespace DotNetBungieAPI.DefinitionProvider.Sqlite;

internal static class SqlValueConverter
{
    private static readonly Type Boolean = typeof(bool);
    private static readonly Type String = typeof(string);
    private static readonly Type Int32 = typeof(int);
    private static readonly Type UInt32 = typeof(uint);

    internal static string ConvertConstantExpression(ConstantExpression expression)
    {
        if (expression.Value is null)
            return "NULL";

        if (expression.Type == Boolean)
        {
            return expression.Value!.ToString()!.ToLowerInvariant();
        }

        if (expression.Type == String)
        {
            return $"'{expression.Value}'";
        }

        if (expression.Type == Int32)
        {
            return expression.Value!.ToString()!;
        }
        
        if (expression.Type == UInt32)
        {
            return expression.Value!.ToString()!;
        }

        return string.Empty;
    }

    internal static string ConvertBinaryExpression(BinaryExpression binaryExpression)
    {
        var left = binaryExpression.Left;
        var right = binaryExpression.Right;

        var leftExpr = left switch
        {
            BinaryExpression leftBinExpr => ConvertBinaryExpression(leftBinExpr),
            ConstantExpression leftConstExpr => ConvertConstantExpression(leftConstExpr),
            MemberExpression leftMemberExpr => ConvertMemberExpression(leftMemberExpr),
            MethodCallExpression leftMethodCallExpr => ConvertMethodCallExpression(leftMethodCallExpr),
            _ => string.Empty
        };

        var rightExpr = right switch
        {
            BinaryExpression rightBinExpr => ConvertBinaryExpression(rightBinExpr),
            ConstantExpression rightConstExpr => ConvertConstantExpression(rightConstExpr),
            MemberExpression rightMemberExpr => ConvertMemberExpression(rightMemberExpr),
            MethodCallExpression rightMethodCallExpr => ConvertMethodCallExpression(rightMethodCallExpr),
            _ => string.Empty
        };

        if (rightExpr == "NULL")
        {
            var operation = ConvertOperation(binaryExpression);
            switch (operation)
            {
                case "=":
                    return $"({leftExpr} IS NULL)";
                case "!=":
                    return $"({leftExpr} IS NOT NULL)";
                default:
                    throw new Exception($"Can't use {operation} ({binaryExpression.NodeType}) with NULL");
            }
        }
        else
        {
            return $"({leftExpr} {ConvertOperation(binaryExpression)} {rightExpr})";
        }
    }

    internal static string ConvertMethodCallExpression(MethodCallExpression methodCallExpression)
    {
        if (methodCallExpression.Method == DbFunctions.LikeMethod)
        {
            var member = methodCallExpression.Arguments[0];
            var value = methodCallExpression.Arguments[1];

            return
                $"{ConvertMemberExpression(member as MemberExpression)} LIKE '%{((ConstantExpression)value).Value}%'";
        }

        if (IsListIndexerExpression(methodCallExpression, out var index))
        {
            var path = CreateMemberPath((MemberExpression)methodCallExpression.Object);
            return $"json_extract(json, '$.{path}[{index}]')";
        }

        throw new Exception("Unsupported method");
    }

    private static bool IsListIndexerExpression(Expression expr, out int index)
    {
        index = 0;

        if (expr is not MethodCallExpression { Object: MemberExpression memberExpression } methodCallExpression)
            return false;

        var memberInfo = ((PropertyInfo)memberExpression.Member).PropertyType;

        var isList = memberInfo.IsGenericType &&
                     (memberInfo
                         .GetTypeInfo()
                         .ImplementedInterfaces
                         .Any(x =>
                             x.GetTypeInfo().IsGenericType && x.GetGenericTypeDefinition() == typeof(IList<>)));

        if (!isList)
            return false;

        var arguments = methodCallExpression.Arguments[0];

        if (arguments is ConstantExpression constantExpression && constantExpression.Type == Int32)
        {
            index = (int)constantExpression.Value!;
            return true;
        }

        return false;
    }

    private static string CreateMemberPath(Expression memberExpression)
    {
        var propertyPath = string.Empty;

        var shouldContinue = true;
        
        Expression currentExpr = memberExpression;

        while (shouldContinue)
        {
            if (currentExpr is MemberExpression memberExpr)
            {
                var jsonName = memberExpr.Member.GetCustomAttribute<JsonPropertyNameAttribute>();
                if (propertyPath == string.Empty)
                {
                    propertyPath = $"{jsonName!.Name}";
                }
                else
                {
                    propertyPath = $"{jsonName!.Name}.{propertyPath}";
                }

                currentExpr = memberExpr.Expression;
            }
            else if (IsListIndexerExpression(currentExpr!, out var index))
            {
                var methodExpr = (MethodCallExpression)((MemberExpression)memberExpression).Expression;
                var methodMemberExpr = (MemberExpression)methodExpr.Object;
                
                var jsonName = methodMemberExpr.Member.GetCustomAttribute<JsonPropertyNameAttribute>();
                if (propertyPath == string.Empty)
                {
                    propertyPath = $"{jsonName!.Name}[{index}]";
                }
                else
                {
                    propertyPath = $"{jsonName!.Name}[{index}].{propertyPath}";
                }

                currentExpr = methodMemberExpr.Expression;
            }

            shouldContinue = IsListIndexerExpression(currentExpr, out _) || currentExpr is MemberExpression;
        }

        return propertyPath;
    }

    private static string ConvertMemberExpression(MemberExpression memberExpression)
    {
        if (memberExpression.Member.Name == "Count")
        {
            var propertyPath = CreateMemberPath(memberExpression.Expression);
            return $"json_array_length(json, '$.{propertyPath}')";
        }
        else
        {
            var propertyPath = CreateMemberPath(memberExpression);
            return $"json_extract(json, '$.{propertyPath}')";
        }
    }

    private static string ConvertOperation(BinaryExpression binaryExpression)
    {
        return binaryExpression.NodeType switch
        {
            ExpressionType.AndAlso => "AND",
            ExpressionType.OrElse => "OR",
            ExpressionType.Equal => "=",
            ExpressionType.NotEqual => "!=",
            ExpressionType.LessThan => "<",
            ExpressionType.LessThanOrEqual => "<=",
            ExpressionType.GreaterThan => ">",
            ExpressionType.GreaterThanOrEqual => ">=",
            _ => "ERROR"
        };
    }
}