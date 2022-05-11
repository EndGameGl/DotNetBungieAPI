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
}