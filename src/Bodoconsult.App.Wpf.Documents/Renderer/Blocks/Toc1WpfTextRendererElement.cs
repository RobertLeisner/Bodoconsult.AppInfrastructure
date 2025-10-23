// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Wpf.Documents.Renderer;
using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Blocks;

/// <summary>
/// WPF rendering element for <see cref="Toc1"/> instances
/// </summary>
public class Toc1WpfTextRendererElement : ParagraphWpfTextRendererElementBase
{
    private readonly Toc1 _toc1;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc1WpfTextRendererElement(Toc1 toc1) : base(toc1)
    {
        _toc1 = toc1;
        ClassName = toc1.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(WpfTextDocumentRenderer renderer)
    {

    }
}

