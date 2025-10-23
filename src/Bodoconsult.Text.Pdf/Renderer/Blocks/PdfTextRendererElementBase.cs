// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;
using Bodoconsult.Text.Pdf.Helpers;
using Bodoconsult.Text.Pdf.Interfaces;

namespace Bodoconsult.Text.Pdf.Renderer.Blocks;

/// <summary>
    /// Base renderer implementation for HTML elements
    /// </summary>
    public abstract class PdfTextRendererElementBase : IPdfTextRendererElement
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
    protected PdfTextRendererElementBase(Block block)
    {
        Block = block;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public virtual void RenderIt(PdfTextDocumentRenderer renderer)
    {
        PdfDocumentRendererHelper.RenderBlockChildsToPdf(renderer, Block.ChildBlocks);
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public void RenderIt(ITextDocumentRenderer renderer)
    {
        throw new NotSupportedException();
    }
}