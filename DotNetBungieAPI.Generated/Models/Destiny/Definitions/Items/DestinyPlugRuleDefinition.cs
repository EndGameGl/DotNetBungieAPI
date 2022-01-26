namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Items;

/// <summary>
///     Dictates a rule around whether the plug is enabled or insertable.
/// <para />
///     In practice, the live Destiny data will refer to these entries by index. You can then look up that index in the appropriate property (enabledRules or insertionRules) to get the localized string for the failure message if it failed.
/// </summary>
public class DestinyPlugRuleDefinition : IDeepEquatable<DestinyPlugRuleDefinition>
{
    /// <summary>
    ///     The localized string to show if this rule fails.
    /// </summary>
    [JsonPropertyName("failureMessage")]
    public string FailureMessage { get; set; }

    public bool DeepEquals(DestinyPlugRuleDefinition? other)
    {
        return other is not null &&
               FailureMessage == other.FailureMessage;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyPlugRuleDefinition? other)
    {
        if (other is null) return;
        if (FailureMessage != other.FailureMessage)
        {
            FailureMessage = other.FailureMessage;
            OnPropertyChanged(nameof(FailureMessage));
        }
    }
}