namespace DotNetBungieAPI.Generated.Models.Destiny.Milestones;

public class DestinyMilestoneChallengeActivity : IDeepEquatable<DestinyMilestoneChallengeActivity>
{
    [JsonPropertyName("activityHash")]
    public uint ActivityHash { get; set; }

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

    /// <summary>
    ///     If the Activity has discrete "phases" that we can track, that info will be here. Otherwise, this value will be NULL. Note that this is a list and not a dictionary: the order implies the ascending order of phases or progression in this activity.
    /// </summary>
    [JsonPropertyName("phases")]
    public List<Destiny.Milestones.DestinyMilestoneActivityPhase> Phases { get; set; }

    public bool DeepEquals(DestinyMilestoneChallengeActivity? other)
    {
        return other is not null &&
               ActivityHash == other.ActivityHash &&
               Challenges.DeepEqualsList(other.Challenges) &&
               ModifierHashes.DeepEqualsListNaive(other.ModifierHashes) &&
               BooleanActivityOptions.DeepEqualsDictionaryNaive(other.BooleanActivityOptions) &&
               LoadoutRequirementIndex == other.LoadoutRequirementIndex &&
               Phases.DeepEqualsList(other.Phases);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyMilestoneChallengeActivity? other)
    {
        if (other is null) return;
        if (ActivityHash != other.ActivityHash)
        {
            ActivityHash = other.ActivityHash;
            OnPropertyChanged(nameof(ActivityHash));
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
        if (!Phases.DeepEqualsList(other.Phases))
        {
            Phases = other.Phases;
            OnPropertyChanged(nameof(Phases));
        }
    }
}