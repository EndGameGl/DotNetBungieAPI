using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.DamageTypes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.SandboxPerks
{
    [DestinyDefinition(name: "DestinySandboxPerkDefinition", presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinySandboxPerkDefinition : DestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public DamageType DamageTypeEnumValue { get; }
        public DefinitionHashPointer<DestinyDamageTypeDefinition> DamageType { get; }
        public bool IsDisplayable { get; }

        [JsonConstructor]
        private DestinySandboxPerkDefinition(DestinyDefinitionDisplayProperties displayProperties, DamageType damageType, bool isDisplayable, uint damageTypeHash,
            bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            DisplayProperties = displayProperties;
            DamageTypeEnumValue = damageType;
            DamageType = new DefinitionHashPointer<DestinyDamageTypeDefinition>(damageTypeHash, "DestinyDamageTypeDefinition");
            IsDisplayable = isDisplayable;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
