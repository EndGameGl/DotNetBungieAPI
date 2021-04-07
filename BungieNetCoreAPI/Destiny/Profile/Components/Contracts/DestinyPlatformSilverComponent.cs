using NetBungieAPI.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyPlatformSilverComponent
    {
        public ReadOnlyDictionary<BungieMembershipType, DestinyItemComponent> PlatformSilver { get; }

        [JsonConstructor]
        internal DestinyPlatformSilverComponent(Dictionary<BungieMembershipType, DestinyItemComponent> platformSilver)
        {
            PlatformSilver = platformSilver.AsReadOnlyDictionaryOrEmpty();
        }
    }
}
