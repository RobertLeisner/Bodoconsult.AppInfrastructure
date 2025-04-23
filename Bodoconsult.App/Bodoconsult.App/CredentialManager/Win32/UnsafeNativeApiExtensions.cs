// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

// Copyright (c) 2020 Widauer Patrick. All rights reserved.

using Bodoconsult.App.CredentialManager.Win32.Types;

namespace Bodoconsult.App.CredentialManager.Win32;

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
        return type switch
        {
            CredentialType.Generic => Types.CredentialType.Generic,
            _ => throw new ArgumentOutOfRangeException (nameof(type), type, null)
        };
    }
}