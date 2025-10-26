// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Wpf.Documents.Interfaces;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;
using TextElement = System.Windows.Documents.TextElement;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Inlines;

/// <summary>
/// Base class to render <see cref="Inline"/> elements to HTML
/// </summary>
public class InlineWpfTextRendererElementBase : IWpfTextRendererElement
{
    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public void RenderIt(ITextDocumentRenderer renderer)
    {
        // do nothing
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    /// <exception cref="NotImplementedException"></exception>
    public void RenderIt(WpfTextDocumentRenderer renderer)
    {
        throw new NotSupportedException("Override method RenderToString() in derived subclasses");
    }

    /// <summary>
    /// Render the inline to a string
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    /// <param name="element">Base text element</param>
    /// <param name="childInlines">Child inlines of an inline</param>
    /// <exception cref="NotSupportedException"></exception>
    public virtual void RenderToElement(WpfTextDocumentRenderer renderer, TextElement element, List<Inline> childInlines)
    {
        throw new NotSupportedException("Override method RenderToElement() in derived subclasses");
    }
}