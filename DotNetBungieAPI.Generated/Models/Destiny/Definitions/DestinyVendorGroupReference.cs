namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public class DestinyVendorGroupReference : IDeepEquatable<DestinyVendorGroupReference>
{
    /// <summary>
    ///     The DestinyVendorGroupDefinition to which this Vendor can belong.
    /// </summary>
    [JsonPropertyName("vendorGroupHash")]
    public uint VendorGroupHash { get; set; }

    public bool DeepEquals(DestinyVendorGroupReference? other)
    {
        return other is not null &&
               VendorGroupHash == other.VendorGroupHash;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyVendorGroupReference? other)
    {
        if (other is null) return;
        if (VendorGroupHash != other.VendorGroupHash)
        {
            VendorGroupHash = other.VendorGroupHash;
            OnPropertyChanged(nameof(VendorGroupHash));
        }
    }
}