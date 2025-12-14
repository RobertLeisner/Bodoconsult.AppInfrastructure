// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System.Diagnostics;
using System.IO;
using System.Reflection;
using NUnit.Framework;

namespace Bodoconsult.Drawing.Test.Helpers;

public static class TestHelper
{

    public static string TargetFolder = Path.GetTempPath();

    private static string _testFolder;

    /// <summary>
    /// Get the folder of the current test data
    /// </summary>
    /// <returns></returns>
    public static string GetTestDataFolder()
    {

        if (!string.IsNullOrEmpty(_testFolder))
        {
            return _testFolder;
        }

        var dir = new DirectoryInfo(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).Parent.Parent.Parent;

        _testFolder = Path.Combine(dir.FullName, "TestData");

        return _testFolder;
    }


    /// <summary>
    /// Start an app by file name
    /// </summary>
    /// <param name="fileName"></param>
    public static void StartFile(string fileName)
    {

        if (!Debugger.IsAttached) return;

        Assert.That(File.Exists(fileName));

        var p = new Process { StartInfo = new ProcessStartInfo { UseShellExecute = true, FileName = fileName } };

        p.Start();

    }
}