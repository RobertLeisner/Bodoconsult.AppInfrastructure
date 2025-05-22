﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

// Copyright (c) 2020 Widauer Patrick. All rights reserved.

using System.Security;
using Bodoconsult.App.CredentialManager;
using Bodoconsult.App.Extensions;

namespace Bodoconsult.App.Test.CredentialManager;

[TestFixture]
public class WindowsCredentialManagerTests
{

    private readonly WindowsCredentialManager _credentialManager;

    private const string TargetName = "CRED_TEST";

    public WindowsCredentialManagerTests()
    {
        _credentialManager = new WindowsCredentialManager();
    }

    public void TestSetup()
    {
        _credentialManager.Delete(TargetName);
    }

    [Test]
    public void Save_ValidCredentials_DoesNotThrow()
    {
        SaveCredentials();
    }

    private void SaveCredentials()
    {
        var genericCredentials = new WindowsCredentials(TargetName, CredentialType.Generic)
        {
            UserName = "my user",
            Password = new SecureString()
        };
        genericCredentials.Password.AppendChar('a');
        genericCredentials.Password.AppendChar('a');
        genericCredentials.Password.AppendChar('a');
        genericCredentials.Password.AppendChar('a');
        genericCredentials.Attributes.Add(new CredentialAttribute("a", "a1"));
        genericCredentials.Attributes.Add(new CredentialAttribute("b", ""));

        Assert.DoesNotThrow(() => { _credentialManager.Save(genericCredentials); });
    }

    [Test]
    public void Load_ValidCredentials_Success()
    {

        SaveCredentials();

        var genericCredentials = (WindowsCredentials)_credentialManager.Load(TargetName);

        Assert.That(genericCredentials.UserName, Is.EqualTo("my user"));
        Assert.That(genericCredentials.Password.SecureStringToString(), Is.EqualTo("aaaa"));

        Assert.That(genericCredentials.Attributes.Count, Is.EqualTo(2));
        Assert.That(genericCredentials.Attributes[0].Keyword, Is.EqualTo("a"));
        Assert.That(genericCredentials.Attributes[0].Value, Is.EqualTo("a1"));
        Assert.That(genericCredentials.Attributes[1].Keyword, Is.EqualTo("b"));
        Assert.That(genericCredentials.Attributes[1].Value, Is.EqualTo(""));
    }

    [Test]
    public void Delete_ExistingCredentials_Success()
    {
        SaveCredentials();

        Assert.That(_credentialManager.Delete(TargetName), Is.True);
    }

    [Explicit]
    [Test]
    public void PromptCredentials_DefaultSetup_DialogIsShown()
    {
        var credentialsPromptResult = CredentialsPrompt.ShowWithSaveButton("a", "b", true);

        Assert.That(credentialsPromptResult, Is.Not.Null);
    }
}