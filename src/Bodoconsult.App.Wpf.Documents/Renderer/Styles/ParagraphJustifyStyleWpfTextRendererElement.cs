// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="ParagraphJustifyStyle"/> instances
/// </summary>
public class ParagraphJustifyStyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphJustifyStyle _paragraphJustifyStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ParagraphJustifyStyleWpfTextRendererElement(ParagraphJustifyStyle paragraphJustifyStyle) : base(paragraphJustifyStyle)
    {
        _paragraphJustifyStyle = paragraphJustifyStyle;
        ClassName = "ParagraphJustifyStyle";
    }
}