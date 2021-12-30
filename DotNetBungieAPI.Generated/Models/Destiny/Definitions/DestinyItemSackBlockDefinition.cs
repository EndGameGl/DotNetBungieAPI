using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyItemSackBlockDefinition
{

    [JsonPropertyName("detailAction")]
    public string DetailAction { get; init; }

    [JsonPropertyName("openAction")]
    public string OpenAction { get; init; }

    [JsonPropertyName("selectItemCount")]
    public int SelectItemCount { get; init; }

    [JsonPropertyName("vendorSackType")]
    public string VendorSackType { get; init; }

    [JsonPropertyName("openOnAcquire")]
    public bool OpenOnAcquire { get; init; }
}
