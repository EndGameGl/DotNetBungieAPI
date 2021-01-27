using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.EnergyTypes
{
    [DestinyDefinition(type: DefinitionsEnum.DestinyEnergyTypeDefinition, presentInSQLiteDB: true, shouldBeLoaded: false)]
    public class DestinyEnergyTypeDefinition : IDestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public uint? CapacityStatHash { get; }
        public uint CostStatHash { get; }
        public DestinyEnergyTypes EnumValue { get; }
        public bool ShowIcon { get; }
        public string TransparentIconPath { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinyEnergyTypeDefinition(DestinyDefinitionDisplayProperties displayProperties, uint? capacityStatHash, uint costStatHash, DestinyEnergyTypes enumValue,
            bool showIcon, string transparentIconPath, bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            CapacityStatHash = capacityStatHash;
            CostStatHash = costStatHash;
            EnumValue = enumValue;
            ShowIcon = showIcon;
            TransparentIconPath = transparentIconPath;
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
