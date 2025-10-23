// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for <see cref="Image"/> instances
/// </summary>
public class ImageStyle : ImageStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public ImageStyle()
    {
        TagToUse = "ImageStyle";
        Name = TagToUse;
    }
}