using System.Collections.ObjectModel;
using DotNetBungieAPI.OpenApi.Models;

namespace DotNetBungieAPI.OpenApi.Metadata;

public class EnumTypeData : TypeData
{
    public bool IsFlags { get; private set; }
    public string Format { get; private set; }
    public ReadOnlyCollection<EnumValueData> Values { get; private set; }

    public EnumTypeData(string typeName, OpenApiComponentSchema openApiComponentSchema) :
        base(typeName, openApiComponentSchema)
    {
    }

    protected override void AnalyzeSchema(OpenApiComponentSchema openApiComponentSchema)
    {
        IsFlags = openApiComponentSchema.EnumIsBitmask;
        Format = openApiComponentSchema.Format!;
        var enumValues = openApiComponentSchema
            .EnumValues!
            .Select(x => new EnumValueData(x))
            .ToList();
        Values = new ReadOnlyCollection<EnumValueData>(enumValues);
    }
}