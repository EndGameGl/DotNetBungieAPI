# DotNetBungieAPI

C# Wrapper for interacting with Bungie.net API, based of https://github.com/Bungie-net/api

### Features:
 - Can be easily plugged into any default DI container (e.g. `IServiceCollection`)
 - All library services can be fully customised to the point of your own implementation
 - All hashes references are converted to `DefinitionHashPointer{T}` class for strong typing
 - Implemented default services for handling most stuff, but `IDefinitionProvider` is up to you to choose.

### Default services
 This library has multiple services to work with:

| Service name                    | Service description                                                                         | Path                               |
|:--------------------------------|---------------------------------------------------------------------------------------------|------------------------------------|
| `IAuthorizationHandler`         | This service is used to handle OAuth2-related stuff                                         | `IBungieClient.Authorization`      |
| `IBungieApiAccess `             | This service is used to access https://www.bungie.net endpoints                             | `IBungieClient.ApiAccess`          |
| `IDefinitionProvider`           | This service is used to load Destiny 2 definitions and handle manifest updates              | `IBungieClient.DefinitionProvider` |
| `IDestiny2DefinitionRepository` | This service is used to store and use Destiny 2 definitions                                 | `IBungieClient.Repository`         |
| `IDestiny2ResetService`         | This service is used to calculate `DateTime` values for Destiny 2 weekly/daily resets       | `IBungieClient.ResetService`       |
| `IBungieNetJsonSerializer`      | This service is used to (de)serialize any json data related to this library                 | `IBungieClient.Serializer`         |
| `IDotNetBungieApiHttpClient`    | This service is used to access https://www.bungie.net directly, used by `IBungieApiAccess`  | `IBungieClient.ApiHttpClient`      |

Logging is supported and **SHOULD** be configured within default Microsoft approach with `IServiceCollection.AddLogging(...)`

### Where to start:
https://github.com/EndGameGl/DotNetBungieAPI/wiki/Basic-client-setup

### Is this getting used? 
Yes, this library is used by some public projects, such as:
 - https://tryfelicity.one/
 - https://marvin.gg/

This list will get updated as new projects use this library and I get to know that
