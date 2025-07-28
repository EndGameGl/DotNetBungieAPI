namespace DotNetBungieAPI.OpenApi.Models.ComponentSchemas;

public interface IMappedDefinition
{
    OpenApiComponentReference? MappedDefinition { get; init; }
}
