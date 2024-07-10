namespace DotNetBungieAPI.Generated.Models.Applications;

public class Application
{
    [JsonPropertyName("applicationType")]
    public Applications.OAuthApplicationType? ApplicationType { get; set; }

    /// <summary>
    ///     Unique ID assigned to the application
    /// </summary>
    [JsonPropertyName("applicationId")]
    public int? ApplicationId { get; set; }

    /// <summary>
    ///     Name of the application
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    ///     URL used to pass the user's authorization code to the application
    /// </summary>
    [JsonPropertyName("redirectUrl")]
    public string? RedirectUrl { get; set; }

    /// <summary>
    ///     Link to website for the application where a user can learn more about the app.
    /// </summary>
    [JsonPropertyName("link")]
    public string? Link { get; set; }

    /// <summary>
    ///     Permissions the application needs to work
    /// </summary>
    [JsonPropertyName("scope")]
    public long? Scope { get; set; }

    /// <summary>
    ///     Value of the Origin header sent in requests generated by this application.
    /// </summary>
    [JsonPropertyName("origin")]
    public string? Origin { get; set; }

    /// <summary>
    ///     Current status of the application.
    /// </summary>
    [JsonPropertyName("status")]
    public Applications.ApplicationStatus? Status { get; set; }

    /// <summary>
    ///     Date the application was first added to our database.
    /// </summary>
    [JsonPropertyName("creationDate")]
    public DateTime? CreationDate { get; set; }

    /// <summary>
    ///     Date the application status last changed.
    /// </summary>
    [JsonPropertyName("statusChanged")]
    public DateTime? StatusChanged { get; set; }

    /// <summary>
    ///     Date the first time the application status entered the 'Public' status.
    /// </summary>
    [JsonPropertyName("firstPublished")]
    public DateTime? FirstPublished { get; set; }

    /// <summary>
    ///     List of team members who manage this application on Bungie.net. Will always consist of at least the application owner.
    /// </summary>
    [JsonPropertyName("team")]
    public List<Applications.ApplicationDeveloper> Team { get; set; }

    /// <summary>
    ///     An optional override for the Authorize view name.
    /// </summary>
    [JsonPropertyName("overrideAuthorizeViewName")]
    public string? OverrideAuthorizeViewName { get; set; }
}
