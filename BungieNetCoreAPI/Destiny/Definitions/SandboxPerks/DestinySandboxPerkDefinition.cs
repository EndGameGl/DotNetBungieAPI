using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.DamageTypes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.SandboxPerks
{
    [DestinyDefinition(type: DefinitionsEnum.DestinySandboxPerkDefinition, presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinySandboxPerkDefinition : IDestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public DamageType DamageTypeEnumValue { get; }
        public DefinitionHashPointer<DestinyDamageTypeDefinition> DamageType { get; }
        public bool IsDisplayable { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinySandboxPerkDefinition(DestinyDefinitionDisplayProperties displayProperties, DamageType damageType, bool isDisplayable, uint damageTypeHash,
            bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            DamageTypeEnumValue = damageType;
            DamageType = new DefinitionHashPointer<DestinyDamageTypeDefinition>(damageTypeHash, DefinitionsEnum.DestinyDamageTypeDefinition);
            IsDisplayable = isDisplayable;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
