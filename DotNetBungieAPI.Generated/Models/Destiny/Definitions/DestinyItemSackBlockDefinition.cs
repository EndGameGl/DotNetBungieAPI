namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     Some items are "sacks" - they can be "opened" to produce other items. This is information related to its sack status, mostly UI strings. Engrams are an example of items that are considered to be "Sacks".
/// </summary>
public class DestinyItemSackBlockDefinition
{
    /// <summary>
    ///     A description of what will happen when you open the sack. As far as I can tell, this is blank currently. Unknown whether it will eventually be populated with useful info.
    /// </summary>
    [JsonPropertyName("detailAction")]
    public string DetailAction { get; set; }

    /// <summary>
    ///     The localized name of the action being performed when you open the sack.
    /// </summary>
    [JsonPropertyName("openAction")]
    public string OpenAction { get; set; }

    [JsonPropertyName("selectItemCount")]
    public int SelectItemCount { get; set; }

    [JsonPropertyName("vendorSackType")]
    public string VendorSackType { get; set; }

    [JsonPropertyName("openOnAcquire")]
    public bool OpenOnAcquire { get; set; }
}
