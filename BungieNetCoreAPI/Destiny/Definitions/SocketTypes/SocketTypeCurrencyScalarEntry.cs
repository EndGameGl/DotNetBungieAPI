using BungieNetCoreAPI.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.SocketTypes
{
    public class SocketTypeCurrencyScalarEntry
    {
        public DefinitionHashPointer<DestinyInventoryItemDefinition> CurrencyItem { get; }
        public int ScalarValue { get; }

        [JsonConstructor]
        private SocketTypeCurrencyScalarEntry(uint currencyItemHash, int scalarValue)
        {
            CurrencyItem = new DefinitionHashPointer<DestinyInventoryItemDefinition>(currencyItemHash, "DestinyInventoryItemDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext);
            ScalarValue = scalarValue;
        }
    }
}
