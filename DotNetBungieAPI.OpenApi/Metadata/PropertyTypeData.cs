using DotNetBungieAPI.OpenApi.Models;

namespace DotNetBungieAPI.OpenApi.Metadata;

public class PropertyTypeData
{
    public string CSharpPropertyName { get; }
    public string OriginPropertyName { get; }
    public string PropertyTypeName { get; }
    public string Description { get; }

    public PropertyTypeData(
        string typeName, 
        OpenApiComponentSchema openApiComponentSchema)
    {
        OriginPropertyName = typeName;
        PropertyTypeName = openApiComponentSchema.GetCSharpType();
        Description = openApiComponentSchema.Description;
        CSharpPropertyName = $"{char.ToUpper(typeName[0])}{typeName[1..]}";
    }
}