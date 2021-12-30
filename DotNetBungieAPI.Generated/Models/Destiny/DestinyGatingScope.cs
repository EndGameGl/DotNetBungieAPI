using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny;

public enum DestinyGatingScope : int
{
    None = 0,
    Global = 1,
    Clan = 2,
    Profile = 3,
    Character = 4,
    Item = 5,
    AssumedWorstCase = 6
}
