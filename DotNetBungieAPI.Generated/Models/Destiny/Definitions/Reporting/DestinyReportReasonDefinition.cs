namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Reporting;

/// <summary>
///     A specific reason for being banned. Only accessible under the related category (DestinyReportReasonCategoryDefinition) under which it is shown. Note that this means that report reasons' reasonHash are not globally unique: and indeed, entries like "Other" are defined under most categories for example.
/// </summary>
public class DestinyReportReasonDefinition : IDeepEquatable<DestinyReportReasonDefinition>
{
    /// <summary>
    ///     The identifier for the reason: they are only guaranteed unique under the Category in which they are found.
    /// </summary>
    [JsonPropertyName("reasonHash")]
    public uint ReasonHash { get; set; }

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }

    public bool DeepEquals(DestinyReportReasonDefinition? other)
    {
        return other is not null &&
               ReasonHash == other.ReasonHash &&
               (DisplayProperties is not null ? DisplayProperties.DeepEquals(other.DisplayProperties) : other.DisplayProperties is null);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyReportReasonDefinition? other)
    {
        if (other is null) return;
        if (ReasonHash != other.ReasonHash)
        {
            ReasonHash = other.ReasonHash;
            OnPropertyChanged(nameof(ReasonHash));
        }
        if (!DisplayProperties.DeepEquals(other.DisplayProperties))
        {
            DisplayProperties.Update(other.DisplayProperties);
            OnPropertyChanged(nameof(DisplayProperties));
        }
    }
}