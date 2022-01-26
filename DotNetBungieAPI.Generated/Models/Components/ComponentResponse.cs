namespace DotNetBungieAPI.Generated.Models.Components;

/// <summary>
///     The base class for any component-returning object that may need to indicate information about the state of the component being returned.
/// </summary>
public class ComponentResponse : IDeepEquatable<ComponentResponse>
{
    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; set; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }

    public bool DeepEquals(ComponentResponse? other)
    {
        return other is not null &&
               Privacy == other.Privacy &&
               Disabled == other.Disabled;
    }
}