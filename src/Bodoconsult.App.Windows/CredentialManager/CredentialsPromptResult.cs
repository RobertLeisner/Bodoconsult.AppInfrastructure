// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

// Copyright (c) 2020 Widauer Patrick. All rights reserved.

using System.Security;

namespace Bodoconsult.App.Windows.CredentialManager;

/// <summary>
/// Result of a credential prompt
/// </summary>
public class CredentialsPromptResult
{
    
    internal static readonly CredentialsPromptResult CancelledResult = new(true, string.Empty, string.Empty, new SecureString(), false);

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="isCancelled">Was the prompt cancelled?</param>
    /// <param name="domain">Domain name</param>
    /// <param name="username">Username</param>
    /// <param name="password">Password</param>
    /// <param name="save">Save the result</param>
    public CredentialsPromptResult(bool isCancelled, string domain, string username, SecureString password, bool save)
    {
        IsCancelled = isCancelled;
        Domain = domain;
        Username = username;
        Password = password;
        Save = save;
    }

    /// <summary>
    /// Was the prompt cancelled?
    /// </summary>
    public bool IsCancelled { get; }

    /// <summary>
    /// Domain name
    /// </summary>
    public string Domain { get; }

    /// <summary>
    /// Username
    /// </summary>
    public string Username { get; }

    /// <summary>
    /// Password
    /// </summary>
    public SecureString Password { get; }

    /// <summary>
    /// Save the result
    /// </summary>
    public bool Save { get; }
}