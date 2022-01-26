namespace DotNetBungieAPI.Generated.Models.Applications;

public class Series : IDeepEquatable<Series>
{
    /// <summary>
    ///     Collection of samples with time and value.
    /// </summary>
    [JsonPropertyName("datapoints")]
    public List<Applications.Datapoint> Datapoints { get; set; }

    /// <summary>
    ///     Target to which to datapoints apply.
    /// </summary>
    [JsonPropertyName("target")]
    public string Target { get; set; }

    public bool DeepEquals(Series? other)
    {
        return other is not null &&
               Datapoints.DeepEqualsList(other.Datapoints) &&
               Target == other.Target;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(Series? other)
    {
        if (other is null) return;
        if (!Datapoints.DeepEqualsList(other.Datapoints))
        {
            Datapoints = other.Datapoints;
            OnPropertyChanged(nameof(Datapoints));
        }
        if (Target != other.Target)
        {
            Target = other.Target;
            OnPropertyChanged(nameof(Target));
        }
    }
}