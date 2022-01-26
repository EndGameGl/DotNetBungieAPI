namespace DotNetBungieAPI.Generated.Models.Common.Models;

public class CoreSystem : IDeepEquatable<CoreSystem>
{
    [JsonPropertyName("enabled")]
    public bool Enabled { get; set; }

    [JsonPropertyName("parameters")]
    public Dictionary<string, string> Parameters { get; set; }

    public bool DeepEquals(CoreSystem? other)
    {
        return other is not null &&
               Enabled == other.Enabled &&
               Parameters.DeepEqualsDictionaryNaive(other.Parameters);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(CoreSystem? other)
    {
        if (other is null) return;
        if (Enabled != other.Enabled)
        {
            Enabled = other.Enabled;
            OnPropertyChanged(nameof(Enabled));
        }
        if (!Parameters.DeepEqualsDictionaryNaive(other.Parameters))
        {
            Parameters = other.Parameters;
            OnPropertyChanged(nameof(Parameters));
        }
    }
}