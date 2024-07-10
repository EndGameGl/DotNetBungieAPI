namespace DotNetBungieAPI.Models.Forum;

public enum ForumTopicsSortEnum : byte
{
    Default = 0,
    LastReplied = 1,
    MostReplied = 2,
    Popularity = 3,
    Controversiality = 4,
    Liked = 5,
    HighestRated = 6,
    MostUpvoted = 7
}
