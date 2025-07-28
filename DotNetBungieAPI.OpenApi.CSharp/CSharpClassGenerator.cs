using System.Text;
using DotNetBungieAPI.OpenApi.CodeGeneration;
using DotNetBungieAPI.OpenApi.Extensions;
using DotNetBungieAPI.OpenApi.Models.ComponentSchemas;

namespace DotNetBungieAPI.OpenApi.CSharp;

public class CSharpClassGenerator : ModelGeneratorBase
{
    private const string Indent = "    ";
    private const string NameSpace = "namespace DotNetBungieAPI.Generated.Models;";
    private const string NamespaceBase = "namespace DotNetBungieAPI.Generated.Models";

    public override string FileExtension => "cs";

    public override async Task GenerateFromSchema(string typeName, IOpenApiComponentSchema schema)
    {
        if (schema.AsEnumType(out var enumType))
        {
            await GenerateFromEnumSchema(typeName, enumType);
            return;
        }

        if (schema.AsObjectType(out var objectType))
        {
            await GenerateFromObjectSchema(typeName, objectType);
            return;
        }

        if (schema is OpenApiEmptyObjectComponentSchema)
        {
            await GenerateEmptyClass(typeName);
            return;
        }
    }

    public override bool CanHandle(IOpenApiComponentSchema schema)
    {
        return schema
            is OpenApiObjectComponentSchema
                or OpenApiEnumComponentSchema
                or OpenApiEmptyObjectComponentSchema;
    }

    private async Task GenerateFromEnumSchema(string typeName, OpenApiEnumComponentSchema schema)
    {
        if (typeName.Contains('.'))
        {
            var pathData = typeName.Split('.')[0..^1];
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(NamespaceBase);
            foreach (var pathDataEntry in pathData)
            {
                stringBuilder.Append($".{pathDataEntry}");
            }

            stringBuilder.Append(';');
            await WriteLineAsync(stringBuilder.ToString());
        }
        else
        {
            await WriteLineAsync(NameSpace);
        }

        await WriteLineAsync();

        if (schema.Description is not null)
        {
            await WriteComment(false, schema.Description);
        }

        if (schema.EnumIsBitmask)
        {
            await WriteLineAsync("[System.Flags]");
        }

        await WriteLineAsync(
            $"public enum {typeName.Split('.').Last()} : {Resources.TypeMappings[schema.Format ?? schema.Type]}"
        );

        await WriteLineAsync('{');

        var totalValues = schema.Enum.Length;
        var amountCheckValue = totalValues - 1;
        for (var i = 0; i < totalValues; i++)
        {
            var enumValueData = schema.EnumValues[i];
            if (enumValueData.Description is not null)
            {
                await WriteComment(true, enumValueData.Description);
            }

            await WriteLineAsync(
                $"{Indent}{enumValueData.Identifier} = {enumValueData.NumericValue}{(i != amountCheckValue ? "," : string.Empty)}"
            );
            if (i != amountCheckValue)
            {
                await WriteLineAsync();
            }
        }

        await WriteLineAsync('}');
    }

    private async Task GenerateFromObjectSchema(
        string typeName,
        OpenApiObjectComponentSchema schema
    )
    {
        if (typeName.Contains('.'))
        {
            var pathData = typeName.Split('.')[0..^1];
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(NamespaceBase);
            foreach (var pathDataEntry in pathData)
            {
                stringBuilder.Append($".{pathDataEntry}");
            }

            stringBuilder.Append(';');
            await WriteLineAsync(stringBuilder.ToString());
        }
        else
        {
            await WriteLineAsync(NameSpace);
        }

        await WriteLineAsync();

        if (schema.Description is not null)
        {
            await WriteComment(false, schema.Description);
        }

        if (schema.MobileManifestName is not null && schema.Properties.ContainsKey("hash"))
        {
            await WriteLineAsync($"public class {typeName.Split('.').Last()} : IDestinyDefinition");
        }
        else
        {
            await WriteLineAsync($"public class {typeName.Split('.').Last()}");
        }
        
        await WriteLineAsync('{');

        var totalValues = schema.Properties.Count;
        var amountCheckValue = totalValues - 1;

        var i = 0;
        foreach (var (propertyName, propertySchema) in schema.Properties)
        {
            if (propertySchema is IHasDescription { Description: not null } description)
            {
                await WriteComment(true, description.Description);
            }

            if (propertySchema is IMappedDefinition { MappedDefinition: not null } mappedDefinition)
            {
                await WriteLineAsync(
                    $"{Indent}[Destiny2Definition<{mappedDefinition.MappedDefinition.GetReferencedPath()}>(\"{mappedDefinition.MappedDefinition.GetReferencedPath()}\")]"
                );
            }

            await WriteLineAsync($"{Indent}[JsonPropertyName(\"{propertyName}\")]");

            string propertyType;

            if (
                propertySchema.AsEnumType(out var fullEnumShema)
                && TryFindMatchingSchema(fullEnumShema, out var enumPropertySchema)
            )
            {
                propertyType = enumPropertySchema;
            }
            else
            {
                propertyType = propertySchema.GetCSharpType();
            }

            var nullableSymbol = propertySchema switch
            {
                ICanBeNullable { Nullable: true } or not ICanBeNullable => "?",
                _ => string.Empty
            };

            await WriteLineAsync(
                $"{Indent}public {propertyType}{nullableSymbol} {propertyName.GetCSharpPropertyName()} {{ get; set; }}"
            );

            if (i != amountCheckValue)
            {
                await WriteLineAsync();
            }

            i++;
        }

        await WriteLineAsync('}');
    }

    private async Task GenerateEmptyClass(string typeName)
    {
        if (typeName.Contains('.'))
        {
            var pathData = typeName.Split('.')[0..^1];
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(NamespaceBase);
            foreach (var pathDataEntry in pathData)
            {
                stringBuilder.Append($".{pathDataEntry}");
            }

            stringBuilder.Append(';');
            await WriteLineAsync(stringBuilder.ToString());
        }
        else
        {
            await WriteLineAsync(NameSpace);
        }

        await WriteLineAsync();

        await WriteLineAsync($"public class {typeName.Split('.').Last()}");
        await WriteLineAsync('{');

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
}
