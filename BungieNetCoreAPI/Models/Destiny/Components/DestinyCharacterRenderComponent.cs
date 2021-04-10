using NetBungieAPI.Models.Destiny.Character;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyCharacterRenderComponent
    {
        [JsonPropertyName("customDyes")]
        public ReadOnlyCollection<DyeReference> CustomDyes { get; init; } = Defaults.EmptyReadOnlyCollection<DyeReference>();
        [JsonPropertyName("customization")]
        public DestinyCharacterCustomization Customization { get; init; }
        [JsonPropertyName("peerView")]
        public DestinyCharacterPeerView PeerView { get; init; }
    }
}
