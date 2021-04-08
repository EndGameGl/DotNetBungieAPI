using NetBungieAPI.Models.Destiny.Definitions.SandboxPerks;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Objectives
{
    /// <summary>
    /// Defines the conditions under which an intrinsic perk is applied while participating in an Objective.
    /// <para/>
    /// These perks will generally not be benefit-granting perks, but rather a perk that modifies gameplay in some interesting way.
    /// </summary>
    public class DestinyObjectivePerkEntryDefinition : IDeepEquatable<DestinyObjectivePerkEntryDefinition>
    {
        [JsonPropertyName("perkHash")]
        public DefinitionHashPointer<DestinySandboxPerkDefinition> Perk { get; init; } = DefinitionHashPointer<DestinySandboxPerkDefinition>.Empty;
        [JsonPropertyName("style")]
        public DestinyObjectiveGrantStyle Style { get; init; }

        public bool DeepEquals(DestinyObjectivePerkEntryDefinition other)
        {
            return other != null && Perk.DeepEquals(other.Perk) && Style == other.Style;
        }
    }
}
