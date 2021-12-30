using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public sealed class GroupBanRequest
{

    [JsonPropertyName("comment")]
    public string Comment { get; init; }

    [JsonPropertyName("length")]
    public Ignores.IgnoreLength Length { get; init; }
}
