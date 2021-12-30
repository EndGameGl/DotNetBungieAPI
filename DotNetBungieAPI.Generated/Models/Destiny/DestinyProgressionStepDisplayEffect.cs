using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny;

/// <summary>
///     If progression is earned, this determines whether the progression shows visual effects on the character or its item - or neither.
/// </summary>
public enum DestinyProgressionStepDisplayEffect : int
{
    None = 0,
    Character = 1,
    Item = 2
}
