// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.PlainText;

/// <summary>
/// Text rendering element for <see cref="SectionSubtitle"/> instances
/// </summary>
public class SectionSubtitlePlainTextRendererElement : ParagraphBasePlainTextRendererElement
{

    /// <summary>
    /// Default ctor
    /// </summary>
    public SectionSubtitlePlainTextRendererElement(SectionSubtitle sectionSubtitle)
    {
        Paragraph = sectionSubtitle;
    }


}