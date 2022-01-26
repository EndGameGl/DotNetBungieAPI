namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public class GroupBanRequest : IDeepEquatable<GroupBanRequest>
{
    [JsonPropertyName("comment")]
    public string Comment { get; set; }

    [JsonPropertyName("length")]
    public Ignores.IgnoreLength Length { get; set; }

    public bool DeepEquals(GroupBanRequest? other)
    {
        return other is not null &&
               Comment == other.Comment &&
               Length == other.Length;
    }
}