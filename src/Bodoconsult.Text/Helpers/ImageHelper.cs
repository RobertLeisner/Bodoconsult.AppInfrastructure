// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.IO;

namespace Bodoconsult.Text.Helpers;

/// <summary>
/// Helper class to handle bitmap images
/// </summary>
public static class ImageHelper
{
    /// <summary>
    /// Get byte of a local image or a web image
    /// </summary>
    /// <param name="uri">Local path or web Uri</param>
    /// <returns>Byte array of the image</returns>
    public static byte[] GetBytes(string uri)
    {
        // ToDo: Download from web 
        return File.ReadAllBytes(uri);
    }
}