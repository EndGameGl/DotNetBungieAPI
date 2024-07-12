using DotNetBungieAPI.Models.Destiny.Definitions.FireteamFinder;

namespace DotNetBungieAPI.Models.FireteamFinder;

public sealed record DestinyFireteamFinderGetCharacterActivityAccessResponse
{
    /// <summary>
    ///     A map of fireteam finder activity graph hashes to visibility and availability states.
    /// </summary>
    [JsonPropertyName("fireteamFinderActivityGraphStates")]
    public ReadOnlyDictionary<
        DefinitionHashPointer<DestinyFireteamFinderActivityGraphDefinition>,
        DestinyFireteamFinderActivityGraphState
    > FireteamFinderActivityGraphStates { get; init; } =
        ReadOnlyDictionaries<
            DefinitionHashPointer<DestinyFireteamFinderActivityGraphDefinition>,
            DestinyFireteamFinderActivityGraphState
        >.Empty;
}
