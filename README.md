# BungieNetCoreAPI

This library was made to interact with Bungie.net API.
<br />
It's heavily WIP, but can already be used for analyzing data and stuff.

### Things to do:
 - [x] Load any definition from API
 - [x] Fluent API client settings.
 - [x] Ability to download manifest and files to disk
 - [x] Check for newer versions and download them if needed
 - [x] Load in manifest files into memory in repository class (LocalisedDestinyDefinitionRepositories).
 - [x] All hashes are replaced with a DefinitionHashPointer<T> class, which describes where to look up it's data.
 - [x] DefinitionHashPointer<T> can load data from LocalisedDestinyDefinitionRepositories.
 - [x] All definition pointers can be premapped to save even more time.
 - [x] Can download images from bungie.net (seems pointless as for me)
 - [x] Logger support to take a look of what's going inside.
 - [x] Most API GET methods (Destiny2 mostly).
 - [x] IDeepEquatable<T> interface is implemented on all definitions, so they can be compared.
 - [ ] Still missing many API methods.
 - [ ] Diff support to check what has changed in latest manifest versions.

### Usage example:
Create API client: <br />
`BungieClient _bungieClient = new BungieClient(Action<BungieClientSettings> configure);` <br />
Configure client inside of an action, at least add an API key.<br />
```
(settings) =>
{
    settings.IncludeApiKey("<your_key_goes_here>");    
}
```
Most settings are self-explanatory. <br />
After that you're supposed to run the client in async context, if any loading is neede (such as file reading, downloading, etc.) <br />
`await _bungieClient.Run();`
