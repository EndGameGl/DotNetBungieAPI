namespace DotNetBungieAPI.Models.Trending;

/// <summary>
///     The known entity types that you can have returned from Trending.
/// </summary>
public enum TrendingEntryType : int
{
    News = 0,

    DestinyItem = 1,

    DestinyActivity = 2,

    DestinyRitual = 3,

    SupportArticle = 4,

    Creation = 5,

    Stream = 6,

    Update = 7,

    Link = 8,

    ForumTag = 9,

    Container = 10,

    Release = 11
}
