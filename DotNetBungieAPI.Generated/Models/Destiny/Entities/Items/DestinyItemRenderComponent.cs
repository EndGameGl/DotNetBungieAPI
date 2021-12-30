using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Entities.Items;

public sealed class DestinyItemRenderComponent
{

    [JsonPropertyName("useCustomDyes")]
    public bool UseCustomDyes { get; init; }

    [JsonPropertyName("artRegions")]
    public Dictionary<int, int> ArtRegions { get; init; }
}
