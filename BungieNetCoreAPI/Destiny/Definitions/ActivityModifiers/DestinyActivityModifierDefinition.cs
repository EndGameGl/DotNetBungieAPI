using NetBungieApi.Attributes;
using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Definitions.ActivityModifiers
{
    /// <summary>
    /// Modifiers - in Destiny 1, these were referred to as "Skulls" - are changes that can be applied to an Activity.
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyActivityModifierDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyActivityModifierDefinition : IDestinyDefinition, IDeepEquatable<DestinyActivityModifierDefinition>
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyActivityModifierDefinition(DestinyDefinitionDisplayProperties displayProperties, bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
        public bool DeepEquals(DestinyActivityModifierDefinition other)
        {
            return other != null &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
        public void MapValues()
        {
            return;
        }
    }
}
