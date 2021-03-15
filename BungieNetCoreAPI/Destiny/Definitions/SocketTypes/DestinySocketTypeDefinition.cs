using NetBungieAPI.Attributes;
using NetBungieAPI.Destiny.Definitions.SocketCategories;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.SocketTypes
{
    [DestinyDefinition(DefinitionsEnum.DestinySocketTypeDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinySocketTypeDefinition : IDestinyDefinition, IDeepEquatable<DestinySocketTypeDefinition>
    {
        public bool AlwaysRandomizeSockets { get; }
        public bool AvoidDuplicatesOnInitialization { get; }
        public bool HideDuplicateReusablePlugs { get; }
        public bool IsPreviewEnabled { get; }
        public bool OverridesUiAppearance { get; }
        public DefinitionHashPointer<DestinySocketCategoryDefinition> SocketCategory { get; }
        public SocketVisibility Visibility { get; }
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public SocketTypeInsertAction InsertAction { get; }
        public ReadOnlyCollection<SocketTypeCurrencyScalar> CurrencyScalars { get; }
        public ReadOnlyCollection<SocketTypePlugWhitelist> PlugWhitelist { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinySocketTypeDefinition(bool alwaysRandomizeSockets, bool avoidDuplicatesOnInitialization, bool hideDuplicateReusablePlugs, bool isPreviewEnabled,
            bool overridesUiAppearance, uint socketCategoryHash, SocketVisibility visibility, SocketTypeInsertAction insertAction, SocketTypeCurrencyScalar[] currencyScalars,
            SocketTypePlugWhitelist[] plugWhitelist, DestinyDefinitionDisplayProperties displayProperties, bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            AlwaysRandomizeSockets = alwaysRandomizeSockets;
            AvoidDuplicatesOnInitialization = avoidDuplicatesOnInitialization;
            HideDuplicateReusablePlugs = hideDuplicateReusablePlugs;
            IsPreviewEnabled = isPreviewEnabled;
            OverridesUiAppearance = overridesUiAppearance;
            SocketCategory = new DefinitionHashPointer<DestinySocketCategoryDefinition>(socketCategoryHash, DefinitionsEnum.DestinySocketCategoryDefinition);
            Visibility = visibility;
            InsertAction = insertAction;
            CurrencyScalars = currencyScalars.AsReadOnlyOrEmpty();
            PlugWhitelist = plugWhitelist.AsReadOnlyOrEmpty();
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

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
