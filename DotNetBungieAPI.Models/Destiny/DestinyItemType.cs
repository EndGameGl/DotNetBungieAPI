namespace DotNetBungieAPI.Models.Destiny;

/// <summary>
///     An enumeration that indicates the high-level "type" of the item, attempting to iron out the context specific differences for specific instances of an entity. For instance, though a weapon may be of various weapon "Types", in DestinyItemType they are all classified as "Weapon". This allows for better filtering on a higher level of abstraction for the concept of types.
/// <para />
///      This enum is provided for historical compatibility with Destiny 1, but an ideal alternative is to use DestinyItemCategoryDefinitions and the DestinyItemDefinition.itemCategories property instead. Item Categories allow for arbitrary hierarchies of specificity, and for items to belong to multiple categories across multiple hierarchies simultaneously. For this enum, we pick a single type as a "best guess" fit.
/// <para />
///      NOTE: This is not all of the item types available, and some of these are holdovers from Destiny 1 that may or may not still exist.
/// <para />
///      I keep updating these because they're so damn convenient. I guess I shouldn't fight it.
/// </summary>
public enum DestinyItemType : int
{
    None = 0,

    Currency = 1,

    Armor = 2,

    Weapon = 3,

    Message = 7,

    Engram = 8,

    Consumable = 9,

    ExchangeMaterial = 10,

    MissionReward = 11,

    QuestStep = 12,

    QuestStepComplete = 13,

    Emblem = 14,

    Quest = 15,

    Subclass = 16,

    ClanBanner = 17,

    Aura = 18,

    Mod = 19,

    Dummy = 20,

    Ship = 21,

    Vehicle = 22,

    Emote = 23,

    Ghost = 24,

    Package = 25,

    Bounty = 26,

    Wrapper = 27,

    SeasonalArtifact = 28,

    Finisher = 29,

    Pattern = 30
}
