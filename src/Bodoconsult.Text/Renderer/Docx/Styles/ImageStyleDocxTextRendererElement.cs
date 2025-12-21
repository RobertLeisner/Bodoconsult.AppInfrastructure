// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Styles;

/// <summary>
/// Docx rendering element for <see cref="ImageStyle"/> instances
/// </summary>
public class ImageStyleDocxTextRendererElement : DocxParagraphStyleTextRendererElementBase
{
    private readonly ImageStyle _imageStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ImageStyleDocxTextRendererElement(ImageStyle imageStyle) : base(imageStyle)
    {
        _imageStyle = imageStyle;
        ClassName = "ImageStyle";
    }
}