namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public class ClanBanner : IDeepEquatable<ClanBanner>
{
    [JsonPropertyName("decalId")]
    public uint DecalId { get; set; }

    [JsonPropertyName("decalColorId")]
    public uint DecalColorId { get; set; }

    [JsonPropertyName("decalBackgroundColorId")]
    public uint DecalBackgroundColorId { get; set; }

    [JsonPropertyName("gonfalonId")]
    public uint GonfalonId { get; set; }

    [JsonPropertyName("gonfalonColorId")]
    public uint GonfalonColorId { get; set; }

    [JsonPropertyName("gonfalonDetailId")]
    public uint GonfalonDetailId { get; set; }

    [JsonPropertyName("gonfalonDetailColorId")]
    public uint GonfalonDetailColorId { get; set; }

    public bool DeepEquals(ClanBanner? other)
    {
        return other is not null &&
               DecalId == other.DecalId &&
               DecalColorId == other.DecalColorId &&
               DecalBackgroundColorId == other.DecalBackgroundColorId &&
               GonfalonId == other.GonfalonId &&
               GonfalonColorId == other.GonfalonColorId &&
               GonfalonDetailId == other.GonfalonDetailId &&
               GonfalonDetailColorId == other.GonfalonDetailColorId;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(ClanBanner? other)
    {
        if (other is null) return;
        if (DecalId != other.DecalId)
        {
            DecalId = other.DecalId;
            OnPropertyChanged(nameof(DecalId));
        }
        if (DecalColorId != other.DecalColorId)
        {
            DecalColorId = other.DecalColorId;
            OnPropertyChanged(nameof(DecalColorId));
        }
        if (DecalBackgroundColorId != other.DecalBackgroundColorId)
        {
            DecalBackgroundColorId = other.DecalBackgroundColorId;
            OnPropertyChanged(nameof(DecalBackgroundColorId));
        }
        if (GonfalonId != other.GonfalonId)
        {
            GonfalonId = other.GonfalonId;
            OnPropertyChanged(nameof(GonfalonId));
        }
        if (GonfalonColorId != other.GonfalonColorId)
        {
            GonfalonColorId = other.GonfalonColorId;
            OnPropertyChanged(nameof(GonfalonColorId));
        }
        if (GonfalonDetailId != other.GonfalonDetailId)
        {
            GonfalonDetailId = other.GonfalonDetailId;
            OnPropertyChanged(nameof(GonfalonDetailId));
        }
        if (GonfalonDetailColorId != other.GonfalonDetailColorId)
        {
            GonfalonDetailColorId = other.GonfalonDetailColorId;
            OnPropertyChanged(nameof(GonfalonDetailColorId));
        }
    }
}