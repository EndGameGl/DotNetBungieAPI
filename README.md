# .NetBungieAPI

This library was made to interact with Bungie.net API.
<br />
It's heavily WIP, but can already be used for analyzing data and stuff.

### Features:
 - Load any definition from API
 - Fluent API client settings
 - Check for newer versions and download them if needed
 - Load in manifest files into memory in repository class (LocalisedDestinyDefinitionRepositories)
 - All hashes are replaced with a DefinitionHashPointer<T> class, which describes where to look up it's data
 - DefinitionHashPointer<T> can load data from LocalisedDestinyDefinitionRepositories
 - All definition pointers can be premapped to save even more time
 - Can download images from bungie.net (seems pointless as for me)
 - Logger support to take a look of what's going inside
 - IBungieApiAccess interface for API methods
 - IDeepEquatable<T> interface is implemented on all definitions, so they can be compared
 - DatabaseComparer class can be used to compare 2 definition databases

### To do:
 - [ ] Still missing many API methods
 - [ ] OAuth2 support

### Where to start:
Fetch client as stated below: <br/>
```var client = BungieApiBuilder.GetApiClient(Action<BungieClientSettings> configure)``` <br/>
Then jump is async context and: <br/>
```await client.Run() ``` <br/>

## Methods done status

### App methods (2/2)

Name | Status
-----|-------
GetApplicationApiUsage | Done 
GetBungieApplications | Done 

### User methods (7/7)

Name | Status
-----|-------
GetBungieNetUserById | Done 
SearchUsers | Done 
GetCredentialTypesForTargetAccount | Done
GetAvailableThemes | Done
GetMembershipDataById | Done
GetMembershipDataForCurrentUser | Done
GetMembershipFromHardLinkedCredential | Done

### Content methods (6/6)

Name | Status
-----|-------
GetContentType | Done
GetContentById | Done
GetContentByTagAndType | Done
SearchContentWithText | Done
SearchContentByTagAndType | Done
SearchHelpArticles | Done

### Forum methods (10/10)

Name | Status
-----|-------
GetTopicsPaged | Done
GetCoreTopicsPaged | Done
GetPostsThreadedPaged | Done
GetPostsThreadedPagedFromChild | Done
GetPostAndParent | Done
GetPostAndParentAwaitingApproval | Done
GetTopicForContent | Done
GetForumTagSuggestions | Done
GetPoll | Done
GetRecruitmentThreadSummaries | Done

### GroupV2 methods

Name | Status
-----|-------
GetAvailableAvatars | Not done
GetAvailableThemes | Not done
GetUserClanInviteSetting | Not done
GetRecommendedGroups | Not done
GroupSearch | Not done
GetGroup | Not done
GetGroupByName | Not done
GetGroupByNameV2 | Not done
GetGroupOptionalConversations | Not done
EditGroup | Not done
EditClanBanner | Not done
EditFounderOptions | Not done
AddOptionalConversation | Not done
EditOptionalConversation | Not done
GetMembersOfGroup | Not done
GetAdminsAndFounderOfGroup | Not done
EditGroupMembership | Not done
KickMember | Not done
BanMember | Not done
UnbanMember | Not done
GetBannedMembersOfGroup | Not done
AbdicateFoundership | Not done
GetPendingMemberships | Not done
GetInvitedIndividuals | Not done
ApproveAllPending | Not done
DenyAllPending | Not done
ApprovePendingForList | Not done
ApprovePending | Not done
DenyPendingForList | Not done
GetGroupsForMember | Not done
RecoverGroupForFounder | Not done
GetPotentialGroupsForMember | Not done
IndividualGroupInvite | Not done
IndividualGroupInviteCancel | Not done
