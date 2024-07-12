namespace DotNetBungieAPI.Models.Destiny.Definitions.FireteamFinder;

public sealed record DestinyFireteamFinderOptionCreatorSettings
{
    [JsonPropertyName("control")]
    public DestinyFireteamFinderOptionSettingsControl Control { get; init; }
}
