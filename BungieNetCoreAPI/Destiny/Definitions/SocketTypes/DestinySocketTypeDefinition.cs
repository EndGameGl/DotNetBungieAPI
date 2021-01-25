using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.SocketCategories;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.SocketTypes
{
    [DestinyDefinition(name: "DestinySocketTypeDefinition", presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinySocketTypeDefinition : IDestinyDefinition
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
        public List<SocketTypeCurrencyScalarEntry> CurrencyScalars { get; }
        public List<SocketTypePlugWhitelistEntry> PlugWhitelist { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinySocketTypeDefinition(bool alwaysRandomizeSockets, bool avoidDuplicatesOnInitialization, bool hideDuplicateReusablePlugs, bool isPreviewEnabled,
            bool overridesUiAppearance, uint socketCategoryHash, SocketVisibility visibility, SocketTypeInsertAction insertAction, List<SocketTypeCurrencyScalarEntry> currencyScalars,
            List<SocketTypePlugWhitelistEntry> plugWhitelist, DestinyDefinitionDisplayProperties displayProperties, bool blacklisted, uint hash, int index, bool redacted)
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
            CurrencyScalars = currencyScalars;
            PlugWhitelist = plugWhitelist;
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
