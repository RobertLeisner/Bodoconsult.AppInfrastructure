﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Wpf.Documents.Helpers;
using Bodoconsult.App.Wpf.Documents.Renderer;
using Bodoconsult.Text.Documents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;


namespace Bodoconsult.App.Wpf.Documents.Renderer.Blocks;

/// <summary>
/// Base renderer implementation for HTML elements
/// </summary>
public abstract class ParagraphWpfTextRendererElementBase : WpfTextRendererElementBase
{
    private readonly ParagraphBase _paragraphBase;

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="block">Current block</param>
    protected ParagraphWpfTextRendererElementBase(Block block) : base(block)
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
    public System.Windows.Documents.Paragraph Paragraph { get; set; }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(WpfTextDocumentRenderer renderer)
    {
        renderer.Dispatcher.Invoke(() =>
        {
            Paragraph = new System.Windows.Documents.Paragraph();
            var style = (Style)renderer.StyleSet[_paragraphBase.StyleName];
            Paragraph.Style = style;

            renderer.CurrentSection.Blocks.Add(Paragraph);

            var childs = new List<Inline>();

            if (string.IsNullOrEmpty(_paragraphBase.CurrentPrefix))
            {
                childs.Add(new Span(_paragraphBase.CurrentPrefix));
            }

            childs.AddRange(_paragraphBase.ChildInlines);

            WpfDocumentRendererHelper.RenderBlockInlinesToWpf(renderer, childs, Paragraph);
        });
    }

}