namespace DotNetBungieAPI.Models.Destiny.Definitions.Items;

[DestinyDefinition(DefinitionsEnum.DestinyInventoryItemConstantsDefinition)]
public sealed class DestinyInventoryItemConstantsDefinition : IDestinyDefinition
{
    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyInventoryItemConstantsDefinition;

    /// <summary>
    ///     Gear tier overlay images
    /// </summary>
    [JsonPropertyName("gearTierOverlayImagePaths")]
    public string[]? GearTierOverlayImagePaths { get; init; }

    /// <summary>
    ///     Watermark drop shadow
    /// </summary>
    [JsonPropertyName("watermarkDropShadowPath")]
    public string WatermarkDropShadowPath { get; init; }

    /// <summary>
    ///     Reverse drop shadow for crafted icon identifier
    /// </summary>
    [JsonPropertyName("craftedBackgroundPath")]
    public string CraftedBackgroundPath { get; init; }

    /// <summary>
    ///     Teal flag for featured item watermarks
    /// </summary>
    [JsonPropertyName("featuredItemFlagPath")]
    public string FeaturedItemFlagPath { get; init; }

    /// <summary>
    ///     Gold masterwork glow
    /// </summary>
    [JsonPropertyName("masterworkOverlayPath")]
    public string MasterworkOverlayPath { get; init; }

    /// <summary>
    ///     Crafted weapon overlay path
    /// </summary>
    [JsonPropertyName("craftedOverlayPath")]
    public string CraftedOverlayPath { get; init; }

    /// <summary>
    ///     Enhanced item overlay
    /// </summary>
    [JsonPropertyName("enhancedItemOverlayPath")]
    public string EnhancedItemOverlayPath { get; init; }

    /// <summary>
    ///     Layer between item and color background to denote holofoil status, introduced in v736
    /// </summary>
    [JsonPropertyName("holofoilBackgroundOverlayPath")]
    public string HolofoilBackgroundOverlayPath { get; init; }

    /// <summary>
    ///     Layer between item and color background to denote holofoil status, introduced in v900
    /// </summary>
    [JsonPropertyName("holofoil900BackgroundOverlayPath")]
    public string Holofoil900BackgroundOverlayPath { get; init; }

    /// <summary>
    ///     Layer between item and color background to denote holofoil status, introduced in v900, animated
    /// </summary>
    [JsonPropertyName("holofoil900AnimatedBackgroundOverlayPath")]
    public string Holofoil900AnimatedBackgroundOverlayPath { get; init; }

    /// <summary>
    ///     Layer between item and color background to denote universal ornament status
    /// </summary>
    [JsonPropertyName("universalOrnamentBackgroundOverlayPath")]
    public string UniversalOrnamentBackgroundOverlayPath { get; init; }

    /// <summary>
    ///     The unique identifier for this entity. Guaranteed to be unique for the type of entity, but not globally.
    /// <para />
    ///     When entities refer to each other in Destiny content, it is this hash that they are referring to.
    /// </summary>
    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    /// <summary>
    ///     The index of the entity as it was found in the investment tables.
    /// </summary>
    [JsonPropertyName("index")]
    public int Index { get; init; }

    /// <summary>
    ///     If this is true, then there is an entity with this identifier/type combination, but BNet is not yet allowed to show it. Sorry!
    /// </summary>
    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
