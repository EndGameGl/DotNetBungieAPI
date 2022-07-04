namespace DotNetBungieAPI.Models.Destiny.Definitions;

[Flags]
public enum DestinyTalentNodeStepDamageTypes
{
    None = 0,
    Kinetic = 1,
    Arc = 2,
    Solar = 4,
    Void = 8,
    All = 15
}