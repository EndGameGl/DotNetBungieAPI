namespace DotNetBungieAPI.Models.Forum;

[Flags]
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ForumTopicsCategoryFiltersEnum
{
    None = 0,
    Links = 1,
    Questions = 2,
    AnsweredQuestions = 4,
    Media = 8,
    TextOnly = 16,
    Announcement = 32,
    BungieOfficial = 64,
    Polls = 128
}