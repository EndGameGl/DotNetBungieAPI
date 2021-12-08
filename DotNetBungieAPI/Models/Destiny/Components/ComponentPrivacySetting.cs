namespace DotNetBungieAPI.Models.Destiny.Components;

/// <summary>
///     A set of flags for reason(s) why the component populated in the way that it did. Inspect the individual flags for
///     the reasons.
/// </summary>
public enum ComponentPrivacySetting
{
    None = 0,
    Public = 1,
    Private = 2
}