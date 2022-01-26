namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Metrics;

public class DestinyMetricComponent : IDeepEquatable<DestinyMetricComponent>
{
    [JsonPropertyName("invisible")]
    public bool Invisible { get; set; }

    [JsonPropertyName("objectiveProgress")]
    public Destiny.Quests.DestinyObjectiveProgress ObjectiveProgress { get; set; }

    public bool DeepEquals(DestinyMetricComponent? other)
    {
        return other is not null &&
               Invisible == other.Invisible &&
               (ObjectiveProgress is not null ? ObjectiveProgress.DeepEquals(other.ObjectiveProgress) : other.ObjectiveProgress is null);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyMetricComponent? other)
    {
        if (other is null) return;
        if (Invisible != other.Invisible)
        {
            Invisible = other.Invisible;
            OnPropertyChanged(nameof(Invisible));
        }
        if (!ObjectiveProgress.DeepEquals(other.ObjectiveProgress))
        {
            ObjectiveProgress.Update(other.ObjectiveProgress);
            OnPropertyChanged(nameof(ObjectiveProgress));
        }
    }
}