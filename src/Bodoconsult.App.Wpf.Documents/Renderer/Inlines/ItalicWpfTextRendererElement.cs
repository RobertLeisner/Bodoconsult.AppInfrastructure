// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Wpf.Documents.Renderer;
using Bodoconsult.Text.Documents;

using System.Text;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Inlines;

/// <summary>
/// Render a <see cref="Italic"/> element
/// </summary>
public class ItalicWpfTextRendererElement : InlineWpfTextRendererElementBase
{
    private readonly Italic _span;

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="span">Paragraph</param>
    public ItalicWpfTextRendererElement(Italic span)
    {
        _span = span;
    }

    /// <summary>
    /// Render the inline to a string
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    /// <param name="sb">String</param>
    public override void RenderToString(WpfTextDocumentRenderer renderer, StringBuilder sb)
    {
        sb.Append(renderer.CheckContent(_span.Content));
    }
}