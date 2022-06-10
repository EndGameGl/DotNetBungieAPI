using DotNetBungieAPI.OpenApi.CodeGeneration;
using DotNetBungieAPI.OpenApi.Metadata;

namespace DotNetBungieAPI.OpenApi.JavaScript;

public class JavaScriptClassGenerator : ModelGeneratorBase
{
    private const string Indent = "    ";
    public override string FileExtension => "js";

    public override async Task GenerateDataForObjectType(ObjectTypeData typeData)
    {
        if (typeData.Description is not null)
        {
            await WriteLineAsync($"/** {typeData.Description} */");
        }
        await WriteLineAsync($"class {typeData.TypeName} {{");
        foreach (var propertyTypeData in typeData.Properties)
        {
            await WriteLineAsync($"{Indent}/** @type {{{propertyTypeData.TypeReference}}} */");
            await WriteLineAsync($"{Indent}{propertyTypeData.OriginPropertyName};");
        }

        await WriteLineAsync('}');
    }

    public override async Task GenerateDataForEnumType(EnumTypeData typeData)
    {
        if (typeData.Description is not null)
        {
            await WriteLineAsync($"/** {typeData.Description} */");
        }
        
        await WriteLineAsync($"const {typeData.TypeName} = {{");

        var totalValues = typeData.Values.Count;
        var amountCheckValue = totalValues - 1;
        for (var i = 0; i < totalValues; i++)
        {
            var enumValueData = typeData.Values[i];

            await WriteLineAsync(
                $"{Indent}{enumValueData.Name}: {enumValueData.Value}{(i != amountCheckValue ? "," : string.Empty)}");
        }

        await WriteLineAsync('}');
    }
}