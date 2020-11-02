using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.EntitlementOffers
{
    public class DestinyEntitlementOfferDefinition : DestinyDefinition
    {
        public uint OfferKey { get; }

        [JsonConstructor]
        private DestinyEntitlementOfferDefinition(uint offerKey, bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            OfferKey = offerKey;
        }
    }
}
