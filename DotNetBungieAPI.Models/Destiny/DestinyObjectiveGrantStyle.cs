namespace DotNetBungieAPI.Models.Destiny;

/// <summary>
///     Some Objectives provide perks, generally as part of providing some kind of interesting modifier for a Challenge or Quest. This indicates when the Perk is granted.
/// </summary>
public enum DestinyObjectiveGrantStyle : int
{
    WhenIncomplete = 0,

    WhenComplete = 1,

    Always = 2
}
