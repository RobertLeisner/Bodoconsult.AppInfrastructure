// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

// Copyright (c) 2020 Widauer Patrick. All rights reserved.

namespace Bodoconsult.App.CredentialManager.Win32.Types;

internal enum CredentialType
{
    Generic = 1,
    DomainPassword = 2,
    DomainCertificate = 3,
    DomainVisiblePassword = 4,
    GenericCertificate = 5,
    DomainExtended = 6
}