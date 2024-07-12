namespace DotNetBungieAPI.Models.FireteamFinder;

public sealed record DestinyFireteamFinderApplication
{
    [JsonPropertyName("applicationId")]
    public long ApplicationId { get; init; }

    [JsonPropertyName("revision")]
    public int Revision { get; init; }

    [JsonPropertyName("state")]
    public DestinyFireteamFinderApplicationState State { get; init; }

    [JsonPropertyName("submitterId")]
    public DestinyFireteamFinderPlayerId SubmitterId { get; init; }

    [JsonPropertyName("referralToken")]
    public long ReferralToken { get; init; }

    [JsonPropertyName("applicantSet")]
    public DestinyFireteamFinderApplicantSet ApplicantSet { get; init; }

    [JsonPropertyName("applicationType")]
    public DestinyFireteamFinderApplicationType ApplicationType { get; init; }

    [JsonPropertyName("listingId")]
    public long ListingId { get; init; }

    [JsonPropertyName("createdDateTime")]
    public DateTime CreatedDateTime { get; init; }
}
