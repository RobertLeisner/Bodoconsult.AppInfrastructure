// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.PlainText;

/// <summary>
/// Text rendering element for <see cref="ParagraphJustify"/> instances
/// </summary>
public class ParagraphJustifyPlainTextRendererElement : ParagraphBasePlainTextRendererElement
{

    /// <summary>
    /// Default ctor
    /// </summary>
    public ParagraphJustifyPlainTextRendererElement(ParagraphJustify paragraphJustify)
    {
        Paragraph = paragraphJustify;
    }

}