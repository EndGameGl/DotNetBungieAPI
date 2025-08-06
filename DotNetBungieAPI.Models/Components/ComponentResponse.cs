namespace DotNetBungieAPI.Models.Components;

/// <summary>
///     The base class for any component-returning object that may need to indicate information about the state of the component being returned.
/// </summary>
public sealed class ComponentResponse
{
    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; init; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; init; }
}
