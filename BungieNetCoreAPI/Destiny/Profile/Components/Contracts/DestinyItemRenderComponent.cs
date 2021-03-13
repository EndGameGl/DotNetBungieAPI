using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieApi.Destiny.Profile.Components.Contracts
{
    public class DestinyItemRenderComponent
    {
        public bool UseCustomDyes { get; }
        public ReadOnlyDictionary<int, int> ArtRegions { get; }

        [JsonConstructor]
        internal DestinyItemRenderComponent(bool useCustomDyes, Dictionary<int, int> artRegions)
        {
            UseCustomDyes = useCustomDyes;
            ArtRegions = artRegions.AsReadOnlyDictionaryOrEmpty();
        }
    }
}
