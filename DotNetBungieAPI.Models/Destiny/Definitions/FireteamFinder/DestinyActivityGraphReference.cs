using DotNetBungieAPI.Models.Destiny.Definitions.ActivityGraphs;

namespace DotNetBungieAPI.Models.Destiny.Definitions.FireteamFinder;

public sealed record DestinyActivityGraphReference
{
    [JsonPropertyName("activityGraphHash")]
    public DefinitionHashPointer<DestinyActivityGraphDefinition> ActivityGraph { get; init; } =
        DefinitionHashPointer<DestinyActivityGraphDefinition>.Empty;
}
