namespace DotNetBungieAPI.Models.Destiny.Definitions.FireteamFinder;

public sealed class DestinyActivityInteractableReference
{
    [JsonPropertyName("activityInteractableHash")]
    public DefinitionHashPointer<Destiny.Definitions.Activities.DestinyActivityInteractableDefinition> ActivityInteractableHash { get; init; }

    [JsonPropertyName("activityInteractableElementIndex")]
    public int ActivityInteractableElementIndex { get; init; }
}
