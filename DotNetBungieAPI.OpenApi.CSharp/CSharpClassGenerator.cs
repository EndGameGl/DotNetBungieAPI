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

        await WriteLineAsync($"public class {typeData.TypeName}");
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
                $"{Indent}public {propertyTypeData.GetCSharpType()} {propertyTypeData.OriginPropertyName.GetCSharpPropertyName()} {{ get; set; }}");

            if (i != amountCheckValue)
            {
                await WriteLineAsync();
            }
        }
        
        await WriteLineAsync('}');
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

        await WriteLineAsync($"public enum {typeData.TypeName} : {Resources.TypeMappings[typeData.Format]}");
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
}