using System.Collections.ObjectModel;
using DotNetBungieAPI.Models.Destiny.Components;

namespace DotNetBungieAPI.Data.Models.Profiles;

public class DestinyProfileAndCharacters
{
    public DestinyProfileComponent Profile { get; init; }
    public ReadOnlyDictionary<long, DestinyCharacterComponent> Characters { get; init; }
}