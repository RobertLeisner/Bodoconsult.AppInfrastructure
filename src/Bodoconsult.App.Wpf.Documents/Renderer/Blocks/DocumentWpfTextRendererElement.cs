// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Wpf.Documents.Helpers;
using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Blocks;

/// <summary>
/// WPF rendering element for <see cref="Document"/> instances
/// </summary>
public class DocumentWpfTextRendererElement : WpfTextRendererElementBase
{
    private readonly Document _document;

    /// <summary>
    /// Default ctor
    /// </summary>
    public DocumentWpfTextRendererElement(Document document) : base(document)
    {
        _document = document;
        ClassName = document.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(WpfTextDocumentRenderer renderer)
    {
        WpfDocumentRendererHelper.RenderBlockChildsToWpf(renderer, _document.ChildBlocks);
    }
}