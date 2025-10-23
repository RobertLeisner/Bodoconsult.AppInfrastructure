// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="ListItemStyle"/> instances
/// </summary>
public class ListItemStyleRtfTextRendererElement : RtfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphStyleBase _listItemStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ListItemStyleRtfTextRendererElement(ListItemStyle listItemStyle) : base(listItemStyle)
    {
        _listItemStyle = listItemStyle;
        ClassName = "ListItemStyle";
    }
}