// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;
using DocumentFormat.OpenXml;
using System;
using System.Collections.Generic;
using Paragraph = Bodoconsult.Text.Documents.Paragraph;

namespace Bodoconsult.Text.Renderer.Docx.Inlines;

/// <summary>
/// Base class to render <see cref="Inline"/> elements to DOCX
/// </summary>
public class InlineDocxTextRendererElementBase : IDocxTextRendererElement
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
    public void RenderIt(DocxTextDocumentRenderer renderer)
    {
        throw new NotSupportedException("Override method RenderToString() in derived subclasses");
    }

    /// <summary>
    /// Render the inline element to string
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    /// <param name="paragraph">Paragraph to render the inline into</param>
    public virtual void RenderIt(DocxTextDocumentRenderer renderer, Paragraph paragraph)
    {
        // Not supported
    }

    /// <summary>
    /// Render the inline to a run
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    /// <param name="runs">Current list of runs</param>
    /// <exception cref="NotSupportedException"></exception>
    public virtual void RenderToString(DocxTextDocumentRenderer renderer, List<OpenXmlElement> runs)
    {
        throw new NotSupportedException("Override method RenderToString() in derived subclasses");
    }
}