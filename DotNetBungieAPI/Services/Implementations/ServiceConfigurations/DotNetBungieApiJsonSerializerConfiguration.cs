namespace DotNetBungieAPI.Services.Implementations.ServiceConfigurations;

public sealed class DotNetBungieApiJsonSerializerConfiguration
{
    public JsonSerializerOptions Options { get; internal set; } = new();
}