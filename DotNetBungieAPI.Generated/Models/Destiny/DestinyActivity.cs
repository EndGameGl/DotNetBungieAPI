namespace DotNetBungieAPI.Generated.Models.Destiny;

/// <summary>
///     Represents the "Live" data that we can obtain about a Character's status with a specific Activity. This will tell you whether the character can participate in the activity, as well as some other basic mutable information. 
/// <para />
///     Meant to be combined with static DestinyActivityDefinition data for a full picture of the Activity.
/// </summary>
public class DestinyActivity : IDeepEquatable<DestinyActivity>
{
    /// <summary>
    ///     The hash identifier of the Activity. Use this to look up the DestinyActivityDefinition of the activity.
    /// </summary>
    [JsonPropertyName("activityHash")]
    public uint ActivityHash { get; set; }

    /// <summary>
    ///     If true, then the activity should have a "new" indicator in the Director UI.
    /// </summary>
    [JsonPropertyName("isNew")]
    public bool IsNew { get; set; }

    /// <summary>
    ///     If true, the user is allowed to lead a Fireteam into this activity.
    /// </summary>
    [JsonPropertyName("canLead")]
    public bool CanLead { get; set; }

    /// <summary>
    ///     If true, the user is allowed to join with another Fireteam in this activity.
    /// </summary>
    [JsonPropertyName("canJoin")]
    public bool CanJoin { get; set; }

    /// <summary>
    ///     If true, we both have the ability to know that the user has completed this activity and they have completed it. Unfortunately, we can't necessarily know this for all activities. As such, this should probably only be used if you already know in advance which specific activities you wish to check.
    /// </summary>
    [JsonPropertyName("isCompleted")]
    public bool IsCompleted { get; set; }

    /// <summary>
    ///     If true, the user should be able to see this activity.
    /// </summary>
    [JsonPropertyName("isVisible")]
    public bool IsVisible { get; set; }

    /// <summary>
    ///     The difficulty level of the activity, if applicable.
    /// </summary>
    [JsonPropertyName("displayLevel")]
    public int? DisplayLevel { get; set; }

    /// <summary>
    ///     The recommended light level for the activity, if applicable.
    /// </summary>
    [JsonPropertyName("recommendedLight")]
    public int? RecommendedLight { get; set; }

    /// <summary>
    ///     A DestinyActivityDifficultyTier enum value indicating the difficulty of the activity.
    /// </summary>
    [JsonPropertyName("difficultyTier")]
    public Destiny.DestinyActivityDifficultyTier DifficultyTier { get; set; }

    [JsonPropertyName("challenges")]
    public List<Destiny.Challenges.DestinyChallengeStatus> Challenges { get; set; }

    /// <summary>
    ///     If the activity has modifiers, this will be the list of modifiers that all variants have in common. Perform lookups against DestinyActivityModifierDefinition which defines the modifier being applied to get at the modifier data.
    /// <para />
    ///     Note that, in the DestiyActivityDefinition, you will see many more modifiers than this being referred to: those are all *possible* modifiers for the activity, not the active ones. Use only the active ones to match what's really live.
    /// </summary>
    [JsonPropertyName("modifierHashes")]
    public List<uint> ModifierHashes { get; set; }

    /// <summary>
    ///     The set of activity options for this activity, keyed by an identifier that's unique for this activity (not guaranteed to be unique between or across all activities, though should be unique for every *variant* of a given *conceptual* activity: for instance, the original D2 Raid has many variant DestinyActivityDefinitions. While other activities could potentially have the same option hashes, for any given D2 base Raid variant the hash will be unique).
    /// <para />
    ///     As a concrete example of this data, the hashes you get for Raids will correspond to the currently active "Challenge Mode".
    /// <para />
    ///     We don't have any human readable information for these, but saavy 3rd party app users could manually associate the key (a hash identifier for the "option" that is enabled/disabled) and the value (whether it's enabled or disabled presently)
    /// <para />
    ///     On our side, we don't necessarily even know what these are used for (the game designers know, but we don't), and we have no human readable data for them. In order to use them, you will have to do some experimentation.
    /// </summary>
    [JsonPropertyName("booleanActivityOptions")]
    public Dictionary<uint, bool> BooleanActivityOptions { get; set; }

    /// <summary>
    ///     If returned, this is the index into the DestinyActivityDefinition's "loadouts" property, indicating the currently active loadout requirements.
    /// </summary>
    [JsonPropertyName("loadoutRequirementIndex")]
    public int? LoadoutRequirementIndex { get; set; }

    public bool DeepEquals(DestinyActivity? other)
    {
        return other is not null &&
               ActivityHash == other.ActivityHash &&
               IsNew == other.IsNew &&
               CanLead == other.CanLead &&
               CanJoin == other.CanJoin &&
               IsCompleted == other.IsCompleted &&
               IsVisible == other.IsVisible &&
               DisplayLevel == other.DisplayLevel &&
               RecommendedLight == other.RecommendedLight &&
               DifficultyTier == other.DifficultyTier &&
               Challenges.DeepEqualsList(other.Challenges) &&
               ModifierHashes.DeepEqualsListNaive(other.ModifierHashes) &&
               BooleanActivityOptions.DeepEqualsDictionaryNaive(other.BooleanActivityOptions) &&
               LoadoutRequirementIndex == other.LoadoutRequirementIndex;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyActivity? other)
    {
        if (other is null) return;
        if (ActivityHash != other.ActivityHash)
        {
            ActivityHash = other.ActivityHash;
            OnPropertyChanged(nameof(ActivityHash));
        }
        if (IsNew != other.IsNew)
        {
            IsNew = other.IsNew;
            OnPropertyChanged(nameof(IsNew));
        }
        if (CanLead != other.CanLead)
        {
            CanLead = other.CanLead;
            OnPropertyChanged(nameof(CanLead));
        }
        if (CanJoin != other.CanJoin)
        {
            CanJoin = other.CanJoin;
            OnPropertyChanged(nameof(CanJoin));
        }
        if (IsCompleted != other.IsCompleted)
        {
            IsCompleted = other.IsCompleted;
            OnPropertyChanged(nameof(IsCompleted));
        }
        if (IsVisible != other.IsVisible)
        {
            IsVisible = other.IsVisible;
            OnPropertyChanged(nameof(IsVisible));
        }
        if (DisplayLevel != other.DisplayLevel)
        {
            DisplayLevel = other.DisplayLevel;
            OnPropertyChanged(nameof(DisplayLevel));
        }
        if (RecommendedLight != other.RecommendedLight)
        {
            RecommendedLight = other.RecommendedLight;
            OnPropertyChanged(nameof(RecommendedLight));
        }
        if (DifficultyTier != other.DifficultyTier)
        {
            DifficultyTier = other.DifficultyTier;
            OnPropertyChanged(nameof(DifficultyTier));
        }
        if (!Challenges.DeepEqualsList(other.Challenges))
        {
            Challenges = other.Challenges;
            OnPropertyChanged(nameof(Challenges));
        }
        if (!ModifierHashes.DeepEqualsListNaive(other.ModifierHashes))
        {
            ModifierHashes = other.ModifierHashes;
            OnPropertyChanged(nameof(ModifierHashes));
        }
        if (!BooleanActivityOptions.DeepEqualsDictionaryNaive(other.BooleanActivityOptions))
        {
            BooleanActivityOptions = other.BooleanActivityOptions;
            OnPropertyChanged(nameof(BooleanActivityOptions));
        }
        if (LoadoutRequirementIndex != other.LoadoutRequirementIndex)
        {
            LoadoutRequirementIndex = other.LoadoutRequirementIndex;
            OnPropertyChanged(nameof(LoadoutRequirementIndex));
        }
    }
}