// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="EquationStyle"/> instances
/// </summary>
public class EquationStyleRtfTextRendererElement : RtfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphStyleBase _equationStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public EquationStyleRtfTextRendererElement(EquationStyle equationStyle) : base(equationStyle)
    {
        _equationStyle = equationStyle;
        ClassName = "EquationStyle";
    }
}