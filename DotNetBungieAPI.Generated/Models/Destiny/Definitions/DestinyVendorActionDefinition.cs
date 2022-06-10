namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     If a vendor can ever end up performing actions, these are the properties that will be related to those actions. I'm not going to bother documenting this yet, as it is unused and unclear if it will ever be used... but in case it is ever populated and someone finds it useful, it is defined here.
/// </summary>
public class DestinyVendorActionDefinition
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("executeSeconds")]
    public int? ExecuteSeconds { get; set; }

    [JsonPropertyName("icon")]
    public string? Icon { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("verb")]
    public string? Verb { get; set; }

    [JsonPropertyName("isPositive")]
    public bool? IsPositive { get; set; }

    [JsonPropertyName("actionId")]
    public string? ActionId { get; set; }

    [JsonPropertyName("actionHash")]
    public uint? ActionHash { get; set; }

    [JsonPropertyName("autoPerformAction")]
    public bool? AutoPerformAction { get; set; }
}
