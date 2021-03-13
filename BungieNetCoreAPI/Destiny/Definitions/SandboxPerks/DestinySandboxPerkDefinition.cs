using NetBungieApi.Attributes;
using NetBungieApi.Destiny.Definitions.DamageTypes;
using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Definitions.SandboxPerks
{
    [DestinyDefinition(DefinitionsEnum.DestinySandboxPerkDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinySandboxPerkDefinition : IDestinyDefinition, IDeepEquatable<DestinySandboxPerkDefinition>
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public DamageType DamageTypeEnumValue { get; }
        public DefinitionHashPointer<DestinyDamageTypeDefinition> DamageType { get; }
        public bool IsDisplayable { get; }
        public string PerkIdentifier { get; }
        public TalentNodeStepGroups PerkGroups { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinySandboxPerkDefinition(DestinyDefinitionDisplayProperties displayProperties, DamageType damageType, bool isDisplayable, uint damageTypeHash,
            string perkIdentifier, TalentNodeStepGroups perkGroups, bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            DamageTypeEnumValue = damageType;
            DamageType = new DefinitionHashPointer<DestinyDamageTypeDefinition>(damageTypeHash, DefinitionsEnum.DestinyDamageTypeDefinition);
            IsDisplayable = isDisplayable;
            PerkIdentifier = perkIdentifier;
            PerkGroups = perkGroups;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }

        public bool DeepEquals(DestinySandboxPerkDefinition other)
        {
            return other != null &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   DamageTypeEnumValue == other.DamageTypeEnumValue &&
                   DamageType.DeepEquals(other.DamageType) &&
                   IsDisplayable == other.IsDisplayable &&
                   PerkIdentifier == other.PerkIdentifier &&
                   PerkGroups.DeepEquals(other.PerkGroups) &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
        public void MapValues()
        {
            DamageType.TryMapValue();
        }
    }
}
