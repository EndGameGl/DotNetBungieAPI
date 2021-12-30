using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Forums;

[System.Flags]
public enum ForumFlagsEnum : int
{
    None = 0,
    BungieStaffPost = 1,
    ForumNinjaPost = 2,
    ForumMentorPost = 4,
    TopicBungieStaffPosted = 8,
    TopicBungieVolunteerPosted = 16,
    QuestionAnsweredByBungie = 32,
    QuestionAnsweredByNinja = 64,
    CommunityContent = 128
}
