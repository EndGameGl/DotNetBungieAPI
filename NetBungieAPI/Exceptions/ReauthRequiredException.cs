using System;

namespace NetBungieAPI.Exceptions
{
    public class ReauthRequiredException : Exception
    {
        public long MembershipId { get; }

        public ReauthRequiredException(long membershipId) : base(
            $"Refresh token for membership id {membershipId} has expired")
        {
            MembershipId = membershipId;
        }
    }
}