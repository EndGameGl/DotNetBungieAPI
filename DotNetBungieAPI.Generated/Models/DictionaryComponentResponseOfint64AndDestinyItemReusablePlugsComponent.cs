namespace DotNetBungieAPI.Generated.Models;

public class DictionaryComponentResponseOfint64AndDestinyItemReusablePlugsComponent : IDeepEquatable<DictionaryComponentResponseOfint64AndDestinyItemReusablePlugsComponent>
{
    [JsonPropertyName("data")]
    public Dictionary<long, Destiny.Components.Items.DestinyItemReusablePlugsComponent> Data { get; set; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; set; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }

    public bool DeepEquals(DictionaryComponentResponseOfint64AndDestinyItemReusablePlugsComponent? other)
    {
        return other is not null &&
               Data.DeepEqualsDictionary(other.Data) &&
               Privacy == other.Privacy &&
               Disabled == other.Disabled;
    }
}