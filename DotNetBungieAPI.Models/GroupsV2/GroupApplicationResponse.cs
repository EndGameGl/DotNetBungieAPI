namespace DotNetBungieAPI.Models.GroupsV2;

public sealed class GroupApplicationResponse
{
    [JsonPropertyName("resolution")]
    public GroupsV2.GroupApplicationResolveState Resolution { get; init; }
}
