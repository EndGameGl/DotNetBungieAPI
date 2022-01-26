namespace DotNetBungieAPI.Generated.Models.Destiny.Milestones;

public class DestinyPublicMilestoneChallengeActivity : IDeepEquatable<DestinyPublicMilestoneChallengeActivity>
{
    [JsonPropertyName("activityHash")]
    public uint ActivityHash { get; set; }

    [JsonPropertyName("challengeObjectiveHashes")]
    public List<uint> ChallengeObjectiveHashes { get; set; }

    /// <summary>
    ///     If the activity has modifiers, this will be the list of modifiers that all variants have in common. Perform lookups against DestinyActivityModifierDefinition which defines the modifier being applied to get at the modifier data.
    /// <para />
    ///     Note that, in the DestiyActivityDefinition, you will see many more modifiers than this being referred to: those are all *possible* modifiers for the activity, not the active ones. Use only the active ones to match what's really live.
    /// </summary>
    [JsonPropertyName("modifierHashes")]
    public List<uint> ModifierHashes { get; set; }

    /// <summary>
    ///     If returned, this is the index into the DestinyActivityDefinition's "loadouts" property, indicating the currently active loadout requirements.
    /// </summary>
    [JsonPropertyName("loadoutRequirementIndex")]
    public int? LoadoutRequirementIndex { get; set; }

    /// <summary>
    ///     The ordered list of phases for this activity, if any. Note that we have no human readable info for phases, nor any entities to relate them to: relating these hashes to something human readable is up to you unfortunately.
    /// </summary>
    [JsonPropertyName("phaseHashes")]
    public List<uint> PhaseHashes { get; set; }

    /// <summary>
    ///     The set of activity options for this activity, keyed by an identifier that's unique for this activity (not guaranteed to be unique between or across all activities, though should be unique for every *variant* of a given *conceptual* activity: for instance, the original D2 Raid has many variant DestinyActivityDefinitions. While other activities could potentially have the same option hashes, for any given D2 base Raid variant the hash will be unique).
    /// <para />
    ///     As a concrete example of this data, the hashes you get for Raids will correspond to the currently active "Challenge Mode".
    /// <para />
    ///     We have no human readable information for this data, so it's up to you if you want to associate it with such info to show it.
    /// </summary>
    [JsonPropertyName("booleanActivityOptions")]
    public Dictionary<uint, bool> BooleanActivityOptions { get; set; }

    public bool DeepEquals(DestinyPublicMilestoneChallengeActivity? other)
    {
        return other is not null &&
               ActivityHash == other.ActivityHash &&
               ChallengeObjectiveHashes.DeepEqualsListNaive(other.ChallengeObjectiveHashes) &&
               ModifierHashes.DeepEqualsListNaive(other.ModifierHashes) &&
               LoadoutRequirementIndex == other.LoadoutRequirementIndex &&
               PhaseHashes.DeepEqualsListNaive(other.PhaseHashes) &&
               BooleanActivityOptions.DeepEqualsDictionaryNaive(other.BooleanActivityOptions);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyPublicMilestoneChallengeActivity? other)
    {
        if (other is null) return;
        if (ActivityHash != other.ActivityHash)
        {
            ActivityHash = other.ActivityHash;
            OnPropertyChanged(nameof(ActivityHash));
        }
        if (!ChallengeObjectiveHashes.DeepEqualsListNaive(other.ChallengeObjectiveHashes))
        {
            ChallengeObjectiveHashes = other.ChallengeObjectiveHashes;
            OnPropertyChanged(nameof(ChallengeObjectiveHashes));
        }
        if (!ModifierHashes.DeepEqualsListNaive(other.ModifierHashes))
        {
            ModifierHashes = other.ModifierHashes;
            OnPropertyChanged(nameof(ModifierHashes));
        }
        if (LoadoutRequirementIndex != other.LoadoutRequirementIndex)
        {
            LoadoutRequirementIndex = other.LoadoutRequirementIndex;
            OnPropertyChanged(nameof(LoadoutRequirementIndex));
        }
        if (!PhaseHashes.DeepEqualsListNaive(other.PhaseHashes))
        {
            PhaseHashes = other.PhaseHashes;
            OnPropertyChanged(nameof(PhaseHashes));
        }
        if (!BooleanActivityOptions.DeepEqualsDictionaryNaive(other.BooleanActivityOptions))
        {
            BooleanActivityOptions = other.BooleanActivityOptions;
            OnPropertyChanged(nameof(BooleanActivityOptions));
        }
    }
}