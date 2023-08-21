using DotNetBungieAPI.Models.Exceptions;

namespace DotNetBungieAPI.Models.Authorization;

/// <summary>
///     Lets you perform authentication asynchronously
/// </summary>
public class AsyncAuthorizationState
{
    /// <summary>
    ///     State that will be compared against received data to ensure that result is valid
    /// </summary>
    public string State { get; private set; }

    /// <summary>
    ///     Code received from authentication process at bungie.net
    /// </summary>
    public string? Code { get; private set; }

    private readonly TaskCompletionSource _tcs;

    private AsyncAuthorizationState() 
    {
        _tcs = new TaskCompletionSource();
    }

    /// <summary>
    ///     Asynchronously waits until code is received via <code>AsyncAuthenticationState.ReceiveCode(code, state)</code>
    /// </summary>
    /// <returns></returns>
    public Task WaitForAuthorization()
    {
        return _tcs.Task;
    }

    /// <summary>
    ///     Completes wait and validates authentication results
    /// </summary>
    /// <param name="code"></param>
    /// <param name="state"></param>
    /// <exception cref="Exception"></exception>
    public void ReceiveCode(string code, string state)
    {
        if (State != state)
        {
            var error = new AuthenticationStateMismatchException(State, state);
            _tcs.SetException(error);
            throw error;
        }
        Code = code;
        _tcs.SetResult();
    }

    /// <summary>
    ///     Creates new authentication awaiter with provided state
    /// </summary>
    /// <param name="state">State for authentication process</param>
    /// <returns></returns>
    public static AsyncAuthorizationState CreateAsyncAuthorizationAwaiter(string state)
    {
        return new AsyncAuthorizationState()
        {
            State = state,
        };
    }
}
