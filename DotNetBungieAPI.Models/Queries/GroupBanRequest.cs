using DotNetBungieAPI.Models.Ignores;

namespace DotNetBungieAPI.Models.Queries;

public class GroupBanRequest
{
    [JsonPropertyName("comment")] public string Comment { get; init; }

    [JsonPropertyName("length")] public IgnoreLength Length { get; init; }
}