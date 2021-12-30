using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

[System.Flags]
public enum DestinyTalentNodeStepLightAbilities : int
{
    None = 0,
    Grenades = 1,
    Melee = 2,
    MovementModes = 4,
    Orbs = 8,
    SuperEnergy = 16,
    SuperMods = 32,
    All = 63
}
