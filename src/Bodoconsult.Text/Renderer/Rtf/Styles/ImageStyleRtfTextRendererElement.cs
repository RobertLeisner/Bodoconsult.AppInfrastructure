// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="ImageStyle"/> instances
/// </summary>
public class ImageStyleRtfTextRendererElement : RtfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphStyleBase _imageStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ImageStyleRtfTextRendererElement(ImageStyle imageStyle) : base(imageStyle)
    {
        _imageStyle = imageStyle;
        ClassName = "ImageStyle";
    }
}