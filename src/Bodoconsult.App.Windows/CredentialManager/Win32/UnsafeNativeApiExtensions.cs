// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

// Copyright (c) 2020 Widauer Patrick. All rights reserved.

using System;
using Bodoconsult.App.Windows.CredentialManager.Win32.Types;
using CredentialType = Bodoconsult.App.Abstractions.Interfaces.CredentialType;

namespace Bodoconsult.App.Windows.CredentialManager.Win32;

internal static class UnsafeNativeApiExtensions
{
    public static CredentialPersist ConvertToApiEnum (this CredentialPersistence persistence)
    {
        return persistence switch
        {
            CredentialPersistence.Session => CredentialPersist.Session,
            CredentialPersistence.LocalMachine => CredentialPersist.LocalMachine,
            CredentialPersistence.Enterprise => CredentialPersist.Enterprise,
            _ => throw new ArgumentOutOfRangeException (nameof(persistence), persistence, null)
        };
    }

    public static CredentialPersistence ConvertToConsumerEnum (this CredentialPersist persistence)
    {
        return persistence switch
        {
            CredentialPersist.Session => CredentialPersistence.Session,
            CredentialPersist.LocalMachine => CredentialPersistence.LocalMachine,
            CredentialPersist.Enterprise => CredentialPersistence.Enterprise,
            _ => throw new ArgumentOutOfRangeException (nameof(persistence), persistence, null)
        };
    }

    public static Types.CredentialType ConvertToApiEnum (this CredentialType type)
    {
        return type.Id switch
        {
            0 => Types.CredentialType.Generic,
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }
}