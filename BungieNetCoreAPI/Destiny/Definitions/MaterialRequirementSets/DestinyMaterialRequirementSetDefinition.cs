using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Definitions.MaterialRequirementSets
{
    /// <summary>
    /// Represent a set of material requirements: Items that either need to be owned or need to be consumed in order to perform an action.
    /// <para/>
    /// A variety of other entities refer to these as gatekeepers and payments for actions that can be performed in game.
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyMaterialRequirementSetDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyMaterialRequirementSetDefinition : IDestinyDefinition, IDeepEquatable<DestinyMaterialRequirementSetDefinition>
    {
        /// <summary>
        /// The list of all materials that are required.
        /// </summary>
        public ReadOnlyCollection<MaterialRequirementSetEntry> Materials { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyMaterialRequirementSetDefinition(MaterialRequirementSetEntry[] materials, bool blacklisted, uint hash, int index, bool redacted)
        {
            Materials = materials.AsReadOnlyOrEmpty();
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash}";
        }

        public bool DeepEquals(DestinyMaterialRequirementSetDefinition other)
        {
            return other != null &&
                   Materials.DeepEqualsReadOnlyCollections(other.Materials) &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }

        public void MapValues()
        {
            foreach (var material in Materials)
            {
                material.Item.TryMapValue();
            }
        }
    }
}
