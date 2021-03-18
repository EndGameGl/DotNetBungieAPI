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
### To access definitions repo: client.Repository
### To access api methods: client.ApiAccess
