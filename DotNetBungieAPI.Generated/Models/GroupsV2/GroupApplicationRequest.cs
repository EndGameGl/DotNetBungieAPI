using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public sealed class GroupApplicationRequest
{

    [JsonPropertyName("message")]
    public string Message { get; init; }
}
