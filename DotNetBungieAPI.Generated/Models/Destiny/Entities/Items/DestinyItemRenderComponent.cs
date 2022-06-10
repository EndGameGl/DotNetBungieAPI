namespace DotNetBungieAPI.Generated.Models.Destiny.Entities.Items;

/// <summary>
///     Many items can be rendered in 3D. When you request this block, you will obtain the custom data needed to render this specific instance of the item.
/// </summary>
public class DestinyItemRenderComponent
{
    /// <summary>
    ///     If you should use custom dyes on this item, it will be indicated here.
    /// </summary>
    [JsonPropertyName("useCustomDyes")]
    public bool? UseCustomDyes { get; set; }

    /// <summary>
    ///     A dictionary for rendering gear components, with:
    /// <para />
    ///     key = Art Arrangement Region Index
    /// <para />
    ///     value = The chosen Arrangement Index for the Region, based on the value of a stat on the item used for making the choice.
    /// </summary>
    [JsonPropertyName("artRegions")]
    public Dictionary<int, int> ArtRegions { get; set; }
}
