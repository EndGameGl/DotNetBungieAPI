using NetBungieAPI.Attributes;
using NetBungieAPI.Destiny.Definitions.DamageTypes;
using Newtonsoft.Json;

namespace NetBungieAPI.Models.Destiny.Definitions.SandboxPerks
{
    [DestinyDefinition(DefinitionsEnum.DestinySandboxPerkDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinySandboxPerkDefinition : IDestinyDefinition, IDeepEquatable<DestinySandboxPerkDefinition>
    {
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }
        public DamageType DamageTypeEnumValue { get; init; }
        public DefinitionHashPointer<DestinyDamageTypeDefinition> DamageType { get; init; }
        public bool IsDisplayable { get; init; }
        public string PerkIdentifier { get; init; }
        public TalentNodeStepGroups PerkGroups { get; init; }
        public bool Blacklisted { get; init; }
        public uint Hash { get; init; }
        public int Index { get; init; }
        public bool Redacted { get; init; }

        [JsonConstructor]
        internal DestinySandboxPerkDefinition(DestinyDisplayPropertiesDefinition displayProperties, DamageType damageType, bool isDisplayable, uint damageTypeHash,
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
