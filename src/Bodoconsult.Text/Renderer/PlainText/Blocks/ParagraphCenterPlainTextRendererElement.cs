// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.PlainText;

/// <summary>
/// Text rendering element for <see cref="ParagraphCenter"/> instances
/// </summary>
public class ParagraphCenterPlainTextRendererElement : ParagraphBasePlainTextRendererElement
{

    /// <summary>
    /// Default ctor
    /// </summary>
    public ParagraphCenterPlainTextRendererElement(ParagraphCenter paragraphCenter)
    {
        Paragraph = paragraphCenter;
    }

}