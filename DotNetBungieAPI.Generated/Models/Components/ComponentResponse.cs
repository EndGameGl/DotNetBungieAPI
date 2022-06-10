namespace DotNetBungieAPI.Generated.Models.Components;

/// <summary>
///     The base class for any component-returning object that may need to indicate information about the state of the component being returned.
/// </summary>
public class ComponentResponse
{
    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; set; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool Disabled { get; set; }
}
