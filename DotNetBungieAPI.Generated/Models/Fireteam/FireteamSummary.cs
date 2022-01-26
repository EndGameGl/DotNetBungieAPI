namespace DotNetBungieAPI.Generated.Models.Fireteam;

public class FireteamSummary : IDeepEquatable<FireteamSummary>
{
    [JsonPropertyName("fireteamId")]
    public long FireteamId { get; set; }

    [JsonPropertyName("groupId")]
    public long GroupId { get; set; }

    [JsonPropertyName("platform")]
    public Fireteam.FireteamPlatform Platform { get; set; }

    [JsonPropertyName("activityType")]
    public int ActivityType { get; set; }

    [JsonPropertyName("isImmediate")]
    public bool IsImmediate { get; set; }

    [JsonPropertyName("scheduledTime")]
    public DateTime? ScheduledTime { get; set; }

    [JsonPropertyName("ownerMembershipId")]
    public long OwnerMembershipId { get; set; }

    [JsonPropertyName("playerSlotCount")]
    public int PlayerSlotCount { get; set; }

    [JsonPropertyName("alternateSlotCount")]
    public int? AlternateSlotCount { get; set; }

    [JsonPropertyName("availablePlayerSlotCount")]
    public int AvailablePlayerSlotCount { get; set; }

    [JsonPropertyName("availableAlternateSlotCount")]
    public int AvailableAlternateSlotCount { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("dateCreated")]
    public DateTime DateCreated { get; set; }

    [JsonPropertyName("dateModified")]
    public DateTime? DateModified { get; set; }

    [JsonPropertyName("isPublic")]
    public bool IsPublic { get; set; }

    [JsonPropertyName("locale")]
    public string Locale { get; set; }

    [JsonPropertyName("isValid")]
    public bool IsValid { get; set; }

    [JsonPropertyName("datePlayerModified")]
    public DateTime DatePlayerModified { get; set; }

    [JsonPropertyName("titleBeforeModeration")]
    public string TitleBeforeModeration { get; set; }

    public bool DeepEquals(FireteamSummary? other)
    {
        return other is not null &&
               FireteamId == other.FireteamId &&
               GroupId == other.GroupId &&
               Platform == other.Platform &&
               ActivityType == other.ActivityType &&
               IsImmediate == other.IsImmediate &&
               ScheduledTime == other.ScheduledTime &&
               OwnerMembershipId == other.OwnerMembershipId &&
               PlayerSlotCount == other.PlayerSlotCount &&
               AlternateSlotCount == other.AlternateSlotCount &&
               AvailablePlayerSlotCount == other.AvailablePlayerSlotCount &&
               AvailableAlternateSlotCount == other.AvailableAlternateSlotCount &&
               Title == other.Title &&
               DateCreated == other.DateCreated &&
               DateModified == other.DateModified &&
               IsPublic == other.IsPublic &&
               Locale == other.Locale &&
               IsValid == other.IsValid &&
               DatePlayerModified == other.DatePlayerModified &&
               TitleBeforeModeration == other.TitleBeforeModeration;
    }
}