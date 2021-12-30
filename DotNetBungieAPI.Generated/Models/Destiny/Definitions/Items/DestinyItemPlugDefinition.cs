using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Items;

public sealed class DestinyItemPlugDefinition
{

    [JsonPropertyName("insertionRules")]
    public List<Destiny.Definitions.Items.DestinyPlugRuleDefinition> InsertionRules { get; init; }

    [JsonPropertyName("plugCategoryIdentifier")]
    public string PlugCategoryIdentifier { get; init; }

    [JsonPropertyName("plugCategoryHash")]
    public uint PlugCategoryHash { get; init; }

    [JsonPropertyName("onActionRecreateSelf")]
    public bool OnActionRecreateSelf { get; init; }

    [JsonPropertyName("insertionMaterialRequirementHash")]
    public uint InsertionMaterialRequirementHash { get; init; }

    [JsonPropertyName("previewItemOverrideHash")]
    public uint PreviewItemOverrideHash { get; init; }

    [JsonPropertyName("enabledMaterialRequirementHash")]
    public uint EnabledMaterialRequirementHash { get; init; }

    [JsonPropertyName("enabledRules")]
    public List<Destiny.Definitions.Items.DestinyPlugRuleDefinition> EnabledRules { get; init; }

    [JsonPropertyName("uiPlugLabel")]
    public string UiPlugLabel { get; init; }

    [JsonPropertyName("plugStyle")]
    public Destiny.PlugUiStyles PlugStyle { get; init; }

    [JsonPropertyName("plugAvailability")]
    public Destiny.PlugAvailabilityMode PlugAvailability { get; init; }

    [JsonPropertyName("alternateUiPlugLabel")]
    public string AlternateUiPlugLabel { get; init; }

    [JsonPropertyName("alternatePlugStyle")]
    public Destiny.PlugUiStyles AlternatePlugStyle { get; init; }

    [JsonPropertyName("isDummyPlug")]
    public bool IsDummyPlug { get; init; }

    [JsonPropertyName("parentItemOverride")]
    public Destiny.Definitions.Items.DestinyParentItemOverride ParentItemOverride { get; init; }

    [JsonPropertyName("energyCapacity")]
    public Destiny.Definitions.Items.DestinyEnergyCapacityEntry EnergyCapacity { get; init; }

    [JsonPropertyName("energyCost")]
    public Destiny.Definitions.Items.DestinyEnergyCostEntry EnergyCost { get; init; }
}
