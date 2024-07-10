namespace DotNetBungieAPI.Models.Destiny.Components;

/// <summary>
///     Many items can be rendered in 3D. When you request this block, you will obtain the custom data needed to render
///     this specific instance of the item.
/// </summary>
public sealed record DestinyItemRenderComponent
{
    /// <summary>
    ///     If you should use custom dyes on this item, it will be indicated here.
    /// </summary>
    [JsonPropertyName("useCustomDyes")]
    public bool UseCustomDyes { get; init; }

    /// <summary>
    ///     A dictionary for rendering gear components, with:
    ///     <para />
    ///     key = Art Arrangement Region Index
    ///     <para />
    ///     value = The chosen Arrangement Index for the Region, based on the value of a stat on the item used for making the
    ///     choice.
    /// </summary>
    [JsonPropertyName("artRegions")]
    public ReadOnlyDictionary<int, int> ArtRegions { get; init; } =
        ReadOnlyDictionaries<int, int>.Empty;
}
