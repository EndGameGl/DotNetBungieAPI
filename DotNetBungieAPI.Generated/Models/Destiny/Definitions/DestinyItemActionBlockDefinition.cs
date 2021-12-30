using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyItemActionBlockDefinition
{

    [JsonPropertyName("verbName")]
    public string VerbName { get; init; }

    [JsonPropertyName("verbDescription")]
    public string VerbDescription { get; init; }

    [JsonPropertyName("isPositive")]
    public bool IsPositive { get; init; }

    [JsonPropertyName("overlayScreenName")]
    public string OverlayScreenName { get; init; }

    [JsonPropertyName("overlayIcon")]
    public string OverlayIcon { get; init; }

    [JsonPropertyName("requiredCooldownSeconds")]
    public int RequiredCooldownSeconds { get; init; }

    [JsonPropertyName("requiredItems")]
    public List<Destiny.Definitions.DestinyItemActionRequiredItemDefinition> RequiredItems { get; init; }

    [JsonPropertyName("progressionRewards")]
    public List<Destiny.Definitions.DestinyProgressionRewardDefinition> ProgressionRewards { get; init; }

    [JsonPropertyName("actionTypeLabel")]
    public string ActionTypeLabel { get; init; }

    [JsonPropertyName("requiredLocation")]
    public string RequiredLocation { get; init; }

    [JsonPropertyName("requiredCooldownHash")]
    public uint RequiredCooldownHash { get; init; }

    [JsonPropertyName("deleteOnAction")]
    public bool DeleteOnAction { get; init; }

    [JsonPropertyName("consumeEntireStack")]
    public bool ConsumeEntireStack { get; init; }

    [JsonPropertyName("useOnAcquire")]
    public bool UseOnAcquire { get; init; }
}
