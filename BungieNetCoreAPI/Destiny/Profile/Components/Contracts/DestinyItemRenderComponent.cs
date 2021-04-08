using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyItemRenderComponent
    {
        public bool UseCustomDyes { get; init; }
        public ReadOnlyDictionary<int, int> ArtRegions { get; init; }

        [JsonConstructor]
        internal DestinyItemRenderComponent(bool useCustomDyes, Dictionary<int, int> artRegions)
        {
            UseCustomDyes = useCustomDyes;
            ArtRegions = artRegions.AsReadOnlyDictionaryOrEmpty();
        }
    }
}
