namespace DotNetBungieAPI.Generated.Models;

public class DictionaryComponentResponseOfuint32AndDestinyItemReusablePlugsComponent : IDeepEquatable<DictionaryComponentResponseOfuint32AndDestinyItemReusablePlugsComponent>
{
    [JsonPropertyName("data")]
    public Dictionary<uint, Destiny.Components.Items.DestinyItemReusablePlugsComponent> Data { get; set; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; set; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }

    public bool DeepEquals(DictionaryComponentResponseOfuint32AndDestinyItemReusablePlugsComponent? other)
    {
        return other is not null &&
               Data.DeepEqualsDictionary(other.Data) &&
               Privacy == other.Privacy &&
               Disabled == other.Disabled;
    }
}