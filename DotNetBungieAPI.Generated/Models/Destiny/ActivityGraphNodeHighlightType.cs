namespace DotNetBungieAPI.Generated.Models.Destiny;

/// <summary>
///     The various known UI styles in which an item can be highlighted. It'll be up to you to determine what you want to show based on this highlighting, BNet doesn't have any assets that correspond to these states. And yeah, RiseOfIron and Comet have their own special highlight states. Don't ask me, I can't imagine they're still used.
/// </summary>
public enum ActivityGraphNodeHighlightType : int
{
    None = 0,

    Normal = 1,

    Hyper = 2,

    Comet = 3,

    RiseOfIron = 4
}
