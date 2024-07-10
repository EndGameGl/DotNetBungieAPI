namespace DotNetBungieAPI.Models.Authorization;

public sealed record AuthorizationResponseError
{
    [JsonPropertyName("error")]
    public string? Error { get; set; }

    [JsonPropertyName("error_description")]
    public string? ErrorDescription { get; set; }

    [JsonPropertyName("error_uri")]
    public string? ErrorUri { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }
}
