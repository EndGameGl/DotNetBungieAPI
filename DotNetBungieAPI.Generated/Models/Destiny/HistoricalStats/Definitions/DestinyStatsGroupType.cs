using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats.Definitions;

public enum DestinyStatsGroupType : int
{
    None = 0,
    General = 1,
    Weapons = 2,
    Medals = 3,
    ReservedGroups = 100,
    Leaderboard = 101,
    Activity = 102,
    UniqueWeapon = 103,
    Internal = 104
}
