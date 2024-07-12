using DotNetBungieAPI.Models.Destiny.Definitions.ActivityInteractables;

namespace DotNetBungieAPI.Models.Destiny.Definitions.FireteamFinder;

public sealed record DestinyActivityInteractableReference
{
    [JsonPropertyName("activityInteractableHash")]
    public DefinitionHashPointer<DestinyActivityInteractableDefinition> ActivityInteractable { get; init; } =
        DefinitionHashPointer<DestinyActivityInteractableDefinition>.Empty;

    [JsonPropertyName("activityInteractableElementIndex")]
    public int ActivityInteractableElementIndex { get; init; }
}
