namespace DotNetBungieAPI.Generated.Models.Config.ClanBanner;

public class ClanBannerDecal : IDeepEquatable<ClanBannerDecal>
{
    [JsonPropertyName("identifier")]
    public string Identifier { get; set; }

    [JsonPropertyName("foregroundPath")]
    public string ForegroundPath { get; set; }

    [JsonPropertyName("backgroundPath")]
    public string BackgroundPath { get; set; }

    public bool DeepEquals(ClanBannerDecal? other)
    {
        return other is not null &&
               Identifier == other.Identifier &&
               ForegroundPath == other.ForegroundPath &&
               BackgroundPath == other.BackgroundPath;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(ClanBannerDecal? other)
    {
        if (other is null) return;
        if (Identifier != other.Identifier)
        {
            Identifier = other.Identifier;
            OnPropertyChanged(nameof(Identifier));
        }
        if (ForegroundPath != other.ForegroundPath)
        {
            ForegroundPath = other.ForegroundPath;
            OnPropertyChanged(nameof(ForegroundPath));
        }
        if (BackgroundPath != other.BackgroundPath)
        {
            BackgroundPath = other.BackgroundPath;
            OnPropertyChanged(nameof(BackgroundPath));
        }
    }
}