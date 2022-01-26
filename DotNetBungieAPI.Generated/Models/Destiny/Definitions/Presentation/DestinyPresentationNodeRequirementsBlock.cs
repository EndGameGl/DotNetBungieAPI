namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Presentation;

/// <summary>
///     Presentation nodes can be restricted by various requirements. This defines the rules of those requirements, and the message(s) to be shown if these requirements aren't met.
/// </summary>
public class DestinyPresentationNodeRequirementsBlock : IDeepEquatable<DestinyPresentationNodeRequirementsBlock>
{
    /// <summary>
    ///     If this node is not accessible due to Entitlements (for instance, you don't own the required game expansion), this is the message to show.
    /// </summary>
    [JsonPropertyName("entitlementUnavailableMessage")]
    public string EntitlementUnavailableMessage { get; set; }

    public bool DeepEquals(DestinyPresentationNodeRequirementsBlock? other)
    {
        return other is not null &&
               EntitlementUnavailableMessage == other.EntitlementUnavailableMessage;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyPresentationNodeRequirementsBlock? other)
    {
        if (other is null) return;
        if (EntitlementUnavailableMessage != other.EntitlementUnavailableMessage)
        {
            EntitlementUnavailableMessage = other.EntitlementUnavailableMessage;
            OnPropertyChanged(nameof(EntitlementUnavailableMessage));
        }
    }
}