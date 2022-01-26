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

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(FireteamSummary? other)
    {
        if (other is null) return;
        if (FireteamId != other.FireteamId)
        {
            FireteamId = other.FireteamId;
            OnPropertyChanged(nameof(FireteamId));
        }
        if (GroupId != other.GroupId)
        {
            GroupId = other.GroupId;
            OnPropertyChanged(nameof(GroupId));
        }
        if (Platform != other.Platform)
        {
            Platform = other.Platform;
            OnPropertyChanged(nameof(Platform));
        }
        if (ActivityType != other.ActivityType)
        {
            ActivityType = other.ActivityType;
            OnPropertyChanged(nameof(ActivityType));
        }
        if (IsImmediate != other.IsImmediate)
        {
            IsImmediate = other.IsImmediate;
            OnPropertyChanged(nameof(IsImmediate));
        }
        if (ScheduledTime != other.ScheduledTime)
        {
            ScheduledTime = other.ScheduledTime;
            OnPropertyChanged(nameof(ScheduledTime));
        }
        if (OwnerMembershipId != other.OwnerMembershipId)
        {
            OwnerMembershipId = other.OwnerMembershipId;
            OnPropertyChanged(nameof(OwnerMembershipId));
        }
        if (PlayerSlotCount != other.PlayerSlotCount)
        {
            PlayerSlotCount = other.PlayerSlotCount;
            OnPropertyChanged(nameof(PlayerSlotCount));
        }
        if (AlternateSlotCount != other.AlternateSlotCount)
        {
            AlternateSlotCount = other.AlternateSlotCount;
            OnPropertyChanged(nameof(AlternateSlotCount));
        }
        if (AvailablePlayerSlotCount != other.AvailablePlayerSlotCount)
        {
            AvailablePlayerSlotCount = other.AvailablePlayerSlotCount;
            OnPropertyChanged(nameof(AvailablePlayerSlotCount));
        }
        if (AvailableAlternateSlotCount != other.AvailableAlternateSlotCount)
        {
            AvailableAlternateSlotCount = other.AvailableAlternateSlotCount;
            OnPropertyChanged(nameof(AvailableAlternateSlotCount));
        }
        if (Title != other.Title)
        {
            Title = other.Title;
            OnPropertyChanged(nameof(Title));
        }
        if (DateCreated != other.DateCreated)
        {
            DateCreated = other.DateCreated;
            OnPropertyChanged(nameof(DateCreated));
        }
        if (DateModified != other.DateModified)
        {
            DateModified = other.DateModified;
            OnPropertyChanged(nameof(DateModified));
        }
        if (IsPublic != other.IsPublic)
        {
            IsPublic = other.IsPublic;
            OnPropertyChanged(nameof(IsPublic));
        }
        if (Locale != other.Locale)
        {
            Locale = other.Locale;
            OnPropertyChanged(nameof(Locale));
        }
        if (IsValid != other.IsValid)
        {
            IsValid = other.IsValid;
            OnPropertyChanged(nameof(IsValid));
        }
        if (DatePlayerModified != other.DatePlayerModified)
        {
            DatePlayerModified = other.DatePlayerModified;
            OnPropertyChanged(nameof(DatePlayerModified));
        }
        if (TitleBeforeModeration != other.TitleBeforeModeration)
        {
            TitleBeforeModeration = other.TitleBeforeModeration;
            OnPropertyChanged(nameof(TitleBeforeModeration));
        }
    }
}