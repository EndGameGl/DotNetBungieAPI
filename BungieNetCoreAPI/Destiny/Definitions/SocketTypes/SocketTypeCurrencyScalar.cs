using NetBungieAPI.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.SocketTypes
{
    public class SocketTypeCurrencyScalar : IDeepEquatable<SocketTypeCurrencyScalar>
    {
        public DefinitionHashPointer<DestinyInventoryItemDefinition> CurrencyItem { get; }
        public int ScalarValue { get; }

        [JsonConstructor]
        internal SocketTypeCurrencyScalar(uint currencyItemHash, int scalarValue)
        {
            CurrencyItem = new DefinitionHashPointer<DestinyInventoryItemDefinition>(currencyItemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            ScalarValue = scalarValue;
        }

        public bool DeepEquals(SocketTypeCurrencyScalar other)
        {
            return other != null &&
                   CurrencyItem.DeepEquals(other.CurrencyItem) &&
                   ScalarValue == other.ScalarValue;
        }  
    }
}
