namespace DotNetBungieAPI.Models.Destiny.Definitions.FireteamFinder;

public sealed class DestinyFireteamFinderOptionSearcherSettings
{
    [JsonPropertyName("control")]
    public Destiny.Definitions.FireteamFinder.DestinyFireteamFinderOptionSettingsControl? Control { get; init; }

    [JsonPropertyName("searchFilterType")]
    public Destiny.FireteamFinderOptionSearchFilterType SearchFilterType { get; init; }
}
