// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="TableHeaderRightStyle"/> instances
/// </summary>
public class TableHeaderRightStyleRtfTextRendererElement : RtfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphStyleBase _style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TableHeaderRightStyleRtfTextRendererElement(TableHeaderRightStyle style) : base(style)
    {
        _style = style;
        ClassName = "TableHeaderStyle";
    }
}