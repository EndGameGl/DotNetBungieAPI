namespace DotNetBungieAPI.Generated.Models.Config;

public class GroupTheme : IDeepEquatable<GroupTheme>
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("folder")]
    public string Folder { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    public bool DeepEquals(GroupTheme? other)
    {
        return other is not null &&
               Name == other.Name &&
               Folder == other.Folder &&
               Description == other.Description;
    }
}