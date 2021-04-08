using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyItemReusablePlugsComponent
    {
        public ReadOnlyDictionary<int, ReadOnlyCollection<PlugItemSettings>> Plugs { get; init; }

        [JsonConstructor]
        internal DestinyItemReusablePlugsComponent(Dictionary<int, PlugItemSettings[]> plugs)
        {
            Plugs = plugs?.ToDictionary(x => x.Key, x => x.Value.AsReadOnlyOrEmpty()).AsReadOnlyDictionaryOrEmpty();
        }
    }
}
