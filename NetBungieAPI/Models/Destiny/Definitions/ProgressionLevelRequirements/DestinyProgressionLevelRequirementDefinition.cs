using NetBungieAPI.Attributes;
using NetBungieAPI.Models.Destiny.Definitions.Progressions;
using NetBungieAPI.Models.Interpolation;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.ProgressionLevelRequirements
{
    /// <summary>
    /// These are pre-constructed collections of data that can be used to determine the Level Requirement for an item given a Progression to be tested (such as the Character's level).
    /// <para/>
    /// For instance, say a character receives a new Auto Rifle, and that Auto Rifle's DestinyInventoryItemDefinition.quality.progressionLevelRequirementHash property is pointing at one of these DestinyProgressionLevelRequirementDefinitions. Let's pretend also that the progressionHash it is pointing at is the Character Level progression.In that situation, the character's level will be used to interpolate a value in the requirementCurve property. The value picked up from that interpolation will be the required level for the item.
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyProgressionLevelRequirementDefinition)]
    public sealed record DestinyProgressionLevelRequirementDefinition : IDestinyDefinition,
        IDeepEquatable<DestinyProgressionLevelRequirementDefinition>
    {
        /// <summary>
        /// The progression whose level should be used to determine the level requirement.
        /// </summary>
        [JsonPropertyName("progressionHash")]
        public DefinitionHashPointer<DestinyProgressionDefinition> Progression { get; init; } =
            DefinitionHashPointer<DestinyProgressionDefinition>.Empty;

        /// <summary>
        /// A curve of level requirements, weighted by the related progressions' level.
        /// <para/>
        /// Interpolate against this curve with the character's progression level to determine what the level requirement of the generated item that is using this data will be.
        /// </summary>
        [JsonPropertyName("requirementCurve")]
        public ReadOnlyCollection<InterpolationPointFloat> RequirementCurve { get; init; } =
            Defaults.EmptyReadOnlyCollection<InterpolationPointFloat>();

        [JsonPropertyName("blacklisted")] public bool Blacklisted { get; init; }
        [JsonPropertyName("hash")] public uint Hash { get; init; }
        [JsonPropertyName("index")] public int Index { get; init; }
        [JsonPropertyName("redacted")] public bool Redacted { get; init; }

        public override string ToString()
        {
            return $"{Hash}";
        }

        public bool DeepEquals(DestinyProgressionLevelRequirementDefinition other)
        {
            return other != null &&
                   Progression.DeepEquals(other.Progression) &&
                   RequirementCurve.DeepEqualsReadOnlyCollections(other.RequirementCurve) &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }

        public void MapValues()
        {
            Progression.TryMapValue();
        }
    }
}