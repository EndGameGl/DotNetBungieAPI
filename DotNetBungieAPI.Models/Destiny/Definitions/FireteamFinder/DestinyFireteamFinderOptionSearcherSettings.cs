namespace DotNetBungieAPI.Models.Destiny.Definitions.FireteamFinder;

public sealed record DestinyFireteamFinderOptionSearcherSettings
{
    [JsonPropertyName("control")]
    public DestinyFireteamFinderOptionSettingsControl Control { get; init; }

    [JsonPropertyName("searchFilterType")]
    public FireteamFinderOptionSearchFilterType SearchFilterType { get; init; }
}
