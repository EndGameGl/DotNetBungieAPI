namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Items;

/// <summary>
///     If an item is a Plug, its DestinyInventoryItemDefinition.plug property will be populated with an instance of one of these bad boys.
/// <para />
///     This gives information about when it can be inserted, what the plug's category is (and thus whether it is compatible with a socket... see DestinySocketTypeDefinition for information about Plug Categories and socket compatibility), whether it is enabled and other Plug info.
/// </summary>
public class DestinyItemPlugDefinition : IDeepEquatable<DestinyItemPlugDefinition>
{
    /// <summary>
    ///     The rules around when this plug can be inserted into a socket, aside from the socket's individual restrictions.
    /// <para />
    ///     The live data DestinyItemPlugComponent.insertFailIndexes will be an index into this array, so you can pull out the failure strings appropriate for the user.
    /// </summary>
    [JsonPropertyName("insertionRules")]
    public List<Destiny.Definitions.Items.DestinyPlugRuleDefinition> InsertionRules { get; set; }

    /// <summary>
    ///     The string identifier for the plug's category. Use the socket's DestinySocketTypeDefinition.plugWhitelist to determine whether this plug can be inserted into the socket.
    /// </summary>
    [JsonPropertyName("plugCategoryIdentifier")]
    public string PlugCategoryIdentifier { get; set; }

    /// <summary>
    ///     The hash for the plugCategoryIdentifier. You can use this instead if you wish: I put both in the definition for debugging purposes.
    /// </summary>
    [JsonPropertyName("plugCategoryHash")]
    public uint PlugCategoryHash { get; set; }

    /// <summary>
    ///     If you successfully socket the item, this will determine whether or not you get "refunded" on the plug.
    /// </summary>
    [JsonPropertyName("onActionRecreateSelf")]
    public bool OnActionRecreateSelf { get; set; }

    /// <summary>
    ///     If inserting this plug requires materials, this is the hash identifier for looking up the DestinyMaterialRequirementSetDefinition for those requirements.
    /// </summary>
    [JsonPropertyName("insertionMaterialRequirementHash")]
    public uint InsertionMaterialRequirementHash { get; set; }

    /// <summary>
    ///     In the game, if you're inspecting a plug item directly, this will be the item shown with the plug attached. Look up the DestinyInventoryItemDefinition for this hash for the item.
    /// </summary>
    [JsonPropertyName("previewItemOverrideHash")]
    public uint PreviewItemOverrideHash { get; set; }

    /// <summary>
    ///     It's not enough for the plug to be inserted. It has to be enabled as well. For it to be enabled, it may require materials. This is the hash identifier for the DestinyMaterialRequirementSetDefinition for those requirements, if there is one.
    /// </summary>
    [JsonPropertyName("enabledMaterialRequirementHash")]
    public uint EnabledMaterialRequirementHash { get; set; }

    /// <summary>
    ///     The rules around whether the plug, once inserted, is enabled and providing its benefits.
    /// <para />
    ///     The live data DestinyItemPlugComponent.enableFailIndexes will be an index into this array, so you can pull out the failure strings appropriate for the user.
    /// </summary>
    [JsonPropertyName("enabledRules")]
    public List<Destiny.Definitions.Items.DestinyPlugRuleDefinition> EnabledRules { get; set; }

    /// <summary>
    ///     Plugs can have arbitrary, UI-defined identifiers that the UI designers use to determine the style applied to plugs. Unfortunately, we have neither a definitive list of these labels nor advance warning of when new labels might be applied or how that relates to how they get rendered. If you want to, you can refer to known labels to change your own styles: but know that new ones can be created arbitrarily, and we have no way of associating the labels with any specific UI style guidance... you'll have to piece that together on your end. Or do what we do, and just show plugs more generically, without specialized styles.
    /// </summary>
    [JsonPropertyName("uiPlugLabel")]
    public string UiPlugLabel { get; set; }

    [JsonPropertyName("plugStyle")]
    public Destiny.PlugUiStyles PlugStyle { get; set; }

    /// <summary>
    ///     Indicates the rules about when this plug can be used. See the PlugAvailabilityMode enumeration for more information!
    /// </summary>
    [JsonPropertyName("plugAvailability")]
    public Destiny.PlugAvailabilityMode PlugAvailability { get; set; }

    /// <summary>
    ///     If the plug meets certain state requirements, it may have an alternative label applied to it. This is the alternative label that will be applied in such a situation.
    /// </summary>
    [JsonPropertyName("alternateUiPlugLabel")]
    public string AlternateUiPlugLabel { get; set; }

    /// <summary>
    ///     The alternate plug of the plug: only applies when the item is in states that only the server can know about and control, unfortunately. See AlternateUiPlugLabel for the related label info.
    /// </summary>
    [JsonPropertyName("alternatePlugStyle")]
    public Destiny.PlugUiStyles AlternatePlugStyle { get; set; }

    /// <summary>
    ///     If TRUE, this plug is used for UI display purposes only, and doesn't have any interesting effects of its own.
    /// </summary>
    [JsonPropertyName("isDummyPlug")]
    public bool IsDummyPlug { get; set; }

    /// <summary>
    ///     Do you ever get the feeling that a system has become so overburdened by edge cases that it probably should have become some other system entirely? So do I!
    /// <para />
    ///     In totally unrelated news, Plugs can now override properties of their parent items. This is some of the relevant definition data for those overrides.
    /// <para />
    ///     If this is populated, it will have the override data to be applied when this plug is applied to an item.
    /// </summary>
    [JsonPropertyName("parentItemOverride")]
    public Destiny.Definitions.Items.DestinyParentItemOverride ParentItemOverride { get; set; }

    /// <summary>
    ///     IF not null, this plug provides Energy capacity to the item in which it is socketed. In Armor 2.0 for example, is implemented in a similar way to Masterworks, where visually it's a single area of the UI being clicked on to "Upgrade" to higher energy levels, but it's actually socketing new plugs.
    /// </summary>
    [JsonPropertyName("energyCapacity")]
    public Destiny.Definitions.Items.DestinyEnergyCapacityEntry EnergyCapacity { get; set; }

    /// <summary>
    ///     IF not null, this plug has an energy cost. This contains the details of that cost.
    /// </summary>
    [JsonPropertyName("energyCost")]
    public Destiny.Definitions.Items.DestinyEnergyCostEntry EnergyCost { get; set; }

    public bool DeepEquals(DestinyItemPlugDefinition? other)
    {
        return other is not null &&
               InsertionRules.DeepEqualsList(other.InsertionRules) &&
               PlugCategoryIdentifier == other.PlugCategoryIdentifier &&
               PlugCategoryHash == other.PlugCategoryHash &&
               OnActionRecreateSelf == other.OnActionRecreateSelf &&
               InsertionMaterialRequirementHash == other.InsertionMaterialRequirementHash &&
               PreviewItemOverrideHash == other.PreviewItemOverrideHash &&
               EnabledMaterialRequirementHash == other.EnabledMaterialRequirementHash &&
               EnabledRules.DeepEqualsList(other.EnabledRules) &&
               UiPlugLabel == other.UiPlugLabel &&
               PlugStyle == other.PlugStyle &&
               PlugAvailability == other.PlugAvailability &&
               AlternateUiPlugLabel == other.AlternateUiPlugLabel &&
               AlternatePlugStyle == other.AlternatePlugStyle &&
               IsDummyPlug == other.IsDummyPlug &&
               (ParentItemOverride is not null ? ParentItemOverride.DeepEquals(other.ParentItemOverride) : other.ParentItemOverride is null) &&
               (EnergyCapacity is not null ? EnergyCapacity.DeepEquals(other.EnergyCapacity) : other.EnergyCapacity is null) &&
               (EnergyCost is not null ? EnergyCost.DeepEquals(other.EnergyCost) : other.EnergyCost is null);
    }
}