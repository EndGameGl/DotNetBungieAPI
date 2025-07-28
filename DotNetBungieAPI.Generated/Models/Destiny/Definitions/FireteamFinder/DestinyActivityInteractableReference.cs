namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.FireteamFinder;

public class DestinyActivityInteractableReference
{
    [Destiny2Definition<Destiny.Definitions.Activities.DestinyActivityInteractableDefinition>("Destiny.Definitions.Activities.DestinyActivityInteractableDefinition")]
    [JsonPropertyName("activityInteractableHash")]
    public uint ActivityInteractableHash { get; set; }

    [JsonPropertyName("activityInteractableElementIndex")]
    public int ActivityInteractableElementIndex { get; set; }
}
