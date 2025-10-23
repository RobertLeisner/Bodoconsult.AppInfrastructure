// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System;
using System.Collections.Generic;
using System.Text;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Pdf.Helpers;
using Paragraph = MigraDoc.DocumentObjectModel.Paragraph;

namespace Bodoconsult.Text.Pdf.Renderer.Blocks;

/// <summary>
/// Base renderer implementation for HTML elements
/// </summary>
public abstract class ParagraphPdfTextRendererElementBase : PdfTextRendererElementBase
{
    private readonly ParagraphBase _paragraphBase;

    /// <summary>
    /// Content of the paragraph to render
    /// </summary>
    protected StringBuilder Content = new();

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="block">Current block</param>
    protected ParagraphPdfTextRendererElementBase(Block block) : base(block)
    {
        if (Block is ParagraphBase paragraphBase)
        {
            _paragraphBase = paragraphBase;
            return;
        }

        throw new NotSupportedException($"block is {block.GetType().Name}");
    }

    /// <summary>
    /// Current paragraph to render in
    /// </summary>
    public Paragraph Paragraph { get; set; }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(PdfTextDocumentRenderer renderer)
    {
        var childs = new List<Inline>();

        if (string.IsNullOrEmpty(_paragraphBase.CurrentPrefix))
        {
            childs.Add(new Span(_paragraphBase.CurrentPrefix));
        }

        childs.AddRange(_paragraphBase.ChildInlines);

        PdfDocumentRendererHelper.RenderBlockInlinesToStringForPdf(renderer, childs, Content);
    }

}