namespace DotNetBungieAPI.Models.GroupsV2;

public sealed class GroupEditHistory
{
    [JsonPropertyName("groupId")]
    public long GroupId { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("nameEditors")]
    public long? NameEditors { get; init; }

    [JsonPropertyName("about")]
    public string About { get; init; }

    [JsonPropertyName("aboutEditors")]
    public long? AboutEditors { get; init; }

    [JsonPropertyName("motto")]
    public string Motto { get; init; }

    [JsonPropertyName("mottoEditors")]
    public long? MottoEditors { get; init; }

    [JsonPropertyName("clanCallsign")]
    public string ClanCallsign { get; init; }

    [JsonPropertyName("clanCallsignEditors")]
    public long? ClanCallsignEditors { get; init; }

    [JsonPropertyName("editDate")]
    public DateTime? EditDate { get; init; }

    [JsonPropertyName("groupEditors")]
    public User.UserInfoCard[]? GroupEditors { get; init; }
}
