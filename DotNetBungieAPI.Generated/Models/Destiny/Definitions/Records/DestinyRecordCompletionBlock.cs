namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Records;

public class DestinyRecordCompletionBlock
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
}
