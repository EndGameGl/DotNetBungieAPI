using NetBungieAPI.Attributes;
using NetBungieAPI.Models.Destiny.Definitions.Common;
using NetBungieAPI.Models.Destiny.Definitions.SocketCategories;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.SocketTypes
{
    [DestinyDefinition(DefinitionsEnum.DestinySocketTypeDefinition)]
    public sealed record DestinySocketTypeDefinition : IDestinyDefinition, IDeepEquatable<DestinySocketTypeDefinition>
    {
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }
        [JsonPropertyName("insertAction")]
        public DestinyInsertPlugActionDefinition InsertAction { get; init; }
        [JsonPropertyName("plugWhitelist")]
        public ReadOnlyCollection<DestinyPlugWhitelistEntryDefinition> PlugWhitelist { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyPlugWhitelistEntryDefinition>();
        [JsonPropertyName("socketCategoryHash")]
        public DefinitionHashPointer<DestinySocketCategoryDefinition> SocketCategory { get; init; } = DefinitionHashPointer<DestinySocketCategoryDefinition>.Empty;
        [JsonPropertyName("visibility")]
        public DestinySocketVisibility Visibility { get; init; }
        [JsonPropertyName("alwaysRandomizeSockets")]
        public bool AlwaysRandomizeSockets { get; init; }
        [JsonPropertyName("isPreviewEnabled")]
        public bool IsPreviewEnabled { get; init; }
        [JsonPropertyName("hideDuplicateReusablePlugs")]
        public bool HideDuplicateReusablePlugs { get; init; }
        [JsonPropertyName("overridesUiAppearance")]
        public bool OverridesUiAppearance { get; init; }
        [JsonPropertyName("avoidDuplicatesOnInitialization")]
        public bool AvoidDuplicatesOnInitialization { get; init; }
        [JsonPropertyName("currencyScalars")]
        public ReadOnlyCollection<DestinySocketTypeScalarMaterialRequirementEntry> CurrencyScalars { get; init; } = Defaults.EmptyReadOnlyCollection<DestinySocketTypeScalarMaterialRequirementEntry>();
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
        public void MapValues()
        {
            SocketCategory.TryMapValue();
            foreach (var scalar in CurrencyScalars)
            {
                scalar.CurrencyItem.TryMapValue();
            }
            foreach (var plugList in PlugWhitelist)
            {
                foreach (var plug in plugList.ReinitializationPossiblePlugs)
                {
                    plug.TryMapValue();
                }
            }
        }
        public bool DeepEquals(DestinySocketTypeDefinition other)
        {
            return other != null &&
                   AlwaysRandomizeSockets == other.AlwaysRandomizeSockets &&
                   AvoidDuplicatesOnInitialization == other.AvoidDuplicatesOnInitialization &&
                   HideDuplicateReusablePlugs == other.HideDuplicateReusablePlugs &&
                   IsPreviewEnabled == other.IsPreviewEnabled &&
                   OverridesUiAppearance == other.OverridesUiAppearance &&
                   SocketCategory.DeepEquals(other.SocketCategory) &&
                   Visibility == other.Visibility &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   InsertAction.DeepEquals(other.InsertAction) &&
                   CurrencyScalars.DeepEqualsReadOnlyCollections(other.CurrencyScalars) &&
                   PlugWhitelist.DeepEqualsReadOnlyCollections(other.PlugWhitelist) &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
    }
}
