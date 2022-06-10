namespace DotNetBungieAPI.Generated.Models;

public class DictionaryComponentResponseOfint32AndDestinyItemReusablePlugsComponent
{
    [JsonPropertyName("data")]
    public Dictionary<int, Destiny.Components.Items.DestinyItemReusablePlugsComponent> Data { get; set; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting? Privacy { get; set; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }
}
