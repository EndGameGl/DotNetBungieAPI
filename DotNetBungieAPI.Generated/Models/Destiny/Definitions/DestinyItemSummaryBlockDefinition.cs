namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     This appears to be information used when rendering rewards. We don't currently use it on BNet.
/// </summary>
public sealed class DestinyItemSummaryBlockDefinition
{

    /// <summary>
    ///     Apparently when rendering an item in a reward, this should be used as a sort priority. We're not doing it presently.
    /// </summary>
    [JsonPropertyName("sortPriority")]
    public int SortPriority { get; init; }
}
