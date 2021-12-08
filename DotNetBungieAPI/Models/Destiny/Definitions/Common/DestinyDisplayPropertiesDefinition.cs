using System.Diagnostics;

namespace DotNetBungieAPI.Models.Destiny.Definitions.Common;

/// <summary>
///     Represents common properties for displaying <see cref="IDestinyDefinition" />
/// </summary>
[DebuggerDisplay("{Name}: {Description}")]
public record DestinyDisplayPropertiesDefinition : IDeepEquatable<DestinyDisplayPropertiesDefinition>
{
    [JsonPropertyName("description")] public string Description { get; init; }

    [JsonPropertyName("name")] public string Name { get; init; }

    [JsonPropertyName("hasIcon")] public bool HasIcon { get; init; }

    /// <summary>
    ///     Note that "icon" is sometimes misleading, and should be interpreted in the context of the entity. For instance, in
    ///     Destiny 1 the DestinyRecordBookDefinition's icon was a big picture of a book.
    ///     <para />
    ///     But usually, it will be a small square image that you can use as... well, an icon.
    ///     <para />
    ///     They are currently represented as 96px x 96px images.
    /// </summary>
    [JsonPropertyName("icon")]
    public BungieNetResource Icon { get; init; }

    /// <summary>
    ///     If this item has a high-res icon (at least for now, many things won't), then the path to that icon will be here.
    /// </summary>
    [JsonPropertyName("highResIcon")]
    public BungieNetResource HighResolutionIcon { get; init; }

    [JsonPropertyName("iconSequences")]
    public ReadOnlyCollection<DestinyIconSequenceDefinition> IconSequences { get; init; } =
        ReadOnlyCollections<DestinyIconSequenceDefinition>.Empty;

    public bool DeepEquals(DestinyDisplayPropertiesDefinition other)
    {
        return other != null &&
               Description == other.Description &&
               HasIcon == other.HasIcon &&
               Icon == other.Icon &&
               Name == other.Name &&
               HighResolutionIcon == other.HighResolutionIcon &&
               IconSequences.DeepEqualsReadOnlyCollections(other.IconSequences);
    }
}