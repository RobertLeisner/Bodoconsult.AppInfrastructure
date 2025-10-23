// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.PlainText;

/// <summary>
/// Text rendering element for <see cref="Title"/> instances
/// </summary>
public class TitlePlainTextRendererElement : ParagraphBasePlainTextRendererElement
{


    /// <summary>
    /// Default ctor
    /// </summary>
    public TitlePlainTextRendererElement(Title title)
    {
        Paragraph = title;
    }

    
}