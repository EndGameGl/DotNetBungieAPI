namespace DotNetBungieAPI.Generated.Models;

public class SingleComponentResponseOfDestinyVendorCategoriesComponent : IDeepEquatable<SingleComponentResponseOfDestinyVendorCategoriesComponent>
{
    [JsonPropertyName("data")]
    public Destiny.Entities.Vendors.DestinyVendorCategoriesComponent Data { get; set; }

    [JsonPropertyName("privacy")]
    public Components.ComponentPrivacySetting Privacy { get; set; }

    /// <summary>
    ///     If true, this component is disabled.
    /// </summary>
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }

    public bool DeepEquals(SingleComponentResponseOfDestinyVendorCategoriesComponent? other)
    {
        return other is not null &&
               (Data is not null ? Data.DeepEquals(other.Data) : other.Data is null) &&
               Privacy == other.Privacy &&
               Disabled == other.Disabled;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(SingleComponentResponseOfDestinyVendorCategoriesComponent? other)
    {
        if (other is null) return;
        if (!Data.DeepEquals(other.Data))
        {
            Data.Update(other.Data);
            OnPropertyChanged(nameof(Data));
        }
        if (Privacy != other.Privacy)
        {
            Privacy = other.Privacy;
            OnPropertyChanged(nameof(Privacy));
        }
        if (Disabled != other.Disabled)
        {
            Disabled = other.Disabled;
            OnPropertyChanged(nameof(Disabled));
        }
    }
}