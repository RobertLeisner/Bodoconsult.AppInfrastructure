// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System;
using System.Text;
using Bodoconsult.App.Wpf.Documents.Interfaces;
using Bodoconsult.App.Wpf.Documents.Renderer;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;

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
    /// <param name="sb">String</param>
    /// <exception cref="NotSupportedException"></exception>
    public virtual void RenderToString(WpfTextDocumentRenderer renderer, StringBuilder sb)
    {
        throw new NotSupportedException("Override method RenderToString() in derived subclasses");
    }
}