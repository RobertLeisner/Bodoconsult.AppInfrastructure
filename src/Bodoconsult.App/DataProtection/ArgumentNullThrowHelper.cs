// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

namespace Bodoconsult.App.DataProtection;

public static class ArgumentNullThrowHelper
{
    public static void ThrowIfNullOrEmpty(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentNullException(nameof(value));
        }
    }

    public static void ThrowIfNull(object obj)
    {
        if (obj != null)
        {
            return;
        }
        throw new ArgumentNullException(nameof(obj));
    }
}