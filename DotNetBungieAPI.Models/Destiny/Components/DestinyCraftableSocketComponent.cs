using DotNetBungieAPI.Models.Destiny.Definitions.PlugSets;

namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DestinyCraftableSocketComponent
{
    [JsonPropertyName("plugSetHash")]
    public DefinitionHashPointer<DestinyPlugSetDefinition> PlugSet { get; init; } =
        DefinitionHashPointer<DestinyPlugSetDefinition>.Empty;

    [JsonPropertyName("plugs")]
    public ReadOnlyCollection<DestinyCraftableSocketPlugComponent> Plugs { get; init; } =
        ReadOnlyCollection<DestinyCraftableSocketPlugComponent>.Empty;
}
