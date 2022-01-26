namespace DotNetBungieAPI.Generated.Models.Destiny.Entities.Characters;

/// <summary>
///     This component contains base properties of the character. You'll probably want to always request this component, but hey you do you.
/// </summary>
public class DestinyCharacterComponent : IDeepEquatable<DestinyCharacterComponent>
{
    /// <summary>
    ///     Every Destiny Profile has a membershipId. This is provided on the character as well for convenience.
    /// </summary>
    [JsonPropertyName("membershipId")]
    public long MembershipId { get; set; }

    /// <summary>
    ///     membershipType tells you the platform on which the character plays. Examine the BungieMembershipType enumeration for possible values.
    /// </summary>
    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; set; }

    /// <summary>
    ///     The unique identifier for the character.
    /// </summary>
    [JsonPropertyName("characterId")]
    public long CharacterId { get; set; }

    /// <summary>
    ///     The last date that the user played Destiny.
    /// </summary>
    [JsonPropertyName("dateLastPlayed")]
    public DateTime DateLastPlayed { get; set; }

    /// <summary>
    ///     If the user is currently playing, this is how long they've been playing.
    /// </summary>
    [JsonPropertyName("minutesPlayedThisSession")]
    public long MinutesPlayedThisSession { get; set; }

    /// <summary>
    ///     If this value is 525,600, then they played Destiny for a year. Or they're a very dedicated Rent fan. Note that this includes idle time, not just time spent actually in activities shooting things.
    /// </summary>
    [JsonPropertyName("minutesPlayedTotal")]
    public long MinutesPlayedTotal { get; set; }

    /// <summary>
    ///     The user's calculated "Light Level". Light level is an indicator of your power that mostly matters in the end game, once you've reached the maximum character level: it's a level that's dependent on the average Attack/Defense power of your items.
    /// </summary>
    [JsonPropertyName("light")]
    public int Light { get; set; }

    /// <summary>
    ///     Your character's stats, such as Agility, Resilience, etc... *not* historical stats.
    /// <para />
    ///     You'll have to call a different endpoint for those.
    /// </summary>
    [JsonPropertyName("stats")]
    public Dictionary<uint, int> Stats { get; set; }

    /// <summary>
    ///     Use this hash to look up the character's DestinyRaceDefinition.
    /// </summary>
    [JsonPropertyName("raceHash")]
    public uint RaceHash { get; set; }

    /// <summary>
    ///     Use this hash to look up the character's DestinyGenderDefinition.
    /// </summary>
    [JsonPropertyName("genderHash")]
    public uint GenderHash { get; set; }

    /// <summary>
    ///     Use this hash to look up the character's DestinyClassDefinition.
    /// </summary>
    [JsonPropertyName("classHash")]
    public uint ClassHash { get; set; }

    /// <summary>
    ///     Mostly for historical purposes at this point, this is an enumeration for the character's race.
    /// <para />
    ///     It'll be preferable in the general case to look up the related definition: but for some people this was too convenient to remove.
    /// </summary>
    [JsonPropertyName("raceType")]
    public Destiny.DestinyRace RaceType { get; set; }

    /// <summary>
    ///     Mostly for historical purposes at this point, this is an enumeration for the character's class.
    /// <para />
    ///     It'll be preferable in the general case to look up the related definition: but for some people this was too convenient to remove.
    /// </summary>
    [JsonPropertyName("classType")]
    public Destiny.DestinyClass ClassType { get; set; }

    /// <summary>
    ///     Mostly for historical purposes at this point, this is an enumeration for the character's Gender.
    /// <para />
    ///     It'll be preferable in the general case to look up the related definition: but for some people this was too convenient to remove. And yeah, it's an enumeration and not a boolean. Fight me.
    /// </summary>
    [JsonPropertyName("genderType")]
    public Destiny.DestinyGender GenderType { get; set; }

    /// <summary>
    ///     A shortcut path to the user's currently equipped emblem image. If you're just showing summary info for a user, this is more convenient than examining their equipped emblem and looking up the definition.
    /// </summary>
    [JsonPropertyName("emblemPath")]
    public string EmblemPath { get; set; }

    /// <summary>
    ///     A shortcut path to the user's currently equipped emblem background image. If you're just showing summary info for a user, this is more convenient than examining their equipped emblem and looking up the definition.
    /// </summary>
    [JsonPropertyName("emblemBackgroundPath")]
    public string EmblemBackgroundPath { get; set; }

    /// <summary>
    ///     The hash of the currently equipped emblem for the user. Can be used to look up the DestinyInventoryItemDefinition.
    /// </summary>
    [JsonPropertyName("emblemHash")]
    public uint EmblemHash { get; set; }

    /// <summary>
    ///     A shortcut for getting the background color of the user's currently equipped emblem without having to do a DestinyInventoryItemDefinition lookup.
    /// </summary>
    [JsonPropertyName("emblemColor")]
    public Destiny.Misc.DestinyColor EmblemColor { get; set; }

    /// <summary>
    ///     The progression that indicates your character's level. Not their light level, but their character level: you know, the thing you max out a couple hours in and then ignore for the sake of light level.
    /// </summary>
    [JsonPropertyName("levelProgression")]
    public Destiny.DestinyProgression LevelProgression { get; set; }

    /// <summary>
    ///     The "base" level of your character, not accounting for any light level.
    /// </summary>
    [JsonPropertyName("baseCharacterLevel")]
    public int BaseCharacterLevel { get; set; }

    /// <summary>
    ///     A number between 0 and 100, indicating the whole and fractional % remaining to get to the next character level.
    /// </summary>
    [JsonPropertyName("percentToNextLevel")]
    public float PercentToNextLevel { get; set; }

    /// <summary>
    ///     If this Character has a title assigned to it, this is the identifier of the DestinyRecordDefinition that has that title information.
    /// </summary>
    [JsonPropertyName("titleRecordHash")]
    public uint? TitleRecordHash { get; set; }

    public bool DeepEquals(DestinyCharacterComponent? other)
    {
        return other is not null &&
               MembershipId == other.MembershipId &&
               MembershipType == other.MembershipType &&
               CharacterId == other.CharacterId &&
               DateLastPlayed == other.DateLastPlayed &&
               MinutesPlayedThisSession == other.MinutesPlayedThisSession &&
               MinutesPlayedTotal == other.MinutesPlayedTotal &&
               Light == other.Light &&
               Stats.DeepEqualsDictionaryNaive(other.Stats) &&
               RaceHash == other.RaceHash &&
               GenderHash == other.GenderHash &&
               ClassHash == other.ClassHash &&
               RaceType == other.RaceType &&
               ClassType == other.ClassType &&
               GenderType == other.GenderType &&
               EmblemPath == other.EmblemPath &&
               EmblemBackgroundPath == other.EmblemBackgroundPath &&
               EmblemHash == other.EmblemHash &&
               (EmblemColor is not null ? EmblemColor.DeepEquals(other.EmblemColor) : other.EmblemColor is null) &&
               (LevelProgression is not null ? LevelProgression.DeepEquals(other.LevelProgression) : other.LevelProgression is null) &&
               BaseCharacterLevel == other.BaseCharacterLevel &&
               PercentToNextLevel == other.PercentToNextLevel &&
               TitleRecordHash == other.TitleRecordHash;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyCharacterComponent? other)
    {
        if (other is null) return;
        if (MembershipId != other.MembershipId)
        {
            MembershipId = other.MembershipId;
            OnPropertyChanged(nameof(MembershipId));
        }
        if (MembershipType != other.MembershipType)
        {
            MembershipType = other.MembershipType;
            OnPropertyChanged(nameof(MembershipType));
        }
        if (CharacterId != other.CharacterId)
        {
            CharacterId = other.CharacterId;
            OnPropertyChanged(nameof(CharacterId));
        }
        if (DateLastPlayed != other.DateLastPlayed)
        {
            DateLastPlayed = other.DateLastPlayed;
            OnPropertyChanged(nameof(DateLastPlayed));
        }
        if (MinutesPlayedThisSession != other.MinutesPlayedThisSession)
        {
            MinutesPlayedThisSession = other.MinutesPlayedThisSession;
            OnPropertyChanged(nameof(MinutesPlayedThisSession));
        }
        if (MinutesPlayedTotal != other.MinutesPlayedTotal)
        {
            MinutesPlayedTotal = other.MinutesPlayedTotal;
            OnPropertyChanged(nameof(MinutesPlayedTotal));
        }
        if (Light != other.Light)
        {
            Light = other.Light;
            OnPropertyChanged(nameof(Light));
        }
        if (!Stats.DeepEqualsDictionaryNaive(other.Stats))
        {
            Stats = other.Stats;
            OnPropertyChanged(nameof(Stats));
        }
        if (RaceHash != other.RaceHash)
        {
            RaceHash = other.RaceHash;
            OnPropertyChanged(nameof(RaceHash));
        }
        if (GenderHash != other.GenderHash)
        {
            GenderHash = other.GenderHash;
            OnPropertyChanged(nameof(GenderHash));
        }
        if (ClassHash != other.ClassHash)
        {
            ClassHash = other.ClassHash;
            OnPropertyChanged(nameof(ClassHash));
        }
        if (RaceType != other.RaceType)
        {
            RaceType = other.RaceType;
            OnPropertyChanged(nameof(RaceType));
        }
        if (ClassType != other.ClassType)
        {
            ClassType = other.ClassType;
            OnPropertyChanged(nameof(ClassType));
        }
        if (GenderType != other.GenderType)
        {
            GenderType = other.GenderType;
            OnPropertyChanged(nameof(GenderType));
        }
        if (EmblemPath != other.EmblemPath)
        {
            EmblemPath = other.EmblemPath;
            OnPropertyChanged(nameof(EmblemPath));
        }
        if (EmblemBackgroundPath != other.EmblemBackgroundPath)
        {
            EmblemBackgroundPath = other.EmblemBackgroundPath;
            OnPropertyChanged(nameof(EmblemBackgroundPath));
        }
        if (EmblemHash != other.EmblemHash)
        {
            EmblemHash = other.EmblemHash;
            OnPropertyChanged(nameof(EmblemHash));
        }
        if (!EmblemColor.DeepEquals(other.EmblemColor))
        {
            EmblemColor.Update(other.EmblemColor);
            OnPropertyChanged(nameof(EmblemColor));
        }
        if (!LevelProgression.DeepEquals(other.LevelProgression))
        {
            LevelProgression.Update(other.LevelProgression);
            OnPropertyChanged(nameof(LevelProgression));
        }
        if (BaseCharacterLevel != other.BaseCharacterLevel)
        {
            BaseCharacterLevel = other.BaseCharacterLevel;
            OnPropertyChanged(nameof(BaseCharacterLevel));
        }
        if (PercentToNextLevel != other.PercentToNextLevel)
        {
            PercentToNextLevel = other.PercentToNextLevel;
            OnPropertyChanged(nameof(PercentToNextLevel));
        }
        if (TitleRecordHash != other.TitleRecordHash)
        {
            TitleRecordHash = other.TitleRecordHash;
            OnPropertyChanged(nameof(TitleRecordHash));
        }
    }
}