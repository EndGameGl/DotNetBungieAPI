using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyCharacterRenderComponent
    {
        public ReadOnlyCollection<DyeReference> CustomDyes { get; init; }
        public DestinyCharacterCustomization Customization { get; init; }
        public DestinyCharacterPeerView PeerView { get; init; }

        [JsonConstructor]
        internal DestinyCharacterRenderComponent(DyeReference[] customDyes, DestinyCharacterCustomization customization, DestinyCharacterPeerView peerView)
        {
            CustomDyes = customDyes.AsReadOnlyOrEmpty();
            Customization = customization;
            PeerView = peerView;
        }
    }
}
