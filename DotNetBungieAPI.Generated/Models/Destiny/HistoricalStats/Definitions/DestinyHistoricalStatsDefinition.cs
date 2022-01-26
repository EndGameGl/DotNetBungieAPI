namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats.Definitions;

public class DestinyHistoricalStatsDefinition : IDeepEquatable<DestinyHistoricalStatsDefinition>
{
    /// <summary>
    ///     Unique programmer friendly ID for this stat
    /// </summary>
    [JsonPropertyName("statId")]
    public string StatId { get; set; }

    /// <summary>
    ///     Statistic group
    /// </summary>
    [JsonPropertyName("group")]
    public Destiny.HistoricalStats.Definitions.DestinyStatsGroupType Group { get; set; }

    /// <summary>
    ///     Time periods the statistic covers
    /// </summary>
    [JsonPropertyName("periodTypes")]
    public List<Destiny.HistoricalStats.Definitions.PeriodType> PeriodTypes { get; set; }

    /// <summary>
    ///     Game modes where this statistic can be reported.
    /// </summary>
    [JsonPropertyName("modes")]
    public List<Destiny.HistoricalStats.Definitions.DestinyActivityModeType> Modes { get; set; }

    /// <summary>
    ///     Category for the stat.
    /// </summary>
    [JsonPropertyName("category")]
    public Destiny.HistoricalStats.Definitions.DestinyStatsCategoryType Category { get; set; }

    /// <summary>
    ///     Display name
    /// </summary>
    [JsonPropertyName("statName")]
    public string StatName { get; set; }

    /// <summary>
    ///     Display name abbreviated
    /// </summary>
    [JsonPropertyName("statNameAbbr")]
    public string StatNameAbbr { get; set; }

    /// <summary>
    ///     Description of a stat if applicable.
    /// </summary>
    [JsonPropertyName("statDescription")]
    public string StatDescription { get; set; }

    /// <summary>
    ///     Unit, if any, for the statistic
    /// </summary>
    [JsonPropertyName("unitType")]
    public Destiny.HistoricalStats.Definitions.UnitType UnitType { get; set; }

    /// <summary>
    ///     Optional URI to an icon for the statistic
    /// </summary>
    [JsonPropertyName("iconImage")]
    public string IconImage { get; set; }

    /// <summary>
    ///     Optional icon for the statistic
    /// </summary>
    [JsonPropertyName("mergeMethod")]
    public int? MergeMethod { get; set; }

    /// <summary>
    ///     Localized Unit Name for the stat.
    /// </summary>
    [JsonPropertyName("unitLabel")]
    public string UnitLabel { get; set; }

    /// <summary>
    ///     Weight assigned to this stat indicating its relative impressiveness.
    /// </summary>
    [JsonPropertyName("weight")]
    public int Weight { get; set; }

    /// <summary>
    ///     The tier associated with this medal - be it implicitly or explicitly.
    /// </summary>
    [JsonPropertyName("medalTierHash")]
    public uint? MedalTierHash { get; set; }

    public bool DeepEquals(DestinyHistoricalStatsDefinition? other)
    {
        return other is not null &&
               StatId == other.StatId &&
               Group == other.Group &&
               PeriodTypes.DeepEqualsListNaive(other.PeriodTypes) &&
               Modes.DeepEqualsListNaive(other.Modes) &&
               Category == other.Category &&
               StatName == other.StatName &&
               StatNameAbbr == other.StatNameAbbr &&
               StatDescription == other.StatDescription &&
               UnitType == other.UnitType &&
               IconImage == other.IconImage &&
               MergeMethod == other.MergeMethod &&
               UnitLabel == other.UnitLabel &&
               Weight == other.Weight &&
               MedalTierHash == other.MedalTierHash;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyHistoricalStatsDefinition? other)
    {
        if (other is null) return;
        if (StatId != other.StatId)
        {
            StatId = other.StatId;
            OnPropertyChanged(nameof(StatId));
        }
        if (Group != other.Group)
        {
            Group = other.Group;
            OnPropertyChanged(nameof(Group));
        }
        if (!PeriodTypes.DeepEqualsListNaive(other.PeriodTypes))
        {
            PeriodTypes = other.PeriodTypes;
            OnPropertyChanged(nameof(PeriodTypes));
        }
        if (!Modes.DeepEqualsListNaive(other.Modes))
        {
            Modes = other.Modes;
            OnPropertyChanged(nameof(Modes));
        }
        if (Category != other.Category)
        {
            Category = other.Category;
            OnPropertyChanged(nameof(Category));
        }
        if (StatName != other.StatName)
        {
            StatName = other.StatName;
            OnPropertyChanged(nameof(StatName));
        }
        if (StatNameAbbr != other.StatNameAbbr)
        {
            StatNameAbbr = other.StatNameAbbr;
            OnPropertyChanged(nameof(StatNameAbbr));
        }
        if (StatDescription != other.StatDescription)
        {
            StatDescription = other.StatDescription;
            OnPropertyChanged(nameof(StatDescription));
        }
        if (UnitType != other.UnitType)
        {
            UnitType = other.UnitType;
            OnPropertyChanged(nameof(UnitType));
        }
        if (IconImage != other.IconImage)
        {
            IconImage = other.IconImage;
            OnPropertyChanged(nameof(IconImage));
        }
        if (MergeMethod != other.MergeMethod)
        {
            MergeMethod = other.MergeMethod;
            OnPropertyChanged(nameof(MergeMethod));
        }
        if (UnitLabel != other.UnitLabel)
        {
            UnitLabel = other.UnitLabel;
            OnPropertyChanged(nameof(UnitLabel));
        }
        if (Weight != other.Weight)
        {
            Weight = other.Weight;
            OnPropertyChanged(nameof(Weight));
        }
        if (MedalTierHash != other.MedalTierHash)
        {
            MedalTierHash = other.MedalTierHash;
            OnPropertyChanged(nameof(MedalTierHash));
        }
    }
}