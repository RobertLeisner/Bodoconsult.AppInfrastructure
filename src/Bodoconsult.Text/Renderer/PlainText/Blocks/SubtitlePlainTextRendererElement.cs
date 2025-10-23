// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.PlainText;

/// <summary>
/// Text rendering element for <see cref="Subtitle"/> instances
/// </summary>
public class SubtitlePlainTextRendererElement : ParagraphBasePlainTextRendererElement
{

    /// <summary>
    /// Default ctor
    /// </summary>
    public SubtitlePlainTextRendererElement(Subtitle subtitle)
    {
        Paragraph = subtitle;
        
    }
}