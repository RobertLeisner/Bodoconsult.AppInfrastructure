// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="ParagraphStyleBase"/> instances
/// </summary>
public class ParagraphStyleBaseWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphStyleBase _paragraphStyleBase;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ParagraphStyleBaseWpfTextRendererElement(ParagraphStyleBase paragraphStyleBase) : base(paragraphStyleBase)
    {
        _paragraphStyleBase = paragraphStyleBase;
        ClassName = "ParagraphStyleBase";
    }
}