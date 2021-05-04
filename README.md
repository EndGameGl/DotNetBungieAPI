# .NetBungieAPI

This library was made to interact with Bungie.net API.
<br />
It's more or less done and usable for data analysis and client-side usage (for example you can auth in Blazor app and use all methods)

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
 - OAuth2 token creation and storage
 - All API methods coverage

### To do:
 - [ ] I guess this just needs more in-depth testing

### Where to start:
Fetch client as stated below: <br/>
```var client = BungieApiBuilder.GetApiClient(Action<BungieClientSettings> configure)``` <br/>
Extension method allows to inject this client into any IServiceCollection: <br/>
``` UseBungieApiClient(this IServiceCollection services, Action<BungieClientSettings> configure) ``` <br/>
After that you can just use IBungieClient for anything you might need. <br/>
This project uses providers to load in data. Currently, it uses SqliteDefinitionProvider to get data.<br/>
In order to change that behaviour, you need to inherit DefinitionProvider class and override it in configuration process: <br/>
```UseDefinitionProvider(DefinitionProvider provider)``` <br/>
