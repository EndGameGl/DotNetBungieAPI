namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public class GroupBanRequest
{
    [JsonPropertyName("comment")]
    public string? Comment { get; set; }

    [JsonPropertyName("length")]
    public Ignores.IgnoreLength? Length { get; set; }
}
