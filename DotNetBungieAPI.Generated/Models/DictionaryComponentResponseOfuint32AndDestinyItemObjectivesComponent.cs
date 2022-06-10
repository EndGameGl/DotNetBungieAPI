namespace DotNetBungieAPI.Generated.Models;

public class DictionaryComponentResponseOfuint32AndDestinyItemObjectivesComponent
{
    [JsonPropertyName("data")]
    public Dictionary<uint, Destiny.Entities.Items.DestinyItemObjectivesComponent> Data { get; set; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting? Privacy { get; set; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }
}
