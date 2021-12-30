using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

[System.Flags]
public enum DestinyTalentNodeStepGuardianAttributes : int
{
    None = 0,
    Stats = 1,
    Shields = 2,
    Health = 4,
    Revive = 8,
    AimUnderFire = 16,
    Radar = 32,
    Invisibility = 64,
    Reputations = 128,
    All = 255
}
