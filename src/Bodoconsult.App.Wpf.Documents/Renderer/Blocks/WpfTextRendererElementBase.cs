// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Wpf.Documents.Interfaces;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Blocks;

/// <summary>
    /// Base renderer implementation for WPF elements
    /// </summary>
    public abstract class WpfTextRendererElementBase : IWpfTextRendererElement
{
    /// <summary>
    /// Current block to renderer
    /// </summary>
    public Block Block { get; private set; }

    /// <summary>
    /// CSS class name
    /// </summary>
    public string ClassName { get; protected set; }

    /// <summary>
    /// CSS to be added to the local tag
    /// </summary>
    public string LocalCss { get; set; }

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="block">Current block</param>
    protected WpfTextRendererElementBase(Block block)
    {
        Block = block;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public virtual void RenderIt(WpfTextDocumentRenderer renderer)
    {
        //throw new NotSupportedException();
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public virtual void RenderIt(ITextDocumentRenderer renderer)
    {
        throw new NotSupportedException();
    }
}