// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Text;
using Bodoconsult.App.Wpf.Documents.Renderer;
using Bodoconsult.Text.Documents;


namespace Bodoconsult.App.Wpf.Documents.Renderer.Inlines;

/// <summary>
/// Render a <see cref="Bold"/> element
/// </summary>
public class BoldWpfTextRendererElement : InlineWpfTextRendererElementBase
{
    private readonly Bold _span;

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="span">Paragraph</param>
    public BoldWpfTextRendererElement(Bold span)
    {
        _span = span;
    }


    ///// <summary>
    ///// Render the inline element to string
    ///// </summary>
    ///// <param name="renderer">Current renderer</param>
    ///// <param name="paragraph">Paragraph to render the inline into</param>
    //public override void RenderIt(WpfTextDocumentRenderer renderer, MigraDoc.DocumentObjectModel.Paragraph paragraph)
    //{
    //    paragraph.AddFormattedText(_span.Content, TextFormat.Bold);
    //}

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