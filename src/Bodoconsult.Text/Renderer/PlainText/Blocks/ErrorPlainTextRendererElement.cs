// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.PlainText;

/// <summary>
/// Text rendering element for <see cref="Error"/> instances
/// </summary>
public class ErrorPlainTextRendererElement : ParagraphBasePlainTextRendererElement
{

    /// <summary>
    /// Default ctor
    /// </summary>
    public ErrorPlainTextRendererElement(Error error)
    {
        Paragraph = error;
        LeftRightBorderChar = "!";
        TopBottomBorderChar = "!";
    }
}