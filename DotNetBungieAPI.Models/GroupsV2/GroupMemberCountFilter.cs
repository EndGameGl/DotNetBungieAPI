namespace DotNetBungieAPI.Models.GroupsV2;

public enum GroupMemberCountFilter : int
{
    All = 0,

    OneToTen = 1,

    ElevenToOneHundred = 2,

    GreaterThanOneHundred = 3
}
