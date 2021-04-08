using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyInventoryComponent
    {
        public ReadOnlyCollection<DestinyItemComponent> Items { get; init; }

        [JsonConstructor]
        internal DestinyInventoryComponent(DestinyItemComponent[] items)
        {
            Items = items.AsReadOnlyOrEmpty();
        }
    }
}
