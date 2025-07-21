﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System.IO;
using System.Reflection;

namespace Bodoconsult.I18N.Helpers;

/// <summary>
/// Helper class for file handling
/// </summary>
public static class FileHelper
{

    /// <summary>
    /// Get a text from a embedded resource file
    /// </summary>
    /// <param name="resourceName">resource name = file name</param>
    /// <returns></returns>
    public static string GetTextResource(string resourceName)
    {
        var ass = Assembly.GetCallingAssembly();
        return GetTextResource(ass, resourceName);
    }


    /// <summary>
    /// Get a text from an embedded resource file
    /// </summary>
    /// <param name="assembly">Assembly to load the resource from</param>
    /// <param name="resourceName">resource name = file name</param>
    /// <returns></returns>
    public static string GetTextResource(Assembly assembly, string resourceName)
    {
        var str = assembly.GetManifestResourceStream(resourceName);

        if (str == null) return null;

        string s;

        using (var file = new StreamReader(str))
        {
            s = file.ReadToEnd();
        }

        return s;
    }
}