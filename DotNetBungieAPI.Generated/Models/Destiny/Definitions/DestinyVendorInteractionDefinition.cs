using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyVendorInteractionDefinition
{

    [JsonPropertyName("interactionIndex")]
    public int InteractionIndex { get; init; }

    [JsonPropertyName("replies")]
    public List<Destiny.Definitions.DestinyVendorInteractionReplyDefinition> Replies { get; init; }

    [JsonPropertyName("vendorCategoryIndex")]
    public int VendorCategoryIndex { get; init; }

    [JsonPropertyName("questlineItemHash")]
    public uint QuestlineItemHash { get; init; }

    [JsonPropertyName("sackInteractionList")]
    public List<Destiny.Definitions.DestinyVendorInteractionSackEntryDefinition> SackInteractionList { get; init; }

    [JsonPropertyName("uiInteractionType")]
    public uint UiInteractionType { get; init; }

    [JsonPropertyName("interactionType")]
    public Destiny.VendorInteractionType InteractionType { get; init; }

    [JsonPropertyName("rewardBlockLabel")]
    public string RewardBlockLabel { get; init; }

    [JsonPropertyName("rewardVendorCategoryIndex")]
    public int RewardVendorCategoryIndex { get; init; }

    [JsonPropertyName("flavorLineOne")]
    public string FlavorLineOne { get; init; }

    [JsonPropertyName("flavorLineTwo")]
    public string FlavorLineTwo { get; init; }

    [JsonPropertyName("headerDisplayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition HeaderDisplayProperties { get; init; }

    [JsonPropertyName("instructions")]
    public string Instructions { get; init; }
}
