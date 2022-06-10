namespace DotNetBungieAPI.Generated.Models;

public class DictionaryComponentResponseOfint64AndDestinyItemSocketsComponent
{
    [JsonPropertyName("data")]
    public Dictionary<long, Destiny.Entities.Items.DestinyItemSocketsComponent> Data { get; set; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting? Privacy { get; set; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }
}
