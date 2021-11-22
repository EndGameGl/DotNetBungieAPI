namespace DotNetBungieAPI.Models.Destiny.Definitions.Records
{
    public sealed record DestinyRecordCompletionBlock : IDeepEquatable<DestinyRecordCompletionBlock>
    {
        [JsonPropertyName("ScoreValue")] public int ScoreValue { get; init; }

        /// <summary>
        ///     The number of objectives that must be completed before the objective is considered "complete"
        /// </summary>
        [JsonPropertyName("partialCompletionObjectiveCountThreshold")]
        public int PartialCompletionObjectiveCountThreshold { get; init; }

        [JsonPropertyName("shouldFireToast")] public bool ShouldFireToast { get; init; }
        [JsonPropertyName("toastStyle")] public DestinyRecordToastStyle ToastStyle { get; init; }

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