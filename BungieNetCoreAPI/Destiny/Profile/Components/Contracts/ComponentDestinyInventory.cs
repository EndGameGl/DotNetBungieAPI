using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class ComponentDestinyInventory
    {
        public ReadOnlyCollection<DestinyItemComponent> Items { get; }

        [JsonConstructor]
        internal ComponentDestinyInventory(DestinyItemComponent[] items)
        {
            Items = items.AsReadOnlyOrEmpty();
        }
    }
}
