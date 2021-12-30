using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny;

public enum DestinyProgressionScope : int
{
    Account = 0,
    Character = 1,
    Clan = 2,
    Item = 3,
    ImplicitFromEquipment = 4,
    Mapped = 5,
    MappedAggregate = 6,
    MappedStat = 7,
    MappedUnlockValue = 8
}
