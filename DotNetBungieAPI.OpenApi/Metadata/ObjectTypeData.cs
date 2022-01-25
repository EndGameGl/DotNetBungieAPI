using System.Collections.ObjectModel;
using DotNetBungieAPI.OpenApi.Models;

namespace DotNetBungieAPI.OpenApi.Metadata;

public class ObjectTypeData : TypeData
{
    public ReadOnlyCollection<PropertyTypeData> Properties { get; private set; }

    public ObjectTypeData(string typeName, OpenApiComponentSchema openApiComponentSchema) :
        base(typeName, openApiComponentSchema)
    {
    }

    protected override void AnalyzeSchema(OpenApiComponentSchema openApiComponentSchema)
    {
        var properties = openApiComponentSchema
            .Properties
            .Select(x => new PropertyTypeData(x.Key, x.Value))
            .ToList();
        Properties = new ReadOnlyCollection<PropertyTypeData>(properties);
    }

    public override async Task SerializeTypeDataToStream(StreamWriter streamWriter)
    {
        if (Description is not null)
        {
            await WriteComment(false, Description, streamWriter);
        }

        await streamWriter.WriteLineAsync($"public class {TypeName}");
        await streamWriter.WriteLineAsync('{');

        var totalValues = Properties.Count;
        var amountCheckValue = totalValues - 1;
        for (var i = 0; i < totalValues; i++)
        {
            var propertyTypeData = Properties[i];
            if (propertyTypeData.Description is not null)
            {
                await WriteComment(true, propertyTypeData.Description, streamWriter);
            }

            await streamWriter.WriteLineAsync($"{Indent}[JsonPropertyName(\"{propertyTypeData.OriginPropertyName}\")]");
            await streamWriter.WriteLineAsync(
                $"{Indent}public {propertyTypeData.PropertyTypeName} {propertyTypeData.CSharpPropertyName} {{ get; set; }}");
            if (i != amountCheckValue)
            {
                await streamWriter.WriteLineAsync();
            }
        }

        await streamWriter.WriteLineAsync('}');
    }
}