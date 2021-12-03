# DotNetBungieAPI

C# Wrapper for interacting with Bungie.net API, based of https://github.com/Bungie-net/api

### Features:
 - Can be easily plugged into any default DI container
 - All library services can be fully customised to the point of your own implementation
 - All hashes are converted to `DefinitionHashPointer{T}` class for strong typing
 - Implemented default services for handling most stuff

### Default services
 This library has 6 separate services to work with
 - `IAuthorizationHandler` - Handles work related to getting tokens from users
 - `IBungieNetJsonSerializer` - Custom object serialization (like hash pointers)
 - `IDefinitionProvider` - Handles definition access from external source (such as default provider: SqliteDefinitionProvider)
 - `IDestiny2DefinitionRepository` - Stores definitions in-memory for quick access
 - `IDotNetBungieApiHttpClient` - Handles HTTP API calls
 - `Microsoft.Extensions.Logging.ILogger` implementation - default logging solution for this library

### Where to start:
https://github.com/EndGameGl/DotNetBungieAPI/wiki/Basic-client-setup
