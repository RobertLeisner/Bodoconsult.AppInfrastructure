// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Wpf.Documents.Helpers;
using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Blocks;

/// <summary>
/// WPF rendering element for <see cref="Styleset"/> instances
/// </summary>
public class StylesetWpfTextRendererElement : WpfTextRendererElementBase
{
    private readonly Styleset _styleset;

    /// <summary>
    /// Default ctor
    /// </summary>
    public StylesetWpfTextRendererElement(Styleset styleset) : base(styleset)
    {
        _styleset = styleset;
        ClassName = styleset.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(WpfTextDocumentRenderer renderer)
    {
        WpfDocumentRendererHelper.RenderBlockChildsToWpf(renderer, Block.ChildBlocks);
    }
}