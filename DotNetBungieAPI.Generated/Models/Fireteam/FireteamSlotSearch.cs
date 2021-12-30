using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Fireteam;

public enum FireteamSlotSearch : byte
{
    NoSlotRestriction = 0,
    HasOpenPlayerSlots = 1,
    HasOpenPlayerOrAltSlots = 2
}
