// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System;
using System.Collections.Generic;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using DocumentFormat.OpenXml;

namespace Bodoconsult.Text.Renderer.Docx.Blocks;

/// <summary>
/// Base renderer implementation for HTML elements
/// </summary>
public abstract class ParagraphDocxTextRendererElementBase : DocxTextRendererElementBase
{
    private readonly ParagraphBase _paragraphBase;

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="block">Current block</param>
    protected ParagraphDocxTextRendererElementBase(Block block) : base(block)
    {
        if (block is not ParagraphBase paragraphBase)
        {
            throw new NotSupportedException($"block is {block.GetType().Name} not implementing ParagraphBase");
        }
        _paragraphBase = paragraphBase;
    }

    /// <summary>
    /// Current paragraph to render in
    /// </summary>
    public Paragraph Paragraph { get; set; }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(DocxTextDocumentRenderer renderer)
    {
        var styleName = _paragraphBase.StyleName.Replace("Style", string.Empty);

        if (styleName == "Paragraph")
        {
            styleName = "Normal";
        }

        //Debug.Print(styleName);

        var childs = new List<Inline>();

        if (string.IsNullOrEmpty(_paragraphBase.CurrentPrefix))
        {
            childs.Add(new Span(_paragraphBase.CurrentPrefix));
        }

        childs.AddRange(_paragraphBase.ChildInlines);

        var runs = new List<OpenXmlElement>();

        DocxDocumentRendererHelper.RenderBlockInlinesToRunsForDocx(renderer, childs, runs);
        renderer.DocxDocument.AddParagraph(runs, styleName);
    }

}