// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.App.Extensions;

/// <summary>
/// Extensions for stream based classes
/// </summary>
public static class StreamExtensions
{
    /// <summary>
    /// Save a stream into a file
    /// </summary>
    /// <param name="stream">Stream to save as file</param>
    /// <param name="fileName">Full file name</param>
    public static void ToFile(this Stream stream, string fileName)
    {
        using var file = new FileStream(fileName, FileMode.Create, FileAccess.Write);
        stream.Position = 0;
        stream.CopyTo(file);
        stream.Close();
    }
}