using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Entities.Characters;

public sealed class DestinyCharacterRenderComponent
{

    [JsonPropertyName("customDyes")]
    public List<Destiny.DyeReference> CustomDyes { get; init; }

    [JsonPropertyName("customization")]
    public Destiny.Character.DestinyCharacterCustomization Customization { get; init; }

    [JsonPropertyName("peerView")]
    public Destiny.Character.DestinyCharacterPeerView PeerView { get; init; }
}
