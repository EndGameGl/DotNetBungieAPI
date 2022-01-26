namespace DotNetBungieAPI.Generated.Models.Fireteam;

public class FireteamResponse : IDeepEquatable<FireteamResponse>
{
    [JsonPropertyName("Summary")]
    public Fireteam.FireteamSummary Summary { get; set; }

    [JsonPropertyName("Members")]
    public List<Fireteam.FireteamMember> Members { get; set; }

    [JsonPropertyName("Alternates")]
    public List<Fireteam.FireteamMember> Alternates { get; set; }

    public bool DeepEquals(FireteamResponse? other)
    {
        return other is not null &&
               (Summary is not null ? Summary.DeepEquals(other.Summary) : other.Summary is null) &&
               Members.DeepEqualsList(other.Members) &&
               Alternates.DeepEqualsList(other.Alternates);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(FireteamResponse? other)
    {
        if (other is null) return;
        if (!Summary.DeepEquals(other.Summary))
        {
            Summary.Update(other.Summary);
            OnPropertyChanged(nameof(Summary));
        }
        if (!Members.DeepEqualsList(other.Members))
        {
            Members = other.Members;
            OnPropertyChanged(nameof(Members));
        }
        if (!Alternates.DeepEqualsList(other.Alternates))
        {
            Alternates = other.Alternates;
            OnPropertyChanged(nameof(Alternates));
        }
    }
}