using System;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Forum
{
    [Flags, JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ForumFlagsEnum
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
}
