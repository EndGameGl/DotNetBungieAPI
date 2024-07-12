namespace DotNetBungieAPI.Generated.Models.Fireteam;

public class FireteamSummary
{
    [JsonPropertyName("fireteamId")]
    public long? FireteamId { get; set; }

    [JsonPropertyName("groupId")]
    public long? GroupId { get; set; }

    [JsonPropertyName("platform")]
    public Fireteam.FireteamPlatform? Platform { get; set; }

    [JsonPropertyName("activityType")]
    public int? ActivityType { get; set; }

    [JsonPropertyName("isImmediate")]
    public bool? IsImmediate { get; set; }

    [JsonPropertyName("scheduledTime")]
    public DateTime? ScheduledTime { get; set; }

    [JsonPropertyName("ownerMembershipId")]
    public long? OwnerMembershipId { get; set; }

    [JsonPropertyName("playerSlotCount")]
    public int? PlayerSlotCount { get; set; }

    [JsonPropertyName("alternateSlotCount")]
    public int? AlternateSlotCount { get; set; }

    [JsonPropertyName("availablePlayerSlotCount")]
    public int? AvailablePlayerSlotCount { get; set; }

    [JsonPropertyName("availableAlternateSlotCount")]
    public int? AvailableAlternateSlotCount { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("dateCreated")]
    public DateTime? DateCreated { get; set; }

    [JsonPropertyName("dateModified")]
    public DateTime? DateModified { get; set; }

    [JsonPropertyName("isPublic")]
    public bool? IsPublic { get; set; }

    [JsonPropertyName("locale")]
    public string? Locale { get; set; }

    [JsonPropertyName("isValid")]
    public bool? IsValid { get; set; }

    [JsonPropertyName("datePlayerModified")]
    public DateTime? DatePlayerModified { get; set; }

    [JsonPropertyName("titleBeforeModeration")]
    public string? TitleBeforeModeration { get; set; }

    [Destiny2Definition<Destiny.Definitions.GuardianRanks.DestinyGuardianRankDefinition>("Destiny.Definitions.GuardianRanks.DestinyGuardianRankDefinition")]
    [JsonPropertyName("ownerCurrentGuardianRankSnapshot")]
    public int? OwnerCurrentGuardianRankSnapshot { get; set; }

    [Destiny2Definition<Destiny.Definitions.GuardianRanks.DestinyGuardianRankDefinition>("Destiny.Definitions.GuardianRanks.DestinyGuardianRankDefinition")]
    [JsonPropertyName("ownerHighestLifetimeGuardianRankSnapshot")]
    public int? OwnerHighestLifetimeGuardianRankSnapshot { get; set; }

    [JsonPropertyName("ownerTotalCommendationScoreSnapshot")]
    public int? OwnerTotalCommendationScoreSnapshot { get; set; }
}
