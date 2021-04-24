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

### GroupV2 methods (17/33)

Name | Status
-----|-------
GetAvailableAvatars | Done
GetAvailableThemes | Done
GetUserClanInviteSetting | Done
GetRecommendedGroups | Done
GroupSearch | Done
GetGroup | Done
GetGroupByName | Done
GetGroupByNameV2 | Done
GetGroupOptionalConversations | Done
EditGroup | Done
EditClanBanner | Done
EditFounderOptions | Done
AddOptionalConversation | Done
EditOptionalConversation | Done
GetMembersOfGroup | Done
GetAdminsAndFounderOfGroup | Done
EditGroupMembership | Done
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

### Tokens methods (0/3)

Name | Status
-----|-------
ClaimPartnerOffer | Not done
ApplyMissingPartnerOffersWithoutClaim | Not done
GetPartnerOfferSkuHistory | Not done

### Destiny2 methods (22/36)

Name | Status
-----|-------
GetDestinyManifest | Done
GetDestinyEntityDefinition | Done
SearchDestinyPlayer | Done
GetLinkedProfiles | Done
GetProfile | Done
GetCharacter | Done
GetClanWeeklyRewardState | Done
GetItem | Done
GetVendors | Done
GetVendor | Done
GetPublicVendors (Preview) | Done
GetCollectibleNodeDetails | Done
TransferItem | Not done
PullFromPostmaster | Not done
EquipItem | Not done
EquipItems | Not done
SetItemLockState | Not done
SetQuestTrackedState | Not done
InsertSocketPlug (Preview) | Not done
GetPostGameCarnageReport | Done
ReportOffensivePostGameCarnageReportPlayer | Not done
GetHistoricalStatsDefinition | Done
GetClanLeaderboards (Preview) | Not done
GetClanAggregateStats (Preview) | Not done
GetLeaderboards (Preview) | Not done
GetLeaderboardsForCharacter (Preview) | Not done
SearchDestinyEntities | Done
GetHistoricalStats | Done
GetHistoricalStatsForAccount | Done
GetActivityHistory | Done
GetUniqueWeaponHistory | Done
GetDestinyAggregateActivityStats | Done
GetPublicMilestoneContent | Done
GetPublicMilestones | Done
AwaInitializeRequest | Not done
AwaProvideAuthorizationResult | Not done
AwaGetActionToken | Not done

### CommunityContent methods (1/1)

Name | Status
-----|-------
GetCommunityContent | Done

### Trending methods (3/3)

Name | Status
-----|-------
GetTrendingCategories | Done
GetTrendingCategory | Done
GetTrendingEntryDetail | Done

### Fireteam methods (5/5)

Name | Status
-----|-------
GetActivePrivateClanFireteamCount | Done
GetAvailableClanFireteams | Done
SearchPublicAvailableClanFireteams | Done
GetMyClanFireteams | Done
GetClanFireteam | Done

### Misc methods (4/4)

Name | Status
-----|-------
GetAvailableLocales | Done
GetCommonSettings | Done
GetUserSystemOverrides | Done
GetGlobalAlerts | Done
