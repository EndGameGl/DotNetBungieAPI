using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Records
{
    public class RecordCompletionInfo
    {
        public int ScoreValue { get; }
        public int PartialCompletionObjectiveCountThreshold { get; }
        public bool ShouldFireToast { get; }
        public int ToastStyle { get; }

        [JsonConstructor]
        private RecordCompletionInfo(int ScoreValue, int partialCompletionObjectiveCountThreshold, bool shouldFireToast, int toastStyle)
        {
            this.ScoreValue = ScoreValue;
            PartialCompletionObjectiveCountThreshold = partialCompletionObjectiveCountThreshold;
            ShouldFireToast = shouldFireToast;
            ToastStyle = toastStyle;
        }
    }
}
