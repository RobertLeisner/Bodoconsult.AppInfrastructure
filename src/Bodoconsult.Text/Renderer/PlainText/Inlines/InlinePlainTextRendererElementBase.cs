// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System;
using System.Text;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.PlainText;

/// <summary>
/// Base class to render <see cref="Inline"/> elements
/// </summary>
public class InlinePlainTextRendererElementBase : ITextRendererElement
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
    /// Render the inline element to string
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    /// <param name="sb">String to add the inline element rendered</param>
    public virtual void RenderToString(ITextDocumentRenderer renderer, StringBuilder sb)
    {
        throw new NotSupportedException("Override method RenderToString() in derived subclasses");
    }
}