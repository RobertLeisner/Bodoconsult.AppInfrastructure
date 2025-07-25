// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bodoconsult.App.Wpf.Documents.Test.Helpers
{
    internal static class TestHelper
    {

        static TestHelper()
        {
            Assembly = typeof(TestHelper).Assembly;

            var fi = new FileInfo(Assembly.Location);

            TestDataPath = Path.Combine(fi.Directory.Parent.Parent.Parent.Parent.FullName, "TestData");

            TestChartImage = Path.Combine(TestDataPath, "chart3d.png");

            TestDistributionImage = Path.Combine(TestDataPath, "NormalDistribution.de.png");

            TestLogoImage = Path.Combine(TestDataPath, "logo.jpg");
        }

        /// <summary>
        /// Current assembly
        /// </summary>

        public static Assembly Assembly;

        /// <summary>
        /// Current test data path
        /// </summary>
        public static string TestDataPath { get; }


        public static string TestChartImage { get; }


        public static string TestDistributionImage { get; }

        public static string TestLogoImage { get; }



    }
}
