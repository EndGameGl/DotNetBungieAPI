using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Character
{
    public class DestinyCharacterPeerView
    {
        [JsonPropertyName("equipment")]
        public ReadOnlyCollection<DestinyItemPeerView> Equipment { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyItemPeerView>();
    }
}
