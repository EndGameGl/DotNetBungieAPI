namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Vendors;

/// <summary>
///     This component contains essential/summary information about the vendor.
/// </summary>
public class DestinyVendorBaseComponent : IDeepEquatable<DestinyVendorBaseComponent>
{
    /// <summary>
    ///     The unique identifier for the vendor. Use it to look up their DestinyVendorDefinition.
    /// </summary>
    [JsonPropertyName("vendorHash")]
    public uint VendorHash { get; set; }

    /// <summary>
    ///     The date when this vendor's inventory will next rotate/refresh.
    /// <para />
    ///     Note that this is distinct from the date ranges that the vendor is visible/available in-game: this field indicates the specific time when the vendor's available items refresh and rotate, regardless of whether the vendor is actually available at that time. Unfortunately, these two values may be (and are, for the case of important vendors like Xur) different.
    /// <para />
    ///     Issue https://github.com/Bungie-net/api/issues/353 is tracking a fix to start providing visibility date ranges where possible in addition to this refresh date, so that all important dates for vendors are available for use.
    /// </summary>
    [JsonPropertyName("nextRefreshDate")]
    public DateTime NextRefreshDate { get; set; }

    /// <summary>
    ///     If True, the Vendor is currently accessible. 
    /// <para />
    ///     If False, they may not actually be visible in the world at the moment.
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool Enabled { get; set; }

    public bool DeepEquals(DestinyVendorBaseComponent? other)
    {
        return other is not null &&
               VendorHash == other.VendorHash &&
               NextRefreshDate == other.NextRefreshDate &&
               Enabled == other.Enabled;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyVendorBaseComponent? other)
    {
        if (other is null) return;
        if (VendorHash != other.VendorHash)
        {
            VendorHash = other.VendorHash;
            OnPropertyChanged(nameof(VendorHash));
        }
        if (NextRefreshDate != other.NextRefreshDate)
        {
            NextRefreshDate = other.NextRefreshDate;
            OnPropertyChanged(nameof(NextRefreshDate));
        }
        if (Enabled != other.Enabled)
        {
            Enabled = other.Enabled;
            OnPropertyChanged(nameof(Enabled));
        }
    }
}