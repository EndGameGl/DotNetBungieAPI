namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public class GroupEditHistory
{
    [JsonPropertyName("groupId")]
    public long GroupId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("nameEditors")]
    public long? NameEditors { get; set; }

    [JsonPropertyName("about")]
    public string About { get; set; }

    [JsonPropertyName("aboutEditors")]
    public long? AboutEditors { get; set; }

    [JsonPropertyName("motto")]
    public string Motto { get; set; }

    [JsonPropertyName("mottoEditors")]
    public long? MottoEditors { get; set; }

    [JsonPropertyName("clanCallsign")]
    public string ClanCallsign { get; set; }

    [JsonPropertyName("clanCallsignEditors")]
    public long? ClanCallsignEditors { get; set; }

    [JsonPropertyName("editDate")]
    public DateTime? EditDate { get; set; }

    [JsonPropertyName("groupEditors")]
    public User.UserInfoCard[]? GroupEditors { get; set; }
}
