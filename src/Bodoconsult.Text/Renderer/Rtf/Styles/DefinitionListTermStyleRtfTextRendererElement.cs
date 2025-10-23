// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="DefinitionListTermStyle"/> instances
/// </summary>
public class DefinitionListTermStyleRtfTextRendererElement : RtfParagraphStyleTextRendererElementBase
{
    private readonly DefinitionListTermStyle _style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public DefinitionListTermStyleRtfTextRendererElement(DefinitionListTermStyle style) : base(style)
    {
        _style = style;
        ClassName = "DefinitionListTermStyle";
    }
}