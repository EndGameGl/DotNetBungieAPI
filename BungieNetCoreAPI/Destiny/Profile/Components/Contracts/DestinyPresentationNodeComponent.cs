using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Profile.Components.Contracts
{
    public class DestinyPresentationNodeComponent
    {
        public DestinyPresentationNodeState State { get; }
        public DestinyObjectiveProgress Objective { get; }
        public int ProgressValue { get; }
        public int CompletionValue { get; }
        public int? RecordCategoryScore { get; }

        [JsonConstructor]
        internal DestinyPresentationNodeComponent(DestinyPresentationNodeState state, DestinyObjectiveProgress objective, int progressValue, int completionValue,
            int? recordCategoryScore)
        {
            State = state;
            Objective = objective;
            ProgressValue = progressValue;
            CompletionValue = completionValue;
            RecordCategoryScore = recordCategoryScore;
        }
    }
}
