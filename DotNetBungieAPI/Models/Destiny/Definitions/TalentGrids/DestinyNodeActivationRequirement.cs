using DotNetBungieAPI.Models.Destiny.Definitions.MaterialRequirementSets;

namespace DotNetBungieAPI.Models.Destiny.Definitions.TalentGrids
{
    /// <summary>
    ///     Talent nodes have requirements that must be met before they can be activated.
    ///     <para />
    ///     This describes the material costs, the Level of the Talent Grid's progression required, and other conditional
    ///     information that limits whether a talent node can be activated.
    /// </summary>
    public sealed record DestinyNodeActivationRequirement : IDeepEquatable<DestinyNodeActivationRequirement>
    {
        [JsonPropertyName("exclusiveSetRequiredHash")]
        public uint ExclusiveSetRequiredHash { get; init; }

        /// <summary>
        ///     The Progression level on the Talent Grid required to activate this node.
        ///     <para />
        ///     See DestinyTalentGridDefinition.progressionHash for the related Progression, and read
        ///     DestinyProgressionDefinition's documentation to learn more about Progressions.
        /// </summary>
        [JsonPropertyName("gridLevel")]
        public int GridLevel { get; init; }

        /// <summary>
        ///     The list of hash identifiers for material requirement sets: materials that are required for the node to be
        ///     activated. See DestinyMaterialRequirementSetDefinition for more information about material requirements.
        ///     <para />
        ///     In this case, only a single DestinyMaterialRequirementSetDefinition will be chosen from this list, and we won't
        ///     know which one will be chosen until an instance of the item is created.
        /// </summary>
        [JsonPropertyName("materialRequirementHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyMaterialRequirementSetDefinition>>
            MaterialRequirements
        { get; init; } =
            ReadOnlyCollections<DefinitionHashPointer<DestinyMaterialRequirementSetDefinition>>.Empty;

        public bool DeepEquals(DestinyNodeActivationRequirement other)
        {
            return other != null &&
                   ExclusiveSetRequiredHash == other.ExclusiveSetRequiredHash &&
                   GridLevel == other.GridLevel &&
                   MaterialRequirements.DeepEqualsReadOnlyCollections(other.MaterialRequirements);
        }
    }
}