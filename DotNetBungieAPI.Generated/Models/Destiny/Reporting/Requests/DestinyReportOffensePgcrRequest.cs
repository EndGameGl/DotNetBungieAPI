namespace DotNetBungieAPI.Generated.Models.Destiny.Reporting.Requests;

/// <summary>
///     If you want to report a player causing trouble in a game, this request will let you report that player and the specific PGCR in which the trouble was caused, along with why.
/// <para />
///     Please don't do this just because you dislike the person! I mean, I know people will do it anyways, but can you like take a good walk, or put a curse on them or something? Do me a solid and reconsider.
/// <para />
///     Note that this request object doesn't have the actual PGCR ID nor your Account/Character ID in it. We will infer that information from your authentication information and the PGCR ID that you pass into the URL of the reporting endpoint itself.
/// </summary>
public class DestinyReportOffensePgcrRequest : IDeepEquatable<DestinyReportOffensePgcrRequest>
{
    /// <summary>
    ///     So you've decided to report someone instead of cursing them and their descendants. Well, okay then. This is the category or categorie(s) of infractions for which you are reporting the user. These are hash identifiers that map to DestinyReportReasonCategoryDefinition entries.
    /// </summary>
    [JsonPropertyName("reasonCategoryHashes")]
    public List<uint> ReasonCategoryHashes { get; set; }

    /// <summary>
    ///     If applicable, provide a more specific reason(s) within the general category of problems provided by the reasonHash. This is also an identifier for a reason. All reasonHashes provided must be children of at least one the reasonCategoryHashes provided.
    /// </summary>
    [JsonPropertyName("reasonHashes")]
    public List<uint> ReasonHashes { get; set; }

    /// <summary>
    ///     Within the PGCR provided when calling the Reporting endpoint, this should be the character ID of the user that you thought was violating terms of use. They must exist in the PGCR provided.
    /// </summary>
    [JsonPropertyName("offendingCharacterId")]
    public long OffendingCharacterId { get; set; }

    public bool DeepEquals(DestinyReportOffensePgcrRequest? other)
    {
        return other is not null &&
               ReasonCategoryHashes.DeepEqualsListNaive(other.ReasonCategoryHashes) &&
               ReasonHashes.DeepEqualsListNaive(other.ReasonHashes) &&
               OffendingCharacterId == other.OffendingCharacterId;
    }
}