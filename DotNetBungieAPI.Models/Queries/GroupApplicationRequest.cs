namespace DotNetBungieAPI.Models.Queries;

public class GroupApplicationRequest
{
    [JsonPropertyName("message")]
    public string Message { get; init; }
}
