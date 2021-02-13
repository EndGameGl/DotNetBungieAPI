using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.Locations;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Objectives
{
    /// <summary>
    /// Defines an "Objective".
    /// <para/>
    /// An objective is a specific task you should accomplish in the game.These are referred to by:
    /// <para/>
    /// - Quest Steps (which are DestinyInventoryItemDefinition entities with Objectives)
    /// <para/>
    ///- Challenges(which are Objectives defined on an DestinyActivityDefintion)
    /// <para/>
    ///- Milestones(which refer to Objectives that are defined on both Quest Steps and Activities)
    /// <para/>
    ///- Anything else that the designers decide to do later.
    /// <para/>
    /// Objectives have progress, a notion of having been Completed, human readable data describing the task to be accomplished, and a lot of optional tack-on data that can enhance the information provided about the task.
    /// </summary>
    [DestinyDefinition(type: DefinitionsEnum.DestinyObjectiveDefinition, presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinyObjectiveDefinition : IDestinyDefinition, IDeepEquatable<DestinyObjectiveDefinition>
    {
        /// <summary>
        /// If true, the value is allowed to go negative.
        /// </summary>
        public bool AllowNegativeValue { get; }
        /// <summary>
        /// If True, the progress will continue even beyond the point where the objective met its minimum completion requirements. Your UI will have to accommodate it.
        /// </summary>
        public bool AllowOvercompletion { get; }
        /// <summary>
        /// If true, you can effectively "un-complete" this objective if you lose progress after crossing the completion threshold.
        /// <para/>
        /// If False, once you complete the task it will remain completed forever by locking the value.
        /// </summary>
        public bool AllowValueChangeWhenCompleted { get; }      
        /// <summary>
        /// The value that the unlock value defined in unlockValueHash must reach in order for the objective to be considered Completed. Used in calculating progress and completion status.
        /// </summary>
        public int CompletionValue { get; }        
        /// <summary>
        /// If true, completion means having an unlock value less than or equal to the completionValue.
        /// <para/>
        /// If False, completion means having an unlock value greater than or equal to the completionValue
        /// </summary>
        public bool IsCountingDownward { get; }
        public bool IsDisplayOnlyObjective { get; }
        /// <summary>
        /// The location at which this objective must be accomplished
        /// </summary>
        public DefinitionHashPointer<DestinyLocationDefinition> Location { get; }
        /// <summary>
        /// If nonzero, this is the minimum value at which the objective's progression should be shown. Otherwise, don't show it yet.
        /// </summary>
        public int MinimumVisibilityThreshold { get; }    
        /// <summary>
        /// Text to describe the progress bar.
        /// </summary>
        public string ProgressDescription { get; }
        /// <summary>
        /// A shortcut for determining the most restrictive gating that this Objective is set to use. This includes both the dynamic determination of progress and of completion values.
        /// </summary>
        public Scope Scope { get; }
        /// <summary>
        /// If True, you should continue showing the progression value in the UI after it's complete. I mean, we already do that in BNet anyways, but if you want to be better behaved than us you could honor this flag.
        /// </summary>
        public bool ShowValueOnComplete { get; }
        /// <summary>
        /// If this objective enables Perks intrinsically, the conditions for that enabling are defined here.
        /// </summary>
        public ObjectivePerks Perks { get; }
        /// <summary>
        /// If this objective enables modifications on a player's stats intrinsically, the conditions are defined here.
        /// </summary>
        public ObjectiveStats Stats { get; }
        /// <summary>
        /// The UI style applied to the objective. It's an enum, take a look at DestinyUnlockValueUIStyle for details of the possible styles. Use this info as you wish to customize your UI.
        /// </summary>
        public ObjectiveUnlockValueUIStyle ValueStyle { get; }
        /// <summary>
        /// The style to use when the objective is completed.
        /// </summary>
        public ObjectiveUnlockValueUIStyle CompletedValueStyle { get; }
        /// <summary>
        /// The style to use when the objective is still in progress.
        /// </summary>
        public ObjectiveUnlockValueUIStyle InProgressValueStyle { get; }
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyObjectiveDefinition(DestinyDefinitionDisplayProperties displayProperties, bool allowNegativeValue, bool allowOvercompletion, bool allowValueChangeWhenCompleted,
            ObjectiveUnlockValueUIStyle completedValueStyle, int completionValue, ObjectiveUnlockValueUIStyle inProgressValueStyle, bool isCountingDownward, bool isDisplayOnlyObjective, uint locationHash,
            int minimumVisibilityThreshold, ObjectivePerks perks, string progressDescription, Scope scope, bool showValueOnComplete, ObjectiveStats stats, ObjectiveUnlockValueUIStyle valueStyle,
            bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            AllowNegativeValue = allowNegativeValue;
            AllowOvercompletion = allowOvercompletion;
            AllowValueChangeWhenCompleted = allowValueChangeWhenCompleted;
            CompletedValueStyle = completedValueStyle;
            CompletionValue = completionValue;
            InProgressValueStyle = inProgressValueStyle;
            IsCountingDownward = isCountingDownward;
            IsDisplayOnlyObjective = isDisplayOnlyObjective;
            Location = new DefinitionHashPointer<DestinyLocationDefinition>(locationHash, DefinitionsEnum.DestinyLocationDefinition);
            MinimumVisibilityThreshold = minimumVisibilityThreshold;
            Perks = perks;
            ProgressDescription = progressDescription;
            Scope = scope;
            ShowValueOnComplete = showValueOnComplete;
            Stats = stats;
            ValueStyle = valueStyle;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description} {ProgressDescription}";
        }

        public bool DeepEquals(DestinyObjectiveDefinition other)
        {
            return other != null &&
                   AllowNegativeValue == other.AllowNegativeValue &&
                   AllowOvercompletion == other.AllowOvercompletion &&
                   AllowValueChangeWhenCompleted == other.AllowValueChangeWhenCompleted &&
                   CompletionValue == other.CompletionValue &&
                   IsCountingDownward == other.IsCountingDownward &&
                   IsDisplayOnlyObjective == other.IsDisplayOnlyObjective &&
                   Location.DeepEquals(other.Location) &&
                   MinimumVisibilityThreshold == other.MinimumVisibilityThreshold &&
                   ProgressDescription == other.ProgressDescription &&
                   Scope == other.Scope &&
                   ShowValueOnComplete == other.ShowValueOnComplete &&
                   (Perks != null ? Perks.DeepEquals(other.Perks) : other == null) &&
                   (Stats != null ? Stats.DeepEquals(other.Stats) : other == null) &&
                   ValueStyle == other.ValueStyle &&
                   CompletedValueStyle == other.CompletedValueStyle &&
                   InProgressValueStyle == other.InProgressValueStyle &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
        public void MapValues()
        {
            Location.TryMapValue();
            Perks?.Perk.TryMapValue();
            Stats?.Stat?.StatType.TryMapValue();
        }
    }
}
