// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="ParagraphStyleBase"/> instances
/// </summary>
public class ParagraphStyleBaseRtfTextRendererElement : RtfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphStyleBase _paragraphStyleBase;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ParagraphStyleBaseRtfTextRendererElement(ParagraphStyleBase paragraphStyleBase) : base(paragraphStyleBase)
    {
        _paragraphStyleBase = paragraphStyleBase;
        ClassName = "ParagraphStyleBase";
    }
}