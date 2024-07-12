namespace DotNetBungieAPI.Models.FireteamFinder;

public sealed record DestinyFireteamFinderRespondToApplicationResponse
{
    [JsonPropertyName("applicationId")]
    public long ApplicationId { get; init; }

    [JsonPropertyName("applicationRevision")]
    public int ApplicationRevision { get; init; }
}
