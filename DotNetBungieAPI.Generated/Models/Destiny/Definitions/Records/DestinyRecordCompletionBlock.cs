using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Records;

public sealed class DestinyRecordCompletionBlock
{

    [JsonPropertyName("partialCompletionObjectiveCountThreshold")]
    public int PartialCompletionObjectiveCountThreshold { get; init; }

    [JsonPropertyName("ScoreValue")]
    public int ScoreValue { get; init; }

    [JsonPropertyName("shouldFireToast")]
    public bool ShouldFireToast { get; init; }

    [JsonPropertyName("toastStyle")]
    public Destiny.DestinyRecordToastStyle ToastStyle { get; init; }
}
