namespace DotNetBungieAPI.Models.GroupsV2;

public sealed class GroupApplicationRequest
{
    [JsonPropertyName("message")]
    public string Message { get; init; }
}
