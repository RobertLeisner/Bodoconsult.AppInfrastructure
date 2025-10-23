// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Wpf.Documents.Renderer;
using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Blocks;

/// <summary>
/// WPF rendering element for <see cref="Paragraph"/> instances
/// </summary>
public class ParagraphWpfTextRendererElement : ParagraphWpfTextRendererElementBase
{
    private readonly Paragraph _paragraph;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ParagraphWpfTextRendererElement(Paragraph paragraph) : base(paragraph)
    {
        _paragraph = paragraph;
        ClassName = paragraph.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(WpfTextDocumentRenderer renderer)
    {

    }
}