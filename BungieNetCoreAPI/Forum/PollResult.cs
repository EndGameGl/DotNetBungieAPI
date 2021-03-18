using Newtonsoft.Json;
using System;

namespace NetBungieAPI.Forum
{
    public class PollResult
    {
        public string AnswerText { get; }
        public int AnswerSlot { get; }
        public DateTime LastVoteDate { get; }
        public int Votes { get; }
        public bool RequestingUserVoted { get; }

        [JsonConstructor]
        internal PollResult(string answerText, int answerSlot, DateTime lastVoteDate, int votes, bool requestingUserVoted)
        {
            AnswerText = answerText;
            AnswerSlot = answerSlot;
            LastVoteDate = lastVoteDate;
            Votes = votes;
            RequestingUserVoted = requestingUserVoted;
        }
    }
}
