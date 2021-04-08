using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Records
{
    public sealed record DestinyRecordCompletionBlock : IDeepEquatable<DestinyRecordCompletionBlock>
    {
        [JsonPropertyName("ScoreValue")]
        public int ScoreValue { get; init; }
        [JsonPropertyName("partialCompletionObjectiveCountThreshold")]
        public int PartialCompletionObjectiveCountThreshold { get; init; }
        [JsonPropertyName("shouldFireToast")]
        public bool ShouldFireToast { get; init; }
        [JsonPropertyName("toastStyle")]
        public DestinyRecordToastStyle ToastStyle { get; init; }

        public bool DeepEquals(DestinyRecordCompletionBlock other)
        {
            return other != null &&
                   ScoreValue == other.ScoreValue &&
                   PartialCompletionObjectiveCountThreshold == other.PartialCompletionObjectiveCountThreshold &&
                   ShouldFireToast == other.ShouldFireToast &&
                   ToastStyle == other.ToastStyle;
        }
    }
}
