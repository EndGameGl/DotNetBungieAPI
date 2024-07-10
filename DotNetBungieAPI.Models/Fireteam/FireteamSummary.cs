using DotNetBungieAPI.Models.Destiny.Definitions.ActivityModes;
using DotNetBungieAPI.Models.Destiny.Definitions.GuardianRanks;

namespace DotNetBungieAPI.Models.Fireteam;

public sealed record FireteamSummary
{
    [JsonPropertyName("fireteamId")]
    public long FireteamId { get; init; }

    [JsonPropertyName("groupId")]
    public long GroupId { get; init; }

    [JsonPropertyName("platform")]
    public FireteamPlatform Platform { get; init; }

    [JsonPropertyName("activityType")]
    public DestinyActivityModeType ActivityType { get; init; }

    [JsonPropertyName("isImmediate")]
    public bool IsImmediate { get; init; }

    [JsonPropertyName("scheduledTime")]
    public DateTime? ScheduledTime { get; init; }

    [JsonPropertyName("ownerMembershipId")]
    public long OwnerMembershipId { get; init; }

    [JsonPropertyName("playerSlotCount")]
    public int PlayerSlotCount { get; init; }

    [JsonPropertyName("alternateSlotCount")]
    public int? AlternateSlotCount { get; init; }

    [JsonPropertyName("availablePlayerSlotCount")]
    public int AvailablePlayerSlotCount { get; init; }

    [JsonPropertyName("availableAlternateSlotCount")]
    public int AvailableAlternateSlotCount { get; init; }

    [JsonPropertyName("title")]
    public string Title { get; init; }

    [JsonPropertyName("dateCreated")]
    public DateTime DateCreated { get; init; }

    [JsonPropertyName("dateModified")]
    public DateTime? DateModified { get; init; }

    [JsonPropertyName("isPublic")]
    public bool IsPublic { get; init; }

    [JsonPropertyName("locale")]
    public string Locale { get; init; }

    [JsonPropertyName("isValid")]
    public bool IsValid { get; init; }

    [JsonPropertyName("datePlayerModified")]
    public DateTime DatePlayerModified { get; init; }

    [JsonPropertyName("titleBeforeModeration")]
    public string TitleBeforeModeration { get; init; }

    [JsonPropertyName("ownerCurrentGuardianRankSnapshot")]
    public DefinitionHashPointer<DestinyGuardianRankDefinition> OwnerCurrentGuardianRankSnapshot { get; init; } =
        DefinitionHashPointer<DestinyGuardianRankDefinition>.Empty;

    [JsonPropertyName("ownerHighestLifetimeGuardianRankSnapshot")]
    public DefinitionHashPointer<DestinyGuardianRankDefinition> OwnerHighestLifetimeGuardianRankSnapshot { get; init; } =
        DefinitionHashPointer<DestinyGuardianRankDefinition>.Empty;

    [JsonPropertyName("ownerTotalCommendationScoreSnapshot")]
    public int OwnerTotalCommendationScoreSnapshot { get; init; }
}
