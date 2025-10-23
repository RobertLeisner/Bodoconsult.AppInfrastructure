// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.PlainText;

/// <summary>
/// Text rendering element for <see cref="SectionTitle"/> instances
/// </summary>
public class SectionTitlePlainTextRendererElement : ParagraphBasePlainTextRendererElement
{
   

    /// <summary>
    /// Default ctor
    /// </summary>
    public SectionTitlePlainTextRendererElement(SectionTitle sectionTitle)
    {
        Paragraph = sectionTitle;
    }

}