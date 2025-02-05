namespace DotNetBungieAPI.Models.FireteamFinder;

public sealed record DestinyFireteamFinderApplicantSet
{
    [JsonPropertyName("applicants")]
    public ReadOnlyCollection<DestinyFireteamFinderApplicant> Applicants { get; init; } =
        ReadOnlyCollection<DestinyFireteamFinderApplicant>.Empty;
}
