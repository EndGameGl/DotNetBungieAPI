using System.Diagnostics.CodeAnalysis;
using DotNetBungieAPI.OpenApi.Models.ComponentSchemas;

namespace DotNetBungieAPI.OpenApi.CodeGeneration;

public abstract class ModelGeneratorBase
{
    public Models.OpenApi Spec { get; internal set; }
    public abstract string FileExtension { get; }
    public StreamWriter Writer { get; internal set; }

    public abstract Task GenerateFromSchema(string typeName, IOpenApiComponentSchema schema);

    public virtual bool CanHandle(IOpenApiComponentSchema schema) => true;

    protected async Task WriteAsync(string text)
    {
        await Writer.WriteAsync(text);
    }

    protected async Task WriteAsync(char text)
    {
        await Writer.WriteAsync(text);
    }

    protected async Task WriteLineAsync()
    {
        await Writer.WriteLineAsync();
    }

    protected async Task WriteLineAsync(string text)
    {
        await Writer.WriteLineAsync(text);
    }

    protected async Task WriteLineAsync(char text)
    {
        await Writer.WriteLineAsync(text);
    }

    protected bool TryFindMatchingSchema(
        OpenApiEnumComponentSchema property,
        [NotNullWhen(true)] out string? enumSchemaName
    )
    {
        enumSchemaName = null;

        foreach (
            var (schemaName, schema) in Spec.Components.Schemas.Where(x =>
                x.Value is OpenApiEnumComponentSchema
            )
        )
        {
            var openApiEnumComponentSchema = (OpenApiEnumComponentSchema)schema;

            if (property.EnumValues.Length != openApiEnumComponentSchema.EnumValues.Length)
            {
                continue;
            }

            var validMatch = true;
            for (var i = 0; i < property.EnumValues.Length; i++)
            {
                var propertyEnumValue = property.EnumValues[i];
                var schemaEnumValue = openApiEnumComponentSchema.EnumValues[i];

                if (propertyEnumValue.Identifier != schemaEnumValue.Identifier)
                {
                    validMatch = false;
                    break;
                }
            }

            if (!validMatch)
            {
                continue;
            }

            enumSchemaName = schemaName;
            return true;
        }

        return false;
    }
}
