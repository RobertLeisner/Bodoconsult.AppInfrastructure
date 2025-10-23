// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.PlainText;

/// <summary>
/// Text rendering element for <see cref="ParagraphRight"/> instances
/// </summary>
public class ParagraphRightPlainTextRendererElement : ParagraphBasePlainTextRendererElement
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public ParagraphRightPlainTextRendererElement(ParagraphRight paragraphRight)
    {
        Paragraph = paragraphRight;
    }
}