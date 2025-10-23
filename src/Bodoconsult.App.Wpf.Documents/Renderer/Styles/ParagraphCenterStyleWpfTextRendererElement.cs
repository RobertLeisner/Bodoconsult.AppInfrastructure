// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="ParagraphCenterStyle"/> instances
/// </summary>
public class ParagraphCenterStyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphCenterStyle _paragraphCenterStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ParagraphCenterStyleWpfTextRendererElement(ParagraphCenterStyle paragraphCenterStyle) : base(paragraphCenterStyle)
    {
        _paragraphCenterStyle = paragraphCenterStyle;
        ClassName = "ParagraphCenterStyle";
    }
}