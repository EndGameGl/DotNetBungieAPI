namespace DotNetBungieAPI.Models.User;

/// <summary>
///     Represents a data-driven view for Email settings. Web/Mobile UI can use this data to show new EMail settings consistently without further manual work.
/// </summary>
public sealed class EmailViewDefinition
{
    /// <summary>
    ///     The identifier for this view.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; init; }

    /// <summary>
    ///     The ordered list of settings to show in this view.
    /// </summary>
    [JsonPropertyName("viewSettings")]
    public User.EmailViewDefinitionSetting[]? ViewSettings { get; init; }
}
