using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyInventoryItemDefinition
{

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("tooltipNotifications")]
    public List<Destiny.Definitions.DestinyItemTooltipNotification> TooltipNotifications { get; init; }

    [JsonPropertyName("collectibleHash")]
    public uint? CollectibleHash { get; init; }

    [JsonPropertyName("iconWatermark")]
    public string IconWatermark { get; init; }

    [JsonPropertyName("iconWatermarkShelved")]
    public string IconWatermarkShelved { get; init; }

    [JsonPropertyName("secondaryIcon")]
    public string SecondaryIcon { get; init; }

    [JsonPropertyName("secondaryOverlay")]
    public string SecondaryOverlay { get; init; }

    [JsonPropertyName("secondarySpecial")]
    public string SecondarySpecial { get; init; }

    [JsonPropertyName("backgroundColor")]
    public Destiny.Misc.DestinyColor BackgroundColor { get; init; }

    [JsonPropertyName("screenshot")]
    public string Screenshot { get; init; }

    [JsonPropertyName("itemTypeDisplayName")]
    public string ItemTypeDisplayName { get; init; }

    [JsonPropertyName("flavorText")]
    public string FlavorText { get; init; }

    [JsonPropertyName("uiItemDisplayStyle")]
    public string UiItemDisplayStyle { get; init; }

    [JsonPropertyName("itemTypeAndTierDisplayName")]
    public string ItemTypeAndTierDisplayName { get; init; }

    [JsonPropertyName("displaySource")]
    public string DisplaySource { get; init; }

    [JsonPropertyName("tooltipStyle")]
    public string TooltipStyle { get; init; }

    [JsonPropertyName("action")]
    public Destiny.Definitions.DestinyItemActionBlockDefinition Action { get; init; }

    [JsonPropertyName("inventory")]
    public Destiny.Definitions.DestinyItemInventoryBlockDefinition Inventory { get; init; }

    [JsonPropertyName("setData")]
    public Destiny.Definitions.DestinyItemSetBlockDefinition SetData { get; init; }

    [JsonPropertyName("stats")]
    public Destiny.Definitions.DestinyItemStatBlockDefinition Stats { get; init; }

    [JsonPropertyName("emblemObjectiveHash")]
    public uint? EmblemObjectiveHash { get; init; }

    [JsonPropertyName("equippingBlock")]
    public Destiny.Definitions.DestinyEquippingBlockDefinition EquippingBlock { get; init; }

    [JsonPropertyName("translationBlock")]
    public Destiny.Definitions.DestinyItemTranslationBlockDefinition TranslationBlock { get; init; }

    [JsonPropertyName("preview")]
    public Destiny.Definitions.DestinyItemPreviewBlockDefinition Preview { get; init; }

    [JsonPropertyName("quality")]
    public Destiny.Definitions.DestinyItemQualityBlockDefinition Quality { get; init; }

    [JsonPropertyName("value")]
    public Destiny.Definitions.DestinyItemValueBlockDefinition Value { get; init; }

    [JsonPropertyName("sourceData")]
    public Destiny.Definitions.DestinyItemSourceBlockDefinition SourceData { get; init; }

    [JsonPropertyName("objectives")]
    public Destiny.Definitions.DestinyItemObjectiveBlockDefinition Objectives { get; init; }

    [JsonPropertyName("metrics")]
    public Destiny.Definitions.DestinyItemMetricBlockDefinition Metrics { get; init; }

    [JsonPropertyName("plug")]
    public Destiny.Definitions.Items.DestinyItemPlugDefinition Plug { get; init; }

    [JsonPropertyName("gearset")]
    public Destiny.Definitions.DestinyItemGearsetBlockDefinition Gearset { get; init; }

    [JsonPropertyName("sack")]
    public Destiny.Definitions.DestinyItemSackBlockDefinition Sack { get; init; }

    [JsonPropertyName("sockets")]
    public Destiny.Definitions.DestinyItemSocketBlockDefinition Sockets { get; init; }

    [JsonPropertyName("summary")]
    public Destiny.Definitions.DestinyItemSummaryBlockDefinition Summary { get; init; }

    [JsonPropertyName("talentGrid")]
    public Destiny.Definitions.DestinyItemTalentGridBlockDefinition TalentGrid { get; init; }

    [JsonPropertyName("investmentStats")]
    public List<Destiny.Definitions.DestinyItemInvestmentStatDefinition> InvestmentStats { get; init; }

    [JsonPropertyName("perks")]
    public List<Destiny.Definitions.DestinyItemPerkEntryDefinition> Perks { get; init; }

    [JsonPropertyName("loreHash")]
    public uint? LoreHash { get; init; }

    [JsonPropertyName("summaryItemHash")]
    public uint? SummaryItemHash { get; init; }

    [JsonPropertyName("animations")]
    public List<Destiny.Definitions.Animations.DestinyAnimationReference> Animations { get; init; }

    [JsonPropertyName("allowActions")]
    public bool AllowActions { get; init; }

    [JsonPropertyName("links")]
    public List<Links.HyperlinkReference> Links { get; init; }

    [JsonPropertyName("doesPostmasterPullHaveSideEffects")]
    public bool DoesPostmasterPullHaveSideEffects { get; init; }

    [JsonPropertyName("nonTransferrable")]
    public bool NonTransferrable { get; init; }

    [JsonPropertyName("itemCategoryHashes")]
    public List<uint> ItemCategoryHashes { get; init; }

    [JsonPropertyName("specialItemType")]
    public Destiny.SpecialItemType SpecialItemType { get; init; }

    [JsonPropertyName("itemType")]
    public Destiny.DestinyItemType ItemType { get; init; }

    [JsonPropertyName("itemSubType")]
    public Destiny.DestinyItemSubType ItemSubType { get; init; }

    [JsonPropertyName("classType")]
    public Destiny.DestinyClass ClassType { get; init; }

    [JsonPropertyName("breakerType")]
    public Destiny.DestinyBreakerType BreakerType { get; init; }

    [JsonPropertyName("breakerTypeHash")]
    public uint? BreakerTypeHash { get; init; }

    [JsonPropertyName("equippable")]
    public bool Equippable { get; init; }

    [JsonPropertyName("damageTypeHashes")]
    public List<uint> DamageTypeHashes { get; init; }

    [JsonPropertyName("damageTypes")]
    public List<Destiny.DamageType> DamageTypes { get; init; }

    [JsonPropertyName("defaultDamageType")]
    public Destiny.DamageType DefaultDamageType { get; init; }

    [JsonPropertyName("defaultDamageTypeHash")]
    public uint? DefaultDamageTypeHash { get; init; }

    [JsonPropertyName("seasonHash")]
    public uint? SeasonHash { get; init; }

    [JsonPropertyName("isWrapper")]
    public bool IsWrapper { get; init; }

    [JsonPropertyName("traitIds")]
    public List<string> TraitIds { get; init; }

    [JsonPropertyName("traitHashes")]
    public List<uint> TraitHashes { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
