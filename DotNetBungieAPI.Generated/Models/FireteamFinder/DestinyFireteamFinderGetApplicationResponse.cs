namespace DotNetBungieAPI.Generated.Models.FireteamFinder;

public class DestinyFireteamFinderGetApplicationResponse
{
    [JsonPropertyName("applicationId")]
    public long? ApplicationId { get; set; }

    [JsonPropertyName("revision")]
    public int? Revision { get; set; }

    [JsonPropertyName("state")]
    public FireteamFinder.DestinyFireteamFinderApplicationState? State { get; set; }

    [JsonPropertyName("submitterId")]
    public FireteamFinder.DestinyFireteamFinderPlayerId? SubmitterId { get; set; }

    [JsonPropertyName("referralToken")]
    public long? ReferralToken { get; set; }

    [JsonPropertyName("applicantSet")]
    public FireteamFinder.DestinyFireteamFinderApplicantSet? ApplicantSet { get; set; }

    [JsonPropertyName("applicationType")]
    public FireteamFinder.DestinyFireteamFinderApplicationType? ApplicationType { get; set; }

    [JsonPropertyName("listingId")]
    public long? ListingId { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }
}
