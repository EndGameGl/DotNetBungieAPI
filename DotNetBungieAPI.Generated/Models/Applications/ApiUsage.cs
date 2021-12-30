using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Applications;

public sealed class ApiUsage
{

    [JsonPropertyName("apiCalls")]
    public List<Applications.Series> ApiCalls { get; init; }

    [JsonPropertyName("throttledRequests")]
    public List<Applications.Series> ThrottledRequests { get; init; }
}
