using DotNetBungieAPI.OpenApi.CodeGeneration;
using DotNetBungieAPI.OpenApi.Metadata;

namespace DotNetBungieAPI.OpenApi.CSharp;

public class CSharpClassGenerator : ModelGeneratorBase
{
    private const string Indent = "    ";

    public override string FileExtension => "cs";

    public override async Task GenerateDataForObjectType(ObjectTypeData typeData)
    {
        if (typeData.Description is not null)
        {
            await WriteComment(false, typeData.Description);
        }

        await WriteLineAsync($"public class {typeData.TypeName} : IDeepEquatable<{typeData.TypeName}>");
        await WriteLineAsync('{');

        var totalValues = typeData.Properties.Count;
        var amountCheckValue = totalValues - 1;
        for (var i = 0; i < totalValues; i++)
        {
            var propertyTypeData = typeData.Properties[i];
            if (propertyTypeData.Description is not null)
            {
                await WriteComment(true, propertyTypeData.Description);
            }

            await WriteLineAsync($"{Indent}[JsonPropertyName(\"{propertyTypeData.OriginPropertyName}\")]");
            await WriteLineAsync(
                $"{Indent}public {propertyTypeData} {propertyTypeData.OriginPropertyName.GetCSharpPropertyName()} {{ get; set; }}");
            if (i != amountCheckValue)
            {
                await WriteLineAsync();
            }
        }

        await WriteLineAsync();

        await WriteDeepEqualsMethod(typeData);

        await WriteLineAsync();

        await WriteUpdateMethod(typeData);

        await WriteAsync('}');
    }

    public override async Task GenerateDataForEnumType(EnumTypeData typeData)
    {
        if (typeData.Description is not null)
        {
            await WriteComment(false, typeData.Description);
        }

        if (typeData.IsFlags)
        {
            await WriteLineAsync("[System.Flags]");
        }

        await WriteLineAsync($"public enum {typeData.TypeName} : {typeData.Format}");
        await WriteLineAsync('{');

        var totalValues = typeData.Values.Count;
        var amountCheckValue = totalValues - 1;
        for (var i = 0; i < totalValues; i++)
        {
            var enumValueData = typeData.Values[i];
            if (enumValueData.Description is not null)
            {
                await WriteComment(true, enumValueData.Description);
            }

            await WriteLineAsync(
                $"{Indent}{enumValueData.Name} = {enumValueData.Value}{(i != amountCheckValue ? "," : string.Empty)}");
            if (i != amountCheckValue)
            {
                await WriteLineAsync();
            }
        }

        await WriteLineAsync('}');
    }

    private async Task WriteComment(bool indent, string description)
    {
        await WriteLineAsync($"{(indent ? Indent : string.Empty)}/// <summary>");
        var entries = description.Split("\r\n");
        if (entries.Length == 1)
        {
            await WriteLineAsync($"{(indent ? Indent : string.Empty)}///     {description}");
        }
        else
        {
            for (var i = 0; i < entries.Length; i++)
            {
                var descLine = entries[i];
                if (i == entries.Length - 1)
                {
                    await WriteLineAsync($"{(indent ? Indent : string.Empty)}///     {descLine}");
                }
                else
                {
                    await WriteLineAsync($"{(indent ? Indent : string.Empty)}///     {descLine}");
                    await WriteLineAsync($"{(indent ? Indent : string.Empty)}/// <para />");
                }
            }
        }

        await WriteLineAsync($"{(indent ? Indent : string.Empty)}/// </summary>");
    }

    private async Task WriteDeepEqualsMethod(ObjectTypeData typeData)
    {
        await WriteLineAsync($"{Indent}public bool DeepEquals({typeData.TypeName}? other)");
        await WriteLineAsync($"{Indent}{{");

        await WriteLineAsync($"{Indent}{Indent}return other is not null &&");

        var totalValues = typeData.Properties.Count;
        var amountCheckValue = totalValues - 1;

        for (var i = 0; i < totalValues; i++)
        {
            var propertyTypeData = typeData.Properties[i];
            var propertyName = propertyTypeData.OriginPropertyName.GetCSharpPropertyName();
            if (propertyTypeData.IsValueType)
            {
                await WriteLineAsync(
                    $"{Indent}{Indent}{Indent}   {propertyName} == other.{propertyName}{(i != amountCheckValue ? " &&" : ";")}");
            }

            if (propertyTypeData.IsClassObject)
            {
                await WriteLineAsync(
                    $"{Indent}{Indent}{Indent}   ({propertyName} is not null ? {propertyName}.DeepEquals(other.{propertyName}) : other.{propertyName} is null){(i != amountCheckValue ? " &&" : ";")}");
            }

            if (propertyTypeData.IsCollection)
            {
                if (propertyTypeData.GenericProperties[0].IsValueType)
                {
                    await WriteLineAsync(
                        $"{Indent}{Indent}{Indent}   {propertyName}.DeepEqualsListNaive(other.{propertyName}){(i != amountCheckValue ? " &&" : ";")}");
                }
                else
                {
                    await WriteLineAsync(
                        $"{Indent}{Indent}{Indent}   {propertyName}.DeepEqualsList(other.{propertyName}){(i != amountCheckValue ? " &&" : ";")}");
                }
            }

            if (propertyTypeData.IsDictionary)
            {
                if (propertyTypeData.GenericProperties[1].IsClassObject)
                {
                    await WriteLineAsync(
                        $"{Indent}{Indent}{Indent}   {propertyName}.DeepEqualsDictionary(other.{propertyName}){(i != amountCheckValue ? " &&" : ";")}");
                }
                else
                {
                    await WriteLineAsync(
                        $"{Indent}{Indent}{Indent}   {propertyName}.DeepEqualsDictionaryNaive(other.{propertyName}){(i != amountCheckValue ? " &&" : ";")}");
                }
            }
        }

        await WriteLineAsync($"{Indent}}}");
    }

    private async Task WriteUpdateMethod(ObjectTypeData typeData)
    {
        await WriteLineAsync($"{Indent}public event PropertyChangedEventHandler? PropertyChanged;");
        await WriteLineAsync();
        await WriteLineAsync($"{Indent}[NotifyPropertyChangedInvocator]");
        await WriteLineAsync($"{Indent}protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)\n{Indent}{{\n{Indent}   PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));\n{Indent}}}");
        await WriteLineAsync();
        
        await WriteLineAsync($"{Indent}public void Update({typeData.TypeName}? other)");
        await WriteLineAsync($"{Indent}{{");

        await WriteLineAsync($"{Indent}    if (other is null) return;");
        
        var totalValues = typeData.Properties.Count;

        for (var i = 0; i < totalValues; i++)
        {
            var propertyTypeData = typeData.Properties[i];
            var propertyName = propertyTypeData.OriginPropertyName.GetCSharpPropertyName();
            if (propertyTypeData.IsClassObject)
            {
                await WriteLineAsync($"{Indent}    if (!{propertyName}.DeepEquals(other.{propertyName}))");
                await WriteLineAsync($"{Indent}    {{");
                await WriteLineAsync($"{Indent}        {propertyName}.Update(other.{propertyName});");
                await WriteLineAsync($"{Indent}        OnPropertyChanged(nameof({propertyName}));");
                await WriteLineAsync($"{Indent}    }}");
            }
            else if (propertyTypeData.IsCollection)
            {
                if (propertyTypeData.GenericProperties[0].IsValueType)
                {
                    await WriteLineAsync($"{Indent}    if (!{propertyName}.DeepEqualsListNaive(other.{propertyName}))");
                    await WriteLineAsync($"{Indent}    {{");
                    await WriteLineAsync($"{Indent}        {propertyName} = other.{propertyName};");
                    await WriteLineAsync($"{Indent}        OnPropertyChanged(nameof({propertyName}));");
                    await WriteLineAsync($"{Indent}    }}");
                }
                else
                {
                    await WriteLineAsync($"{Indent}    if (!{propertyName}.DeepEqualsList(other.{propertyName}))");
                    await WriteLineAsync($"{Indent}    {{");
                    await WriteLineAsync($"{Indent}        {propertyName} = other.{propertyName};");
                    await WriteLineAsync($"{Indent}        OnPropertyChanged(nameof({propertyName}));");
                    await WriteLineAsync($"{Indent}    }}");
                }
            }
            else if (propertyTypeData.IsDictionary)
            {
                if (propertyTypeData.GenericProperties[1].IsValueType)
                {
                    await WriteLineAsync($"{Indent}    if (!{propertyName}.DeepEqualsDictionaryNaive(other.{propertyName}))");
                    await WriteLineAsync($"{Indent}    {{");
                    await WriteLineAsync($"{Indent}        {propertyName} = other.{propertyName};");
                    await WriteLineAsync($"{Indent}        OnPropertyChanged(nameof({propertyName}));");
                    await WriteLineAsync($"{Indent}    }}");
                }
                else
                {
                    await WriteLineAsync($"{Indent}    if (!{propertyName}.DeepEqualsDictionary(other.{propertyName}))");
                    await WriteLineAsync($"{Indent}    {{");
                    await WriteLineAsync($"{Indent}        {propertyName} = other.{propertyName};");
                    await WriteLineAsync($"{Indent}        OnPropertyChanged(nameof({propertyName}));");
                    await WriteLineAsync($"{Indent}    }}");
                }
            }
            else
            {
                await WriteLineAsync($"{Indent}    if ({propertyName} != other.{propertyName})");
                await WriteLineAsync($"{Indent}    {{");
                await WriteLineAsync($"{Indent}        {propertyName} = other.{propertyName};");
                await WriteLineAsync($"{Indent}        OnPropertyChanged(nameof({propertyName}));");
                await WriteLineAsync($"{Indent}    }}");
            }

            
        }

        await WriteLineAsync($"{Indent}}}");
    }
}