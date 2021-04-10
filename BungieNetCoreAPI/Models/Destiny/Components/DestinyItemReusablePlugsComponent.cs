using NetBungieAPI.Models.Destiny.Items;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyItemReusablePlugsComponent
    {
        [JsonPropertyName("plugs")]
        public ReadOnlyDictionary<int, ReadOnlyCollection<PlugItemSettings>> Plugs { get; init; } = Defaults.EmptyReadOnlyDictionary<int, ReadOnlyCollection<PlugItemSettings>>();
    }
}
