using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     A Vendor Interaction is a dialog shown by the vendor other than sale items or transfer screens. The vendor is showing you something, and asking you to reply to it by choosing an option or reward.
/// </summary>
public sealed class DestinyVendorInteractionDefinition
{

    /// <summary>
    ///     The position of this interaction in its parent array. Note that this is NOT content agnostic, and should not be used as such.
    /// </summary>
    [JsonPropertyName("interactionIndex")]
    public int InteractionIndex { get; init; }

    /// <summary>
    ///     The potential replies that the user can make to the interaction.
    /// </summary>
    [JsonPropertyName("replies")]
    public List<Destiny.Definitions.DestinyVendorInteractionReplyDefinition> Replies { get; init; }

    /// <summary>
    ///     If >= 0, this is the category of sale items to show along with this interaction dialog.
    /// </summary>
    [JsonPropertyName("vendorCategoryIndex")]
    public int VendorCategoryIndex { get; init; }

    /// <summary>
    ///     If this interaction dialog is about a quest, this is the questline related to the interaction. You can use this to show the quest overview, or even the character's status with the quest if you use it to find the character's current Quest Step by checking their inventory against this questlineItemHash's DestinyInventoryItemDefinition.setData.
    /// </summary>
    [JsonPropertyName("questlineItemHash")]
    public uint QuestlineItemHash { get; init; }

    /// <summary>
    ///     If this interaction is meant to show you sacks, this is the list of types of sacks to be shown. If empty, the interaction is not meant to show sacks.
    /// </summary>
    [JsonPropertyName("sackInteractionList")]
    public List<Destiny.Definitions.DestinyVendorInteractionSackEntryDefinition> SackInteractionList { get; init; }

    /// <summary>
    ///     A UI hint for the behavior of the interaction screen. This is useful to determine what type of interaction is occurring, such as a prompt to receive a rank up reward or a prompt to choose a reward for completing a quest. The hash isn't as useful as the Enum in retrospect, well what can you do. Try using interactionType instead.
    /// </summary>
    [JsonPropertyName("uiInteractionType")]
    public uint UiInteractionType { get; init; }

    /// <summary>
    ///     The enumerated version of the possible UI hints for vendor interactions, which is a little easier to grok than the hash found in uiInteractionType.
    /// </summary>
    [JsonPropertyName("interactionType")]
    public Destiny.VendorInteractionType InteractionType { get; init; }

    /// <summary>
    ///     If this interaction is displaying rewards, this is the text to use for the header of the reward-displaying section of the interaction.
    /// </summary>
    [JsonPropertyName("rewardBlockLabel")]
    public string RewardBlockLabel { get; init; }

    /// <summary>
    ///     If the vendor's reward list is sourced from one of his categories, this is the index into the category array of items to show.
    /// </summary>
    [JsonPropertyName("rewardVendorCategoryIndex")]
    public int RewardVendorCategoryIndex { get; init; }

    /// <summary>
    ///     If the vendor interaction has flavor text, this is some of it.
    /// </summary>
    [JsonPropertyName("flavorLineOne")]
    public string FlavorLineOne { get; init; }

    /// <summary>
    ///     If the vendor interaction has flavor text, this is the rest of it.
    /// </summary>
    [JsonPropertyName("flavorLineTwo")]
    public string FlavorLineTwo { get; init; }

    /// <summary>
    ///     The header for the interaction dialog.
    /// </summary>
    [JsonPropertyName("headerDisplayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition HeaderDisplayProperties { get; init; }

    /// <summary>
    ///     The localized text telling the player what to do when they see this dialog.
    /// </summary>
    [JsonPropertyName("instructions")]
    public string Instructions { get; init; }
}
