using NetBungieAPI.Attributes;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.EntitlementOffers
{
    [DestinyDefinition(DefinitionsEnum.DestinyEntitlementOfferDefinition, DefinitionSources.BungieNet | DefinitionSources.JSON, DefinitionKeyType.UInt)]
    public class DestinyEntitlementOfferDefinition : IDestinyDefinition, IDeepEquatable<DestinyEntitlementOfferDefinition>
    {
        public uint OfferKey { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyEntitlementOfferDefinition(uint offerKey, bool blacklisted, uint hash, int index, bool redacted)
        {
            OfferKey = offerKey; 
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public bool DeepEquals(DestinyEntitlementOfferDefinition other)
        {
            return other != null &&
                   OfferKey == other.OfferKey &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
        public void MapValues()
        {
            return;
        }
    }
}
