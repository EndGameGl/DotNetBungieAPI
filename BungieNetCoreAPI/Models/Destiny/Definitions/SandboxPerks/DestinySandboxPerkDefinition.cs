using NetBungieAPI.Attributes;
using NetBungieAPI.Models.Destiny.Definitions.Common;
using NetBungieAPI.Models.Destiny.Definitions.DamageTypes;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.SandboxPerks
{
    [DestinyDefinition(DefinitionsEnum.DestinySandboxPerkDefinition)]
    public sealed record DestinySandboxPerkDefinition : IDestinyDefinition, IDeepEquatable<DestinySandboxPerkDefinition>
    {
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }
        [JsonPropertyName("perkIdentifier")]
        public string PerkIdentifier { get; init; }
        [JsonPropertyName("isDisplayable")]
        public bool IsDisplayable { get; init; }
        [JsonPropertyName("damageType")]
        public DamageType DamageTypeEnumValue { get; init; }
        [JsonPropertyName("damageTypeHash")]
        public DefinitionHashPointer<DestinyDamageTypeDefinition> DamageType { get; init; }
        [JsonPropertyName("perkGroups")]
        public TalentNodeStepGroups PerkGroups { get; init; }
        [JsonPropertyName("blacklisted")]
        public bool Blacklisted { get; init; }
        [JsonPropertyName("hash")]
        public uint Hash { get; init; }
        [JsonPropertyName("index")]
        public int Index { get; init; }
        [JsonPropertyName("redacted")]
        public bool Redacted { get; init; }

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
