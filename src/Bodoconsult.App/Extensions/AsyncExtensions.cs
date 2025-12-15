// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Bodoconsult.App.Extensions;

// See https://gist.github.com/icanhasjonas/bdacabee5898f3ec91603945847a2e22

/// <summary>
/// Extensions for asny processing
/// </summary>
public static class AsyncExtensions
{
    /// <summary>
    /// Allows a cancellation token to be awaited.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static CancellationTokenAwaiter GetAwaiter(this CancellationToken ct)
    {
        // return our special awaiter
        return new CancellationTokenAwaiter
        {
            CancellationToken = ct
        };
    }

    /// <summary>
    /// The awaiter for cancellation tokens.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public struct CancellationTokenAwaiter : INotifyCompletion, ICriticalNotifyCompletion
    {

        /// <summary>
        /// Default ctor
        /// </summary>
        /// <param name="cancellationToken">Current cancellation token</param>
        public CancellationTokenAwaiter(CancellationToken cancellationToken)
        {
            CancellationToken = cancellationToken;
        }

        internal CancellationToken CancellationToken;

        /// <summary>
        /// Get the result
        /// </summary>
        /// <returns>nothing</returns>
        /// <exception cref="OperationCanceledException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public object GetResult()
        {
            // this is called by compiler generated methods when the
            // task has completed. Instead of returning a result, we 
            // just throw an exception.
            if (IsCompleted)
            {
                throw new OperationCanceledException();
            }

            throw new InvalidOperationException("The cancellation token has not yet been cancelled.");
        }

        /// <summary>
        /// called by compiler generated/.net internals to check if the task has completed
        /// </summary>
        public bool IsCompleted => CancellationToken.IsCancellationRequested;
        
        /// <summary>
        /// The compiler will generate stuff that hooks in here. We hook those methods directly into the // cancellation token
        /// </summary>
        /// <param name="continuation"></param>
        public void OnCompleted(Action continuation) => CancellationToken.Register(continuation);

        /// <summary>Schedules the continuation action that's invoked when the instance completes.</summary>
        /// <param name="continuation">The action to invoke when the operation completes.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="continuation" /> argument is null (Nothing in Visual Basic).</exception>
        public void UnsafeOnCompleted(Action continuation) =>
            CancellationToken.Register(continuation);
    }
}