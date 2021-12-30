using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models;

public sealed class DictionaryComponentResponseOfint64AndDestinyItemRenderComponent
{

    [JsonPropertyName("data")]
    public Dictionary<long, Destiny.Entities.Items.DestinyItemRenderComponent> Data { get; init; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; init; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; init; }
}
