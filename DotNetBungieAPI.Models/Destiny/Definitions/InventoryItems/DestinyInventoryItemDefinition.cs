﻿using DotNetBungieAPI.Models.Attributes;
using DotNetBungieAPI.Models.Destiny.Definitions.BreakerTypes;
using DotNetBungieAPI.Models.Destiny.Definitions.Collectibles;
using DotNetBungieAPI.Models.Destiny.Definitions.Common;
using DotNetBungieAPI.Models.Destiny.Definitions.DamageTypes;
using DotNetBungieAPI.Models.Destiny.Definitions.ItemCategories;
using DotNetBungieAPI.Models.Destiny.Definitions.Lore;
using DotNetBungieAPI.Models.Destiny.Definitions.Objectives;
using DotNetBungieAPI.Models.Destiny.Definitions.Seasons;
using DotNetBungieAPI.Models.Destiny.Definitions.Traits;
using DotNetBungieAPI.Models.Links;

namespace DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;

/// <summary>
///     So much of what you see in Destiny is actually an Item used in a new and creative way. This is the definition for
///     Items in Destiny, which started off as just entities that could exist in your Inventory but ended up being the
///     backing data for so much more: quests, reward previews, slots, and subclasses.
///     <para />
///     In practice, you will want to associate this data with "live" item data from a Bungie.Net Platform call: these
///     definitions describe the item in generic, non-instanced terms: but an actual instance of an item can vary widely
///     from these generic definitions.
/// </summary>
[DestinyDefinition(DefinitionsEnum.DestinyInventoryItemDefinition)]
public sealed record DestinyInventoryItemDefinition
    : IDestinyDefinition,
        IDisplayProperties,
        IDeepEquatable<DestinyInventoryItemDefinition>
{
    [JsonPropertyName("displayProperties")]
    public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    /// <summary>
    ///     Tooltips that only come up conditionally for the item. Check the live data
    ///     DestinyItemComponent.tooltipNotificationIndexes property for which of these should be shown at runtime.
    /// </summary>
    [JsonPropertyName("tooltipNotifications")]
    public ReadOnlyCollection<DestinyItemTooltipNotification> TooltipNotifications { get; init; } =
        ReadOnlyCollection<DestinyItemTooltipNotification>.Empty;

    /// <summary>
    ///     If this item has a collectible related to it, this is that collectible entry.
    /// </summary>
    [JsonPropertyName("collectibleHash")]
    public DefinitionHashPointer<DestinyCollectibleDefinition> Collectible { get; init; } =
        DefinitionHashPointer<DestinyCollectibleDefinition>.Empty;

    /// <summary>
    ///     If available, this is the original 'active' release watermark overlay for the icon. If the item has different
    ///     versions, this can be overridden by the 'display version watermark icon' from the 'quality' block. Alternatively,
    ///     if there is no watermark for the version, and the item version has a power cap below the current season power cap,
    ///     this can be overridden by the iconWatermarkShelved property.
    /// </summary>
    [JsonPropertyName("iconWatermark")]
    public BungieNetResource IconWatermark { get; init; }

    /// <summary>
    ///     If available, this is the 'shelved' release watermark overlay for the icon. If the item version has a power cap
    ///     below the current season power cap, it can be treated as 'shelved', and should be shown with this 'shelved'
    ///     watermark overlay.
    /// </summary>
    [JsonPropertyName("iconWatermarkShelved")]
    public BungieNetResource IconWatermarkShelved { get; init; }

    /// <summary>
    ///     A secondary icon associated with the item. Currently this is used in very context specific applications, such as
    ///     Emblem Nameplates.
    /// </summary>
    [JsonPropertyName("secondaryIcon")]
    public BungieNetResource SecondaryIcon { get; init; }

    /// <summary>
    ///     Pulled from the secondary icon, this is the "secondary background" of the secondary icon. Confusing? Sure, that's
    ///     why I call it "overlay" here: because as far as it's been used thus far, it has been for an optional overlay image.
    ///     We'll see if that holds up, but at least for now it explains what this image is a bit better.
    /// </summary>
    [JsonPropertyName("secondaryOverlay")]
    public BungieNetResource SecondaryOverlay { get; init; }

    /// <summary>
    ///     Pulled from the Secondary Icon, this is the "special" background for the item. For Emblems, this is the background
    ///     image used on the Details view: but it need not be limited to that for other types of items.
    /// </summary>
    [JsonPropertyName("secondarySpecial")]
    public BungieNetResource SecondarySpecial { get; init; }

    /// <summary>
    ///     Sometimes, an item will have a background color. Most notably this occurs with Emblems, who use the Background
    ///     Color for small character nameplates such as the "friends" view you see in-game. There are almost certainly other
    ///     items that have background color as well, though I have not bothered to investigate what items have it nor what
    ///     purposes they serve: use it as you will.
    /// </summary>
    [JsonPropertyName("backgroundColor")]
    public DestinyColor BackgroundColor { get; init; }

    /// <summary>
    ///     If we were able to acquire an in-game screenshot for the item, the path to that screenshot will be returned here.
    ///     Note that not all items have screenshots: particularly not any non-equippable items.
    /// </summary>
    [JsonPropertyName("screenshot")]
    public BungieNetResource Screenshot { get; init; }

    /// <summary>
    ///     The localized title/name of the item's type. This can be whatever the designers want, and has no guarantee of
    ///     consistency between items.
    /// </summary>
    [JsonPropertyName("itemTypeDisplayName")]
    public string ItemTypeDisplayName { get; init; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("flavorText")]
    public string FlavorText { get; init; }

    /// <summary>
    ///     A string identifier that the game's UI uses to determine how the item should be rendered in inventory screens and
    ///     the like. This could really be anything - at the moment, we don't have the time to really breakdown and maintain
    ///     all the possible strings this could be, partly because new ones could be added ad hoc. But if you want to use it to
    ///     dictate your own UI, or look for items with a certain display style, go for it!
    /// </summary>
    [JsonPropertyName("uiItemDisplayStyle")]
    public string UiItemDisplayStyle { get; init; }

    /// <summary>
    ///     It became a common enough pattern in our UI to show Item Type and Tier combined into a single localized string that
    ///     I'm just going to go ahead and start pre-creating these for items.
    /// </summary>
    [JsonPropertyName("itemTypeAndTierDisplayName")]
    public string ItemTypeAndTierDisplayName { get; init; }

    /// <summary>
    ///     In theory, it is a localized string telling you about how you can find the item. I really wish this was more
    ///     consistent. Many times, it has nothing. Sometimes, it's instead a more narrative-forward description of the item.
    ///     Which is cool, and I wish all properties had that data, but it should really be its own property.
    /// </summary>
    [JsonPropertyName("displaySource")]
    public string DisplaySource { get; init; }

    /// <summary>
    ///     An identifier that the game UI uses to determine what type of tooltip to show for the item. These have no
    ///     corresponding definitions that BNet can link to: so it'll be up to you to interpret and display your UI differently
    ///     according to these styles (or ignore it).
    /// </summary>
    [JsonPropertyName("tooltipStyle")]
    public string TooltipStyle { get; init; }

    /// <summary>
    ///     If the item can be "used", this block will be non-null, and will have data related to the action performed when
    ///     using the item. (Guess what? 99% of the time, this action is "dismantle". Shocker)
    /// </summary>
    [JsonPropertyName("action")]
    public DestinyItemActionBlockDefinition Action { get; init; }

    /// <summary>
    ///     Recipe items will have relevant crafting information available here.
    /// </summary>
    [JsonPropertyName("crafting")]
    public DestinyItemCraftingBlockDefinition Crafting { get; init; }

    /// <summary>
    ///     If this item can exist in an inventory, this block will be non-null. In practice, every item that currently exists
    ///     has one of these blocks. But note that it is not necessarily guaranteed.
    /// </summary>
    [JsonPropertyName("inventory")]
    public DestinyItemInventoryBlockDefinition Inventory { get; init; }

    /// <summary>
    ///     If this item is a quest, this block will be non-null. In practice, I wish I had called this the Quest block, but at
    ///     the time it wasn't clear to me whether it would end up being used for purposes other than quests. It will contain
    ///     data about the steps in the quest, and mechanics we can use for displaying and tracking the quest.
    /// </summary>
    [JsonPropertyName("setData")]
    public DestinyItemSetBlockDefinition SetData { get; init; }

    /// <summary>
    ///     If this item can have stats (such as a weapon, armor, or vehicle), this block will be non-null and populated with
    ///     the stats found on the item.
    /// </summary>
    [JsonPropertyName("stats")]
    public DestinyItemStatBlockDefinition Stats { get; init; }

    /// <summary>
    ///     If the item is an emblem that has a special Objective attached to it - for instance, if the emblem tracks PVP
    ///     Kills, or what-have-you. This is a bit different from, for example, the Vanguard Kill Tracker mod, which pipes data
    ///     into the "art channel". When I get some time, I would like to standardize these so you can get at the values they
    ///     expose without having to care about what they're being used for and how they are wired up, but for now here's the
    ///     raw data.
    /// </summary>
    [JsonPropertyName("emblemObjectiveHash")]
    public DefinitionHashPointer<DestinyObjectiveDefinition> EmblemObjective { get; init; } =
        DefinitionHashPointer<DestinyObjectiveDefinition>.Empty;

    /// <summary>
    ///     If this item can be equipped, this block will be non-null and will be populated with the conditions under which it
    ///     can be equipped.
    /// </summary>
    [JsonPropertyName("equippingBlock")]
    public DestinyEquippingBlockDefinition EquippingBlock { get; init; }

    /// <summary>
    ///     If this item can be rendered, this block will be non-null and will be populated with rendering information.
    /// </summary>
    [JsonPropertyName("translationBlock")]
    public DestinyItemTranslationBlockDefinition TranslationBlock { get; init; }

    /// <summary>
    ///     If this item can be Used or Acquired to gain other items (for instance, how Eververse Boxes can be consumed to get
    ///     items from the box), this block will be non-null and will give summary information for the items that can be
    ///     acquired.
    /// </summary>
    [JsonPropertyName("preview")]
    public DestinyItemPreviewBlockDefinition Preview { get; init; }

    /// <summary>
    ///     If this item can have a level or stats, this block will be non-null and will be populated with default quality
    ///     (item level, "quality", and infusion) data. See the block for more details, there's often less upfront information
    ///     in D2 so you'll want to be aware of how you use quality and item level on the definition level now.
    /// </summary>
    [JsonPropertyName("quality")]
    public DestinyItemQualityBlockDefinition Quality { get; init; }

    /// <summary>
    ///     The conceptual "Value" of an item, if any was defined.
    /// </summary>
    [JsonPropertyName("value")]
    public DestinyItemValueBlockDefinition Value { get; init; }

    /// <summary>
    ///     If this item has a known source, this block will be non-null and populated with source information. Unfortunately,
    ///     at this time we are not generating sources: that is some aggressively manual work which we didn't have time for,
    ///     and I'm hoping to get back to at some point in the future.
    /// </summary>
    [JsonPropertyName("sourceData")]
    public DestinyItemSourceBlockDefinition SourceData { get; init; }

    /// <summary>
    ///     If this item has Objectives (extra tasks that can be accomplished related to the item... most frequently when the
    ///     item is a Quest Step and the Objectives need to be completed to move on to the next Quest Step), this block will be
    ///     non-null and the objectives defined herein.
    /// </summary>
    [JsonPropertyName("objectives")]
    public DestinyItemObjectiveBlockDefinition Objectives { get; init; }

    /// <summary>
    ///     If this item has available metrics to be shown, this block will be non-null have the appropriate hashes defined.
    /// </summary>
    [JsonPropertyName("metrics")]
    public DestinyItemMetricBlockDefinition Metrics { get; init; }

    /// <summary>
    ///     If this item *is* a Plug, this will be non-null and the info defined herein.
    /// </summary>
    [JsonPropertyName("plug")]
    public DestinyItemPlugDefinition Plug { get; init; }

    /// <summary>
    ///     If this item has related items in a "Gear Set", this will be non-null and the relationships defined herein.
    /// </summary>
    [JsonPropertyName("gearset")]
    public DestinyItemGearsetBlockDefinition Gearset { get; init; }

    /// <summary>
    ///     If this item is a "reward sack" that can be opened to provide other items, this will be non-null and the properties
    ///     of the sack contained herein.
    /// </summary>
    [JsonPropertyName("sack")]
    public DestinyItemSackBlockDefinition Sack { get; init; }

    /// <summary>
    ///     If this item has any Sockets, this will be non-null and the individual sockets on the item will be defined herein.
    /// </summary>
    [JsonPropertyName("sockets")]
    public DestinyItemSocketBlockDefinition Sockets { get; init; }

    /// <summary>
    ///     Summary data about the item.
    /// </summary>
    [JsonPropertyName("summary")]
    public DestinyItemSummaryBlockDefinition Summary { get; init; }

    /// <summary>
    ///     If the item has a Talent Grid, this will be non-null and the properties of the grid defined herein. Note that,
    ///     while many items still have talent grids, the only ones with meaningful Nodes still on them will be
    ///     Subclass/"Build" items.
    /// </summary>
    [JsonPropertyName("talentGrid")]
    public DestinyItemTalentGridBlockDefinition TalentGrid { get; init; }

    /// <summary>
    ///     If the item has stats, this block will be defined. It has the "raw" investment stats for the item. These investment
    ///     stats don't take into account the ways that the items can spawn, nor do they take into account any Stat Group
    ///     transformations. I have retained them for debugging purposes, but I do not know how useful people will find them.
    /// </summary>
    [JsonPropertyName("investmentStats")]
    public ReadOnlyCollection<DestinyItemInvestmentStatDefinition> InvestmentStats { get; init; } =
        ReadOnlyCollection<DestinyItemInvestmentStatDefinition>.Empty;

    /// <summary>
    ///     If the item has any *intrinsic* Perks (Perks that it will provide regardless of Sockets, Talent Grid, and other
    ///     transitory state), they will be defined here.
    /// </summary>
    [JsonPropertyName("perks")]
    public ReadOnlyCollection<DestinyItemPerkEntryDefinition> Perks { get; init; } =
        ReadOnlyCollection<DestinyItemPerkEntryDefinition>.Empty;

    /// <summary>
    ///     If the item has any related Lore (DestinyLoreDefinition), this will be it.
    /// </summary>
    [JsonPropertyName("loreHash")]
    public DefinitionHashPointer<DestinyLoreDefinition> Lore { get; init; } =
        DefinitionHashPointer<DestinyLoreDefinition>.Empty;

    /// <summary>
    ///     There are times when the game will show you a "summary/vague" version of an item - such as a description of its
    ///     type represented as a DestinyInventoryItemDefinition - rather than display the item itself.
    /// </summary>
    [JsonPropertyName("summaryItemHash")]
    public DefinitionHashPointer<DestinyInventoryItemDefinition> SummaryItem { get; init; } =
        DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;

    /// <summary>
    ///     If any animations were extracted from game content for this item, these will be the definitions of those
    ///     animations.
    /// </summary>
    [JsonPropertyName("animations")]
    public ReadOnlyCollection<DestinyAnimationReference> Animations { get; init; } =
        ReadOnlyCollection<DestinyAnimationReference>.Empty;

    /// <summary>
    ///     BNet may forbid the execution of actions on this item via the API. If that is occurring, allowActions will be set
    ///     to false.
    /// </summary>
    [JsonPropertyName("allowActions")]
    public bool AllowActions { get; init; }

    /// <summary>
    ///     If we added any help or informational URLs about this item, these will be those links.
    /// </summary>
    [JsonPropertyName("links")]
    public ReadOnlyCollection<HyperlinkReference> Links { get; init; } =
        ReadOnlyCollection<HyperlinkReference>.Empty;

    /// <summary>
    ///     The boolean will indicate to us (and you!) whether something *could* happen when you transfer this item from the
    ///     Postmaster that might be considered a "destructive" action.
    ///     <para />
    ///     It is not feasible currently to tell you (or ourselves!) in a consistent way whether this *will* actually cause a
    ///     destructive action, so we are playing it safe: if it has the potential to do so, we will not allow it to be
    ///     transferred from the Postmaster by default. You will need to check for this flag before transferring an item from
    ///     the Postmaster, or else you'll end up receiving an error.
    /// </summary>
    [JsonPropertyName("doesPostmasterPullHaveSideEffects")]
    public bool DoesPostmasterPullHaveSideEffects { get; init; }

    /// <summary>
    ///     The intrinsic transferability of an item.
    ///     <para />
    ///     I hate that this boolean is negative - but there's a reason.
    ///     <para />
    ///     Just because an item is intrinsically transferrable doesn't mean that it can be transferred, and we don't want to
    ///     imply that this is the only source of that transferability.
    /// </summary>
    [JsonPropertyName("nonTransferrable")]
    public bool NonTransferrable { get; init; }

    /// <summary>
    ///     BNet attempts to make a more formal definition of item "Categories", as defined by DestinyItemCategoryDefinition.
    ///     This is a list of all Categories that we were able to algorithmically determine that this item is a member of. (for
    ///     instance, that it's a "Weapon", that it's an "Auto Rifle", etc...)
    /// </summary>
    [JsonPropertyName("itemCategoryHashes")]
    public ReadOnlyCollection<
        DefinitionHashPointer<DestinyItemCategoryDefinition>
    > ItemCategories { get; init; } =
        ReadOnlyCollection<DefinitionHashPointer<DestinyItemCategoryDefinition>>.Empty;

    /// <summary>
    ///     In Destiny 1, we identified some items as having particular categories that we'd like to know about for various
    ///     internal logic purposes. These are defined in SpecialItemType, and while these days the ItemCategories are the
    ///     preferred way of identifying types, we have retained this enum for its convenience.
    /// </summary>
    [JsonPropertyName("specialItemType")]
    public SpecialItemType SpecialItemType { get; init; }

    /// <summary>
    ///     A value indicating the "base" the of the item. This enum is a useful but dramatic oversimplification of what it
    ///     means for an item to have a "Type". Still, it's handy in many situations.
    ///     <para />
    ///     ItemCategories are the preferred way of identifying types, we have retained this enum for its convenience.
    /// </summary>
    [JsonPropertyName("itemType")]
    public DestinyItemType ItemType { get; init; }

    /// <summary>
    ///     A value indicating the "sub-type" of the item. For instance, where an item might have an ItemType value "Weapon",
    ///     this will be something more specific like "Auto Rifle".
    ///     <para />
    ///     ItemCategories are the preferred way of identifying types, we have retained this enum for its convenience.
    /// </summary>
    [JsonPropertyName("itemSubType")]
    public DestinyItemSubType ItemSubType { get; init; }

    /// <summary>
    ///     If we find item to be restricted in such a way, we set this ClassType property to match the class' enumeration
    ///     value so that users can easily identify class restricted items.
    /// </summary>
    [JsonPropertyName("classType")]
    public DestinyClass ClassType { get; init; }

    /// <summary>
    ///     Some weapons and plugs can have a "Breaker Type": a special ability that works sort of like damage type
    ///     vulnerabilities. This is (almost?) always set on items by plugs.
    /// </summary>
    [JsonPropertyName("breakerType")]
    public DestinyBreakerType BreakerTypeEnumValue { get; init; }

    /// <summary>
    ///     Since we also have a breaker type definition, this is the definition for that breaker type.
    /// </summary>
    [JsonPropertyName("breakerTypeHash")]
    public DefinitionHashPointer<DestinyBreakerTypeDefinition> BreakerType { get; init; } =
        DefinitionHashPointer<DestinyBreakerTypeDefinition>.Empty;

    /// <summary>
    ///     If true, then you will be allowed to equip the item if you pass its other requirements.
    ///     <para />
    ///     This being false means that you cannot equip the item under any circumstances.
    /// </summary>
    [JsonPropertyName("equippable")]
    public bool Equippable { get; init; }

    /// <summary>
    ///     This field will return all of the possible damage types that are available to the weapon by default.
    /// </summary>
    [JsonPropertyName("damageTypeHashes")]
    public ReadOnlyCollection<
        DefinitionHashPointer<DestinyDamageTypeDefinition>
    > DamageTypes { get; init; } =
        ReadOnlyCollection<DefinitionHashPointer<DestinyDamageTypeDefinition>>.Empty;

    /// <summary>
    ///     This is the list of all damage types that we know ahead of time the item can take on. Unfortunately, this does not
    ///     preclude the possibility of something funky happening to give the item a damage type that cannot be predicted
    ///     beforehand: for example, if some designer decides to create arbitrary non-reusable plugs that cause damage type to
    ///     change.
    ///     <para />
    ///     This damage type prediction will only use the following to determine potential damage types:
    ///     <para />
    ///     - Intrinsic perks
    ///     <para />
    ///     - Talent Node perks
    ///     <para />
    ///     - Known, reusable plugs for sockets
    /// </summary>
    [JsonPropertyName("damageTypes")]
    public ReadOnlyCollection<DamageType> DamageTypeEnumValues { get; init; } =
        ReadOnlyCollection<DamageType>.Empty;

    /// <summary>
    ///     If the item has a damage type that could be considered to be default, it will be populated here.
    /// </summary>
    [JsonPropertyName("defaultDamageType")]
    public DamageType DefaultDamageTypeEnumValue { get; init; }

    /// <summary>
    ///     Similar to DefaultDamageType, but represented as DestinyDamageTypeDefinition.
    /// </summary>
    [JsonPropertyName("defaultDamageTypeHash")]
    public DefinitionHashPointer<DestinyDamageTypeDefinition> DefaultDamageType { get; init; } =
        DefinitionHashPointer<DestinyDamageTypeDefinition>.Empty;

    /// <summary>
    ///     If this item is related directly to a Season of Destiny, this is the identifier for that season.
    /// </summary>
    [JsonPropertyName("seasonHash")]
    public DefinitionHashPointer<DestinySeasonDefinition> Season { get; init; } =
        DefinitionHashPointer<DestinySeasonDefinition>.Empty;

    /// <summary>
    ///     If true, this is a dummy vendor-wrapped item template. Items purchased from Eververse will be "wrapped" by one of
    ///     these items so that we can safely provide refund capabilities before the item is "unwrapped".
    /// </summary>
    [JsonPropertyName("isWrapper")]
    public bool IsWrapper { get; init; }

    /// <summary>
    ///     Traits are metadata tags applied to this item. For example: armor slot, weapon type, foundry, faction, etc. These
    ///     IDs come from the game and don't map to any content, but should still be useful.
    /// </summary>
    [JsonPropertyName("traitIds")]
    public ReadOnlyCollection<string> TraitIds { get; init; } = ReadOnlyCollection<string>.Empty;

    /// <summary>
    ///     These are the corresponding trait definitions for the entries in traitIds.
    /// </summary>
    [JsonPropertyName("traitHashes")]
    public ReadOnlyCollection<DefinitionHashPointer<DestinyTraitDefinition>> Traits { get; init; } =
        ReadOnlyCollection<DefinitionHashPointer<DestinyTraitDefinition>>.Empty;

    public bool DeepEquals(DestinyInventoryItemDefinition other)
    {
        return other != null
            && Collectible.DeepEquals(other.Collectible)
            && SummaryItem.DeepEquals(other.SummaryItem)
            && ItemCategories.DeepEqualsReadOnlyCollection(other.ItemCategories)
            && AllowActions == other.AllowActions
            && (
                BackgroundColor != null
                    ? BackgroundColor.DeepEquals(other.BackgroundColor)
                    : other.BackgroundColor == null
            )
            && BreakerTypeEnumValue == other.BreakerTypeEnumValue
            && BreakerType.DeepEquals(other.BreakerType)
            && ClassType == other.ClassType
            && DefaultDamageTypeEnumValue == other.DefaultDamageTypeEnumValue
            && DefaultDamageType.DeepEquals(other.DefaultDamageType)
            && ItemSubType == other.ItemSubType
            && ItemType == other.ItemType
            && SpecialItemType == other.SpecialItemType
            && DisplayProperties.DeepEquals(other.DisplayProperties)
            && DisplaySource == other.DisplaySource
            && DoesPostmasterPullHaveSideEffects == other.DoesPostmasterPullHaveSideEffects
            && Equippable == other.Equippable
            && IconWatermark == other.IconWatermark
            && IconWatermarkShelved == other.IconWatermarkShelved
            && IsWrapper == other.IsWrapper
            && ItemTypeAndTierDisplayName == other.ItemTypeAndTierDisplayName
            && ItemTypeDisplayName == other.ItemTypeDisplayName
            && UiItemDisplayStyle == other.UiItemDisplayStyle
            && NonTransferrable == other.NonTransferrable
            && SecondaryIcon == other.SecondaryIcon
            && SecondaryOverlay == other.SecondaryOverlay
            && SecondarySpecial == other.SecondarySpecial
            && Screenshot == other.Screenshot
            && TooltipStyle == other.TooltipStyle
            && TraitIds.DeepEqualsReadOnlySimpleCollection(other.TraitIds)
            && (Stats != null ? Stats.DeepEquals(other.Stats) : other.Stats == null)
            && (
                TalentGrid != null
                    ? TalentGrid.DeepEquals(other.TalentGrid)
                    : other.TalentGrid == null
            )
            && (
                TranslationBlock != null
                    ? TranslationBlock.DeepEquals(other.TranslationBlock)
                    : other.TranslationBlock == null
            )
            && (Value != null ? Value.DeepEquals(other.Value) : other.Value == null)
            && (SetData != null ? SetData.DeepEquals(other.SetData) : other.SetData == null)
            && (Plug != null ? Plug.DeepEquals(other.Plug) : other.Plug == null)
            && (Preview != null ? Preview.DeepEquals(other.Preview) : other.Preview == null)
            && (Quality != null ? Quality.DeepEquals(other.Quality) : other.Quality == null)
            && (
                Objectives != null
                    ? Objectives.DeepEquals(other.Objectives)
                    : other.Objectives == null
            )
            && Inventory.DeepEquals(other.Inventory)
            && (Action != null ? Action.DeepEquals(other.Action) : other.Action == null)
            && (
                EquippingBlock != null
                    ? EquippingBlock.DeepEquals(other.EquippingBlock)
                    : other.EquippingBlock == null
            )
            && (Sockets is not null ? Sockets.DeepEquals(other.Sockets) : other.Sockets == null)
            && InvestmentStats.DeepEqualsReadOnlyCollection(other.InvestmentStats)
            && Perks.DeepEqualsReadOnlyCollection(other.Perks)
            && TooltipNotifications.DeepEqualsReadOnlyCollection(other.TooltipNotifications)
            && (Sack != null ? Sack.DeepEquals(other.Sack) : other.Sack == null)
            && (Gearset != null ? Gearset.DeepEquals(other.Gearset) : other.Gearset == null)
            && EmblemObjective.DeepEquals(other.EmblemObjective)
            && (
                SourceData != null
                    ? SourceData.DeepEquals(other.SourceData)
                    : other.SourceData == null
            )
            && (Metrics != null ? Metrics.DeepEquals(other.Metrics) : other.Metrics == null)
            && (Summary != null ? Summary.DeepEquals(other.Summary) : other.Summary == null)
            && Lore.DeepEquals(other.Lore)
            && Animations.DeepEqualsReadOnlyCollection(other.Animations)
            && Links.DeepEqualsReadOnlyCollection(other.Links)
            && DamageTypes.DeepEqualsReadOnlyCollection(other.DamageTypes)
            && DamageTypeEnumValues.DeepEqualsReadOnlySimpleCollection(other.DamageTypeEnumValues)
            && Season.DeepEquals(other.Season)
            && FlavorText.Equals(other.FlavorText)
            && (Crafting is not null ? Crafting.DeepEquals(other.Crafting) : other.Crafting is null)
            && Blacklisted == other.Blacklisted
            && Hash == other.Hash
            && Index == other.Index
            && Redacted == other.Redacted;
    }

    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyInventoryItemDefinition;

    [JsonPropertyName("blacklisted")]
    public bool Blacklisted { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
