using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Records
{
    public class RecordCompletionInfo : IDeepEquatable<RecordCompletionInfo>
    {
        public int ScoreValue { get; }
        public int PartialCompletionObjectiveCountThreshold { get; }
        public bool ShouldFireToast { get; }
        public RecordToastStyle ToastStyle { get; }

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
