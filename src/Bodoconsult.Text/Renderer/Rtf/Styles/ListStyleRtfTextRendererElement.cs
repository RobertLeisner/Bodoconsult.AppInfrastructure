// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="ListStyle"/> instances
/// </summary>
public class ListStyleRtfTextRendererElement : RtfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphStyleBase _listStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ListStyleRtfTextRendererElement(ListStyle listStyle) : base(listStyle)
    {
        _listStyle = listStyle;
        ClassName = "ListStyle";
    }
}