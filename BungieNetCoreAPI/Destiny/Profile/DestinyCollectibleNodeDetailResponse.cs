using NetBungieAPI.Destiny.Profile.Components.Contracts;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Profile
{
    public class DestinyCollectibleNodeDetailResponse
    {
        private DestinyProfileComponent<DestinyCollectiblesComponent> _collectibles;
        private DestinyItemSetComponent _collectibleItemComponents;

        [JsonConstructor]
        internal DestinyCollectibleNodeDetailResponse(
            DestinyProfileComponent<DestinyCollectiblesComponent> collectibles,
            DestinyItemSetComponent collectibleItemComponents)
        {
            _collectibles = collectibles;
            _collectibleItemComponents = collectibleItemComponents;
        }

        public bool TryGetCollectibles(out DestinyProfileComponent<DestinyCollectiblesComponent> data)
        {
            data = _collectibles;
            return data != null;
        }
        public bool TryGetCollectibleItemComponents(out DestinyItemSetComponent data)
        {
            data = _collectibleItemComponents;
            return data != null;
        }
    }
}
