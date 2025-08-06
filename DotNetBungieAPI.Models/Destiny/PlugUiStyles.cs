namespace DotNetBungieAPI.Models.Destiny;

/// <summary>
///     If the plug has a specific custom style, this enumeration will represent that style/those styles.
/// </summary>
[System.Flags]
public enum PlugUiStyles : int
{
    None = 0,

    Masterwork = 1
}
