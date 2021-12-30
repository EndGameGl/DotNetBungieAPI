using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Inventory;

public sealed class DestinyCurrenciesComponent
{

    [JsonPropertyName("itemQuantities")]
    public Dictionary<uint, int> ItemQuantities { get; init; }
}
