// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


namespace Bodoconsult.App.Helpers;

/// <summary>
/// Internal helper class for Wait.Until
/// </summary>
internal readonly struct WaitInternal
{

    private readonly Func<bool> _predicate;
    private readonly CancellationToken _token;

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="token">Current cancellation token</param>
    /// <param name="predicate">Current condition to check</param>
    public WaitInternal(CancellationToken token, Func<bool> predicate)
    {
        _predicate = predicate;
        _token = token;
    }

    /// <summary>
    /// Check the condition as long as it is false or no timeout has happened
    /// </summary>
    public void CheckCondition()
    {
        while (true)
        {
            if (_predicate() || _token.IsCancellationRequested)
            {
                return;
            }

            AsyncHelper.Delay(5, _token);
        }
    }
}