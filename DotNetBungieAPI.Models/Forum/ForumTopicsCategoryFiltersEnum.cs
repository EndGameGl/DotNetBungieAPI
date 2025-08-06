namespace DotNetBungieAPI.Models.Forum;

[System.Flags]
public enum ForumTopicsCategoryFiltersEnum : int
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
