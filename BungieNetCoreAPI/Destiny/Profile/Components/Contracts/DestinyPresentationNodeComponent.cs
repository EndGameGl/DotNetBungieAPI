using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyPresentationNodeComponent
    {
        public DestinyPresentationNodeState State { get; init; }
        public DestinyObjectiveProgress Objective { get; init; }
        public int ProgressValue { get; init; }
        public int CompletionValue { get; init; }
        public int? RecordCategoryScore { get; init; }

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
