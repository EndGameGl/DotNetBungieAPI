using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyVendorActionDefinition
{

    [JsonPropertyName("description")]
    public string Description { get; init; }

    [JsonPropertyName("executeSeconds")]
    public int ExecuteSeconds { get; init; }

    [JsonPropertyName("icon")]
    public string Icon { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("verb")]
    public string Verb { get; init; }

    [JsonPropertyName("isPositive")]
    public bool IsPositive { get; init; }

    [JsonPropertyName("actionId")]
    public string ActionId { get; init; }

    [JsonPropertyName("actionHash")]
    public uint ActionHash { get; init; }

    [JsonPropertyName("autoPerformAction")]
    public bool AutoPerformAction { get; init; }
}
