﻿using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieApi.Destiny.Profile.Components.Contracts
{
    public class DestinyInventoryComponent
    {
        public ReadOnlyCollection<DestinyItemComponent> Items { get; }

        [JsonConstructor]
        internal DestinyInventoryComponent(DestinyItemComponent[] items)
        {
            Items = items.AsReadOnlyOrEmpty();
        }
    }
}
