using System.Collections.ObjectModel;
using System.Diagnostics;
using DotNetBungieAPI.OpenApi.Models;

namespace DotNetBungieAPI.OpenApi.Metadata;

[DebuggerDisplay("{FullTypeName}")]
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
            .Properties?
            .Select(x => new PropertyTypeData(x.Key, x.Value))
            .ToList();

        if (properties is null)
        {
            Properties = new ReadOnlyCollection<PropertyTypeData>(Array.Empty<PropertyTypeData>());
        }
        else
        {
            Properties = new ReadOnlyCollection<PropertyTypeData>(properties);
        }
    }
}