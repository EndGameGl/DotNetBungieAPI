using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.EntitlementOffers
{
    [DestinyDefinition(name: "DestinyEntitlementOfferDefinition", presentInSQLiteDB: false, shouldBeLoaded: true)]
    public class DestinyEntitlementOfferDefinition : IDestinyDefinition
    {
        public uint OfferKey { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinyEntitlementOfferDefinition(uint offerKey, bool blacklisted, uint hash, int index, bool redacted)
        {
            OfferKey = offerKey; 
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }
    }
}
