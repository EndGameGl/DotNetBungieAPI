namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Items;

public class DestinyParentItemOverride : IDeepEquatable<DestinyParentItemOverride>
{
    [JsonPropertyName("additionalEquipRequirementsDisplayStrings")]
    public List<string> AdditionalEquipRequirementsDisplayStrings { get; set; }

    [JsonPropertyName("pipIcon")]
    public string PipIcon { get; set; }

    public bool DeepEquals(DestinyParentItemOverride? other)
    {
        return other is not null &&
               AdditionalEquipRequirementsDisplayStrings.DeepEqualsListNaive(other.AdditionalEquipRequirementsDisplayStrings) &&
               PipIcon == other.PipIcon;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyParentItemOverride? other)
    {
        if (other is null) return;
        if (!AdditionalEquipRequirementsDisplayStrings.DeepEqualsListNaive(other.AdditionalEquipRequirementsDisplayStrings))
        {
            AdditionalEquipRequirementsDisplayStrings = other.AdditionalEquipRequirementsDisplayStrings;
            OnPropertyChanged(nameof(AdditionalEquipRequirementsDisplayStrings));
        }
        if (PipIcon != other.PipIcon)
        {
            PipIcon = other.PipIcon;
            OnPropertyChanged(nameof(PipIcon));
        }
    }
}