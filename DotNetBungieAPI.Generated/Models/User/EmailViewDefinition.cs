namespace DotNetBungieAPI.Generated.Models.User;

/// <summary>
///     Represents a data-driven view for Email settings. Web/Mobile UI can use this data to show new EMail settings consistently without further manual work.
/// </summary>
public class EmailViewDefinition
{
    /// <summary>
    ///     The identifier for this view.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    ///     The ordered list of settings to show in this view.
    /// </summary>
    [JsonPropertyName("viewSettings")]
    public List<User.EmailViewDefinitionSetting> ViewSettings { get; set; }
}
