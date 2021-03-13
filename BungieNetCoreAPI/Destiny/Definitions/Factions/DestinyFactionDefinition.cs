using NetBungieApi.Attributes;
using NetBungieApi.Destiny.Definitions.InventoryItems;
using NetBungieApi.Destiny.Definitions.Progressions;
using NetBungieApi.Destiny.Definitions.Vendors;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieApi.Destiny.Definitions.Factions
{
    /// <summary>
    /// These definitions represent Factions in the game. Factions have ended up unilaterally being related to Vendors that represent them, but that need not necessarily be the case.
    /// <para/>
    /// A Faction is really just an entity that has a related progression for which a character can gain experience.In Destiny 1, Dead Orbit was an example of a Faction: there happens to be a Vendor that represents Dead Orbit (and indeed, DestinyVendorDefinition.factionHash defines to this relationship), but Dead Orbit could theoretically exist without the Vendor that provides rewards.
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyFactionDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyFactionDefinition : IDestinyDefinition, IDeepEquatable<DestinyFactionDefinition>
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        /// <summary>
        /// DestinyProgressionDefinition that indicates the character's relationship with this faction in terms of experience and levels.
        /// </summary>
        public DefinitionHashPointer<DestinyProgressionDefinition> Progression { get; }
        /// <summary>
        /// The faction reward item hash, usually an engram.
        /// </summary>
        public DefinitionHashPointer<DestinyInventoryItemDefinition> RewardItem { get; }
        /// <summary>
        /// The faction reward vendor, used for faction engram previews.
        /// </summary>
        public DefinitionHashPointer<DestinyVendorDefinition> RewardVendor { get; }
        /// <summary>
        /// The faction token items, and their respective progression values.
        /// </summary>
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyInventoryItemDefinition>, int> TokenValues { get; }
        /// <summary>
        /// List of vendors that are associated with this faction. The last vendor that passes the unlock flag checks is the one that should be shown.
        /// </summary>
        public ReadOnlyCollection<FactionVendor> Vendors { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyFactionDefinition(uint progressionHash, uint rewardItemHash, uint rewardVendorHash, DestinyDefinitionDisplayProperties displayProperties,
            Dictionary<uint, int> tokenValues, FactionVendor[] vendors,
            bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            Progression = new DefinitionHashPointer<DestinyProgressionDefinition>(progressionHash, DefinitionsEnum.DestinyProgressionDefinition);
            RewardItem = new DefinitionHashPointer<DestinyInventoryItemDefinition>(rewardItemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            RewardVendor = new DefinitionHashPointer<DestinyVendorDefinition>(rewardVendorHash, DefinitionsEnum.DestinyVendorDefinition);
            TokenValues = tokenValues.AsReadOnlyDictionaryWithDefinitionKeyOrEmpty<DestinyInventoryItemDefinition, int>(DefinitionsEnum.DestinyInventoryItemDefinition);
            Vendors = vendors.AsReadOnlyOrEmpty();
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }

        public bool DeepEquals(DestinyFactionDefinition other)
        {
            return other != null &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   Progression.DeepEquals(other.Progression) &&
                   RewardItem.DeepEquals(other.RewardItem) &&
                   RewardVendor.DeepEquals(other.RewardVendor) &&
                   TokenValues.DeepEqualsReadOnlyDictionaryWithDefinitionKeyAndSimpleValue(other.TokenValues) &&
                   Vendors.DeepEqualsReadOnlyCollections(other.Vendors) &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }

        public void MapValues()
        {
            Progression.TryMapValue();
            RewardItem.TryMapValue();
            RewardVendor.TryMapValue();
            foreach (var item in TokenValues.Keys)
            {
                item.TryMapValue();
            }
            foreach (var vendor in Vendors)
            {
                vendor.Destination.TryMapValue();
                vendor.Vendor.TryMapValue();
            }
        }
    }
}
