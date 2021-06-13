using NetBungieAPI.Attributes;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.MaterialRequirementSets
{
    /// <summary>
    /// Represent a set of material requirements: Items that either need to be owned or need to be consumed in order to perform an action.
    /// <para/>
    /// A variety of other entities refer to these as gatekeepers and payments for actions that can be performed in game.
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyMaterialRequirementSetDefinition)]
    public sealed record DestinyMaterialRequirementSetDefinition : IDestinyDefinition,
        IDeepEquatable<DestinyMaterialRequirementSetDefinition>
    {
        /// <summary>
        /// The list of all materials that are required.
        /// </summary>
        [JsonPropertyName("materials")]
        public ReadOnlyCollection<DestinyMaterialRequirement> Materials { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyMaterialRequirement>();

        [JsonPropertyName("blacklisted")] public bool Blacklisted { get; init; }
        [JsonPropertyName("hash")] public uint Hash { get; init; }
        [JsonPropertyName("index")] public int Index { get; init; }
        [JsonPropertyName("redacted")] public bool Redacted { get; init; }

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