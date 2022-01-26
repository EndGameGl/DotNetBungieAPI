namespace DotNetBungieAPI.Generated.Models;

public class SingleComponentResponseOfDestinyStringVariablesComponent : IDeepEquatable<SingleComponentResponseOfDestinyStringVariablesComponent>
{
    [JsonPropertyName("data")]
    public Destiny.Components.StringVariables.DestinyStringVariablesComponent Data { get; set; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; set; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }

    public bool DeepEquals(SingleComponentResponseOfDestinyStringVariablesComponent? other)
    {
        return other is not null &&
               (Data is not null ? Data.DeepEquals(other.Data) : other.Data is null) &&
               Privacy == other.Privacy &&
               Disabled == other.Disabled;
    }
}