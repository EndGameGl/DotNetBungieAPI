namespace DotNetBungieAPI.Models.Destiny;

/// <summary>
///     There's a lot of places where we need to know scope on more than just a profile or character level. For everything
///     else, there's this more generic sense of scope.
/// </summary>
public enum DestinyScope
{
    Profile = 0,
    Character = 1
}