namespace DotNetBungieAPI.Models.Destiny.Definitions.Items;

/// <summary>
///     Dictates a rule around whether the plug is enabled or insertable.
/// <para />
///     In practice, the live Destiny data will refer to these entries by index. You can then look up that index in the appropriate property (enabledRules or insertionRules) to get the localized string for the failure message if it failed.
/// </summary>
public sealed class DestinyPlugRuleDefinition
{
    /// <summary>
    ///     The localized string to show if this rule fails.
    /// </summary>
    [JsonPropertyName("failureMessage")]
    public string FailureMessage { get; init; }
}
