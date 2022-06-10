namespace DotNetBungieAPI.Generated.Models;

public class DictionaryComponentResponseOfint64AndDestinyItemPerksComponent
{
    [JsonPropertyName("data")]
    public Dictionary<long, Destiny.Entities.Items.DestinyItemPerksComponent> Data { get; set; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting? Privacy { get; set; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }
}
