using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyCharacterRenderComponent
    {
        public ReadOnlyCollection<DyeReference> CustomDyes { get; }
        public DestinyCharacterCustomization Customization { get; }
        public DestinyCharacterPeerView PeerView { get; }

        [JsonConstructor]
        internal DestinyCharacterRenderComponent(DyeReference[] customDyes, DestinyCharacterCustomization customization, DestinyCharacterPeerView peerView)
        {
            CustomDyes = customDyes.AsReadOnlyOrEmpty();
            Customization = customization;
            PeerView = peerView;
        }
    }
}
