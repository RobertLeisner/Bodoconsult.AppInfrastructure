// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System.Diagnostics;
using Bodoconsult.App.Helpers;

namespace Bodoconsult.Office.Tests.Helpers;

public static class FileHelper
{

    public static string TempPath { get; set; } = System.IO.Path.GetTempPath();

    public static void StartExcel(string path)
    {
        FileSystemHelper.RunInDebugMode(path);
    }
}