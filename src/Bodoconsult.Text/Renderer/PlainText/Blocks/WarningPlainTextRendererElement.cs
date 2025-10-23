// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.PlainText;

/// <summary>
/// Text rendering element for <see cref="Warning"/> instances
/// </summary>
public class WarningPlainTextRendererElement : ParagraphBasePlainTextRendererElement
{


    /// <summary>
    /// Default ctor
    /// </summary>
    public WarningPlainTextRendererElement(Warning warning)
    {
        Paragraph= warning;
        LeftRightBorderChar = "?";
        TopBottomBorderChar = "?";
    }
}