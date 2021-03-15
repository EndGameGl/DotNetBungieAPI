using NetBungieAPI.Destiny.Definitions.SandboxPerks;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.Objectives
{
    /// <summary>
    /// Defines the conditions under which an intrinsic perk is applied while participating in an Objective.
    /// <para/>
    /// These perks will generally not be benefit-granting perks, but rather a perk that modifies gameplay in some interesting way.
    /// </summary>
    public class ObjectivePerks : IDeepEquatable<ObjectivePerks>
    {
        public DefinitionHashPointer<DestinySandboxPerkDefinition> Perk { get; }
        public ObjectivePerksStyle Style { get; }

        [JsonConstructor]
        internal ObjectivePerks(uint perkHash, ObjectivePerksStyle style)
        {
            Perk = new DefinitionHashPointer<DestinySandboxPerkDefinition>(perkHash, DefinitionsEnum.DestinySandboxPerkDefinition);
            Style = style;
        }

        public bool DeepEquals(ObjectivePerks other)
        {
            return other != null && Perk.DeepEquals(other.Perk) && Style == other.Style;
        }
    }
}
