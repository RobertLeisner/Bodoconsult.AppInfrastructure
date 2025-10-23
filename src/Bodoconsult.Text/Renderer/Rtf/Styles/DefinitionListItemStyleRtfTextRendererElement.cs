// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="DefinitionListItemStyle"/> instances
/// </summary>
public class DefinitionListItemStyleRtfTextRendererElement : RtfParagraphStyleTextRendererElementBase
{
    private readonly DefinitionListItemStyle _style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public DefinitionListItemStyleRtfTextRendererElement(DefinitionListItemStyle style) : base(style)
    {
        _style = style;
        ClassName = "DefinitionListItemStyle";
    }
}