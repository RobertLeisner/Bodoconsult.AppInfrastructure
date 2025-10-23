// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.PlainText;

/// <summary>
/// Text rendering element for <see cref="Heading3"/> instances
/// </summary>
public class Heading3PlainTextRendererElement : ParagraphBasePlainTextRendererElement
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public Heading3PlainTextRendererElement(Heading3 heading3)
    {
        Paragraph= heading3;
    }
}