namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Vendors;

/// <summary>
///     This component returns references to all of the Vendors in the response, grouped by categorizations that Bungie has deemed to be interesting, in the order in which both the groups and the vendors within that group should be rendered.
/// </summary>
public class DestinyVendorGroupComponent : IDeepEquatable<DestinyVendorGroupComponent>
{
    /// <summary>
    ///     The ordered list of groups being returned.
    /// </summary>
    [JsonPropertyName("groups")]
    public List<Destiny.Components.Vendors.DestinyVendorGroup> Groups { get; set; }

    public bool DeepEquals(DestinyVendorGroupComponent? other)
    {
        return other is not null &&
               Groups.DeepEqualsList(other.Groups);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyVendorGroupComponent? other)
    {
        if (other is null) return;
        if (!Groups.DeepEqualsList(other.Groups))
        {
            Groups = other.Groups;
            OnPropertyChanged(nameof(Groups));
        }
    }
}