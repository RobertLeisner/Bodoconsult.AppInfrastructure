// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Reflection;

namespace Bodoconsult.I18N.Test.Helpers
{
    internal static class TestHelper
    {
        public static Assembly CurrentAssembly { get; } = typeof(TestHelper).Assembly;
    }
}
