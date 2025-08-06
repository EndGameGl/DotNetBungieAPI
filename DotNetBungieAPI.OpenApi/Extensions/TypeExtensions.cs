using System.Diagnostics.CodeAnalysis;
using DotNetBungieAPI.OpenApi.Models.ComponentSchemas;

namespace DotNetBungieAPI.OpenApi.Extensions;

public static class TypeExtensions
{
    internal static bool As<T>(this IOpenApiComponentSchema schema, [NotNullWhen(true)] out T? wantedSchema)
        where T : class, IOpenApiComponentSchema
    {
        wantedSchema = null;

        if (schema is T typedSchema)
        {
            wantedSchema = typedSchema;
            return true;
        }

        return false;
    }

    public static bool AsArray(this IOpenApiComponentSchema schema, [NotNullWhen(true)] out OpenApiArrayComponentSchema? componentSchema)
    {
        return schema.As(out componentSchema);
    }

    public static bool AsDictionary(this IOpenApiComponentSchema schema, [NotNullWhen(true)] out OpenApiDictionaryComponentSchema? componentSchema)
    {
        return schema.As(out componentSchema);
    }

    public static bool AsEnumType(this IOpenApiComponentSchema schema, [NotNullWhen(true)] out OpenApiEnumComponentSchema? componentSchema)
    {
        return schema.As(out componentSchema);
    }

    public static bool AsObjectType(this IOpenApiComponentSchema schema, [NotNullWhen(true)] out OpenApiObjectComponentSchema? componentSchema)
    {
        return schema.As(out componentSchema);
    }
}
