namespace DotNetBungieAPI.Models;

public sealed class DictionaryComponentResponseOfint64AndDestinyItemReusablePlugsComponent
{
    [JsonPropertyName("data")]
    public Dictionary<long, Destiny.Components.Items.DestinyItemReusablePlugsComponent>? Data { get; init; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; init; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; init; }
}
