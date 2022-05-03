namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public class DestinyPlugItemCraftingUnlockRequirement : IDeepEquatable<DestinyPlugItemCraftingUnlockRequirement>
{
    [JsonPropertyName("failureDescription")]
    public string FailureDescription { get; set; }

    public bool DeepEquals(DestinyPlugItemCraftingUnlockRequirement? other)
    {
        return other is not null &&
               FailureDescription == other.FailureDescription;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyPlugItemCraftingUnlockRequirement? other)
    {
        if (other is null) return;
        if (FailureDescription != other.FailureDescription)
        {
            FailureDescription = other.FailureDescription;
            OnPropertyChanged(nameof(FailureDescription));
        }
    }
}