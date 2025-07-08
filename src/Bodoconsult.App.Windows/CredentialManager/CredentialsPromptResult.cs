// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

// Copyright (c) 2020 Widauer Patrick. All rights reserved.

using System.Security;

namespace Bodoconsult.App.Windows.CredentialManager;

public class CredentialsPromptResult
{
    internal static readonly CredentialsPromptResult CancelledResult = new(true, string.Empty, string.Empty, new SecureString(), false);

    public bool Cancelled { get; }

    public string Domain { get; }

    public string Username { get; }

    public SecureString Password { get; }

    public bool Save { get; }

    public CredentialsPromptResult (bool cancelled, string domain, string username, SecureString password, bool save)
    {
        Cancelled = cancelled;
        Domain = domain;
        Username = username;
        Password = password;
        Save = save;
    }
}