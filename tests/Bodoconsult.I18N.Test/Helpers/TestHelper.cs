// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bodoconsult.I18N.Test.Helpers
{
    internal static class TestHelper
    {
        public static Assembly CurrentAssembly { get; } = typeof(TestHelper).Assembly;
    }
}
