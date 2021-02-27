using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class ComponentDestinyItemRender
    {
        public bool UseCustomDyes { get; }
        public ReadOnlyDictionary<int, int> ArtRegions { get; }

        [JsonConstructor]
        internal ComponentDestinyItemRender(bool useCustomDyes, Dictionary<int, int> artRegions)
        {
            UseCustomDyes = useCustomDyes;
            ArtRegions = artRegions.AsReadOnlyDictionaryOrEmpty();
        }
    }
}
