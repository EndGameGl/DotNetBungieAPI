using DotNetBungieAPI.OpenApi.Extensions;
using DotNetBungieAPI.OpenApi.Models;

namespace DotNetBungieAPI.OpenApi.Metadata;

public abstract class TypeData
{
    protected const string Indent = "    ";
    
    public string FullTypeName { get; }
    public string TypeName { get; }
    public string? Description { get; }

    public TypeData(string typeName, OpenApiComponentSchema openApiComponentSchema)
    {
        FullTypeName = typeName;
        TypeName = typeName.GetTypeName();
        Description = openApiComponentSchema.Description;
        AnalyzeSchema(openApiComponentSchema);
    }

    protected abstract void AnalyzeSchema(OpenApiComponentSchema openApiComponentSchema);
    
    public static TypeData CreateTypeData(
        string typeName,
        OpenApiComponentSchema openApiComponentSchema)
    {
        switch (openApiComponentSchema)
        {
            case { Enum: not null }:
                return new EnumTypeData(typeName, openApiComponentSchema);
            case { Type: "object" }:
                return new ObjectTypeData(typeName, openApiComponentSchema);
            default:
                throw new Exception("Type conversion not supported");
        }
    }
}