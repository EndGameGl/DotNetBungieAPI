namespace DotNetBungieAPI.Models.Exceptions;

public class AuthenticationStateMismatchException : Exception
{
    public string RequiredState { get; }
    public string ProvidedState { get; }

    public AuthenticationStateMismatchException(
        string requiredState,
        string providedState) : base("Provided state doesn't match awaiter state")
    {
        RequiredState = requiredState;
        ProvidedState = providedState;
    }
}
