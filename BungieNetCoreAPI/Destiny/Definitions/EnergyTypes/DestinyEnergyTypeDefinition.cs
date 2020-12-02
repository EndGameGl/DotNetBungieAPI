using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.EnergyTypes
{
    [DestinyDefinition("DestinyEnergyTypeDefinition")]
    public class DestinyEnergyTypeDefinition : DestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public uint? CapacityStatHash { get; }
        public uint CostStatHash { get; }
        public DestinyEnergyTypes EnumValue { get; }
        public bool ShowIcon { get; }
        public string TransparentIconPath { get; }

        [JsonConstructor]
        private DestinyEnergyTypeDefinition(DestinyDefinitionDisplayProperties displayProperties, uint? capacityStatHash, uint costStatHash, DestinyEnergyTypes enumValue,
            bool showIcon, string transparentIconPath,
            bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            DisplayProperties = displayProperties;
            CapacityStatHash = capacityStatHash;
            CostStatHash = costStatHash;
            EnumValue = enumValue;
            ShowIcon = showIcon;
            TransparentIconPath = transparentIconPath;
        }
        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
