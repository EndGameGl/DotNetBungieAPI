using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     Talent nodes have requirements that must be met before they can be activated.
/// <para />
///     This describes the material costs, the Level of the Talent Grid's progression required, and other conditional information that limits whether a talent node can be activated.
/// </summary>
public sealed class DestinyNodeActivationRequirement
{

    /// <summary>
    ///     The Progression level on the Talent Grid required to activate this node.
    /// <para />
    ///     See DestinyTalentGridDefinition.progressionHash for the related Progression, and read DestinyProgressionDefinition's documentation to learn more about Progressions.
    /// </summary>
    [JsonPropertyName("gridLevel")]
    public int GridLevel { get; init; }

    /// <summary>
    ///     The list of hash identifiers for material requirement sets: materials that are required for the node to be activated. See DestinyMaterialRequirementSetDefinition for more information about material requirements.
    /// <para />
    ///     In this case, only a single DestinyMaterialRequirementSetDefinition will be chosen from this list, and we won't know which one will be chosen until an instance of the item is created.
    /// </summary>
    [JsonPropertyName("materialRequirementHashes")]
    public List<uint> MaterialRequirementHashes { get; init; }
}
