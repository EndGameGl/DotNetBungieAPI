using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Kiosks;

public sealed class DestinyKiosksComponent
{

    [JsonPropertyName("kioskItems")]
    public Dictionary<uint, List<Destiny.Components.Kiosks.DestinyKioskItem>> KioskItems { get; init; }
}
