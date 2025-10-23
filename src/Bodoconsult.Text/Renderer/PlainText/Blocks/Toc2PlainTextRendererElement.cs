// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.PlainText;

/// <summary>
/// Text rendering element for <see cref="Toc2"/> instances
/// </summary>
public class Toc2PlainTextRendererElement : ParagraphBasePlainTextRendererElement
{
  

    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc2PlainTextRendererElement(Toc2 toc2)
    {
        Paragraph = toc2;
    }

    
}