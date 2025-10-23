// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="ParagraphRightStyle"/> instances
/// </summary>
public class ParagraphRightStyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphRightStyle _paragraphRightStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ParagraphRightStyleWpfTextRendererElement(ParagraphRightStyle paragraphRightStyle) : base(paragraphRightStyle)
    {
        _paragraphRightStyle = paragraphRightStyle;
        ClassName = "ParagraphRightStyle";
    }
}