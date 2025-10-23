// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="ParagraphStyle"/> instances
/// </summary>
public class ParagraphStyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphStyle _paragraphStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ParagraphStyleWpfTextRendererElement(ParagraphStyle paragraphStyle) : base(paragraphStyle)
    {
        _paragraphStyle = paragraphStyle;
        ClassName = "ParagraphStyle";
    }
}