using System;
using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.Definitions
{
    [Flags]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DestinyTalentNodeStepWeaponPerformances
    {
        None = 0,
        RateOfFire = 1,
        Damage = 2,
        Accuracy = 4,
        Range = 8,
        Zoom = 16,
        Recoil = 32,
        Ready = 64,
        Reload = 128,
        HairTrigger = 256,
        AmmoAndMagazine = 512,
        TrackingAndDetonation = 1024,
        ShotgunSpread = 2048,
        ChargeTime = 4096,
        All = 8191
    }
}