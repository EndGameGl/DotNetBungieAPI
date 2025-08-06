namespace DotNetBungieAPI.Models.Destiny.Definitions.FireteamFinder;

public sealed class DestinyActivityGraphReference
{
    [JsonPropertyName("activityGraphHash")]
    public DefinitionHashPointer<Destiny.Definitions.Director.DestinyActivityGraphDefinition> ActivityGraphHash { get; init; }
}
