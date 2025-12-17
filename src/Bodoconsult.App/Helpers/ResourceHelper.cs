// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System.Reflection;

namespace Bodoconsult.App.Helpers;

/// <summary>
/// Helper class to read text or SQL resources
/// </summary>
public static class ResourceHelper
{
    /// <summary>
    /// Get a text from an embedded resource file by its full resource name
    /// </summary>
    /// <param name="assembly">Assembly the resource to load from</param>
    /// <param name="resourceName">resource name = plain file name with extension and path</param>
    /// <returns></returns>
    public static string GetTextResource(Assembly assembly, string resourceName)
    {
        var str = assembly.GetManifestResourceStream(resourceName);

        if (str == null)
        {
            return null;
        }

        string s;

        using var file = new StreamReader(str);
        s = file.ReadToEnd();

        return s;
    }
}