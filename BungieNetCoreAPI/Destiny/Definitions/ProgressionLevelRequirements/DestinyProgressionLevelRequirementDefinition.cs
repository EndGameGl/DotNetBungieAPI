using NetBungieAPI.Attributes;
using NetBungieAPI.Destiny.Definitions.Progressions;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.ProgressionLevelRequirements
{
    /// <summary>
    /// These are pre-constructed collections of data that can be used to determine the Level Requirement for an item given a Progression to be tested (such as the Character's level).
    /// <para/>
    /// For instance, say a character receives a new Auto Rifle, and that Auto Rifle's DestinyInventoryItemDefinition.quality.progressionLevelRequirementHash property is pointing at one of these DestinyProgressionLevelRequirementDefinitions. Let's pretend also that the progressionHash it is pointing at is the Character Level progression.In that situation, the character's level will be used to interpolate a value in the requirementCurve property. The value picked up from that interpolation will be the required level for the item.
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyProgressionLevelRequirementDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyProgressionLevelRequirementDefinition : IDestinyDefinition, IDeepEquatable<DestinyProgressionLevelRequirementDefinition>
    {
        public DefinitionHashPointer<DestinyProgressionDefinition> Progression { get; }
        public ReadOnlyCollection<ProgressionLevelRequirementCurveEntry> RequirementCurve { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyProgressionLevelRequirementDefinition(uint progressionHash, ProgressionLevelRequirementCurveEntry[] requirementCurve,
            bool blacklisted, uint hash, int index, bool redacted)
        {
            Progression = new DefinitionHashPointer<DestinyProgressionDefinition>(progressionHash, DefinitionsEnum.DestinyProgressionDefinition);
            RequirementCurve = requirementCurve.AsReadOnlyOrEmpty();
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

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
