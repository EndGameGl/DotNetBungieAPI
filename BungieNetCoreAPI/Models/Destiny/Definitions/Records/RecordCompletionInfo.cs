using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.Records
{
    public class RecordCompletionInfo : IDeepEquatable<RecordCompletionInfo>
    {
        public int ScoreValue { get; init; }
        public int PartialCompletionObjectiveCountThreshold { get; init; }
        public bool ShouldFireToast { get; init; }
        public RecordToastStyle ToastStyle { get; init; }

        [JsonConstructor]
        internal RecordCompletionInfo(int ScoreValue, int partialCompletionObjectiveCountThreshold, bool shouldFireToast, RecordToastStyle toastStyle)
        {
            this.ScoreValue = ScoreValue;
            PartialCompletionObjectiveCountThreshold = partialCompletionObjectiveCountThreshold;
            ShouldFireToast = shouldFireToast;
            ToastStyle = toastStyle;
        }

        public bool DeepEquals(RecordCompletionInfo other)
        {
            return other != null &&
                   ScoreValue == other.ScoreValue &&
                   PartialCompletionObjectiveCountThreshold == other.PartialCompletionObjectiveCountThreshold &&
                   ShouldFireToast == other.ShouldFireToast &&
                   ToastStyle == other.ToastStyle;
        }
    }
}
