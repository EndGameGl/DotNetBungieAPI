namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public class DestinyPlayer : IDeepEquatable<DestinyPlayer>
{
    /// <summary>
    ///     Details about the player as they are known in game (platform display name, Destiny emblem)
    /// </summary>
    [JsonPropertyName("destinyUserInfo")]
    public User.UserInfoCard DestinyUserInfo { get; set; }

    /// <summary>
    ///     Class of the character if applicable and available.
    /// </summary>
    [JsonPropertyName("characterClass")]
    public string CharacterClass { get; set; }

    [JsonPropertyName("classHash")]
    public uint ClassHash { get; set; }

    [JsonPropertyName("raceHash")]
    public uint RaceHash { get; set; }

    [JsonPropertyName("genderHash")]
    public uint GenderHash { get; set; }

    /// <summary>
    ///     Level of the character if available. Zero if it is not available.
    /// </summary>
    [JsonPropertyName("characterLevel")]
    public int CharacterLevel { get; set; }

    /// <summary>
    ///     Light Level of the character if available. Zero if it is not available.
    /// </summary>
    [JsonPropertyName("lightLevel")]
    public int LightLevel { get; set; }

    /// <summary>
    ///     Details about the player as they are known on BungieNet. This will be undefined if the player has marked their credential private, or does not have a BungieNet account.
    /// </summary>
    [JsonPropertyName("bungieNetUserInfo")]
    public User.UserInfoCard BungieNetUserInfo { get; set; }

    /// <summary>
    ///     Current clan name for the player. This value may be null or an empty string if the user does not have a clan.
    /// </summary>
    [JsonPropertyName("clanName")]
    public string ClanName { get; set; }

    /// <summary>
    ///     Current clan tag for the player. This value may be null or an empty string if the user does not have a clan.
    /// </summary>
    [JsonPropertyName("clanTag")]
    public string ClanTag { get; set; }

    /// <summary>
    ///     If we know the emblem's hash, this can be used to look up the player's emblem at the time of a match when receiving PGCR data, or otherwise their currently equipped emblem (if we are able to obtain it).
    /// </summary>
    [JsonPropertyName("emblemHash")]
    public uint EmblemHash { get; set; }

    public bool DeepEquals(DestinyPlayer? other)
    {
        return other is not null &&
               (DestinyUserInfo is not null ? DestinyUserInfo.DeepEquals(other.DestinyUserInfo) : other.DestinyUserInfo is null) &&
               CharacterClass == other.CharacterClass &&
               ClassHash == other.ClassHash &&
               RaceHash == other.RaceHash &&
               GenderHash == other.GenderHash &&
               CharacterLevel == other.CharacterLevel &&
               LightLevel == other.LightLevel &&
               (BungieNetUserInfo is not null ? BungieNetUserInfo.DeepEquals(other.BungieNetUserInfo) : other.BungieNetUserInfo is null) &&
               ClanName == other.ClanName &&
               ClanTag == other.ClanTag &&
               EmblemHash == other.EmblemHash;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyPlayer? other)
    {
        if (other is null) return;
        if (!DestinyUserInfo.DeepEquals(other.DestinyUserInfo))
        {
            DestinyUserInfo.Update(other.DestinyUserInfo);
            OnPropertyChanged(nameof(DestinyUserInfo));
        }
        if (CharacterClass != other.CharacterClass)
        {
            CharacterClass = other.CharacterClass;
            OnPropertyChanged(nameof(CharacterClass));
        }
        if (ClassHash != other.ClassHash)
        {
            ClassHash = other.ClassHash;
            OnPropertyChanged(nameof(ClassHash));
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
        if (CharacterLevel != other.CharacterLevel)
        {
            CharacterLevel = other.CharacterLevel;
            OnPropertyChanged(nameof(CharacterLevel));
        }
        if (LightLevel != other.LightLevel)
        {
            LightLevel = other.LightLevel;
            OnPropertyChanged(nameof(LightLevel));
        }
        if (!BungieNetUserInfo.DeepEquals(other.BungieNetUserInfo))
        {
            BungieNetUserInfo.Update(other.BungieNetUserInfo);
            OnPropertyChanged(nameof(BungieNetUserInfo));
        }
        if (ClanName != other.ClanName)
        {
            ClanName = other.ClanName;
            OnPropertyChanged(nameof(ClanName));
        }
        if (ClanTag != other.ClanTag)
        {
            ClanTag = other.ClanTag;
            OnPropertyChanged(nameof(ClanTag));
        }
        if (EmblemHash != other.EmblemHash)
        {
            EmblemHash = other.EmblemHash;
            OnPropertyChanged(nameof(EmblemHash));
        }
    }
}