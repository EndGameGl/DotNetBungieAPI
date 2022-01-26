namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Records;

public class DestinyRecordCompletionBlock : IDeepEquatable<DestinyRecordCompletionBlock>
{
    /// <summary>
    ///     The number of objectives that must be completed before the objective is considered "complete"
    /// </summary>
    [JsonPropertyName("partialCompletionObjectiveCountThreshold")]
    public int PartialCompletionObjectiveCountThreshold { get; set; }

    [JsonPropertyName("ScoreValue")]
    public int ScoreValue { get; set; }

    [JsonPropertyName("shouldFireToast")]
    public bool ShouldFireToast { get; set; }

    [JsonPropertyName("toastStyle")]
    public Destiny.DestinyRecordToastStyle ToastStyle { get; set; }

    public bool DeepEquals(DestinyRecordCompletionBlock? other)
    {
        return other is not null &&
               PartialCompletionObjectiveCountThreshold == other.PartialCompletionObjectiveCountThreshold &&
               ScoreValue == other.ScoreValue &&
               ShouldFireToast == other.ShouldFireToast &&
               ToastStyle == other.ToastStyle;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyRecordCompletionBlock? other)
    {
        if (other is null) return;
        if (PartialCompletionObjectiveCountThreshold != other.PartialCompletionObjectiveCountThreshold)
        {
            PartialCompletionObjectiveCountThreshold = other.PartialCompletionObjectiveCountThreshold;
            OnPropertyChanged(nameof(PartialCompletionObjectiveCountThreshold));
        }
        if (ScoreValue != other.ScoreValue)
        {
            ScoreValue = other.ScoreValue;
            OnPropertyChanged(nameof(ScoreValue));
        }
        if (ShouldFireToast != other.ShouldFireToast)
        {
            ShouldFireToast = other.ShouldFireToast;
            OnPropertyChanged(nameof(ShouldFireToast));
        }
        if (ToastStyle != other.ToastStyle)
        {
            ToastStyle = other.ToastStyle;
            OnPropertyChanged(nameof(ToastStyle));
        }
    }
}