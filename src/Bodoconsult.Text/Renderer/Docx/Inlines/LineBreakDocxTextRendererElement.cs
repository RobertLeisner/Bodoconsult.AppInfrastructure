// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Office;
using Bodoconsult.Text.Documents;
using DocumentFormat.OpenXml;
using System;
using System.Collections.Generic;

namespace Bodoconsult.Text.Renderer.Docx.Inlines;

/// <summary>
/// Render a <see cref="LineBreak"/> element
/// </summary>
public class LineBreakDocxTextRendererElement : InlineDocxTextRendererElementBase
{
    private readonly LineBreak _span;

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="span">Paragraph</param>
    public LineBreakDocxTextRendererElement(LineBreak span)
    {
        _span = span;
    }

    /// <summary>
    /// Render the inline to a run
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    /// <param name="runs">Current list of runs</param>
    /// <exception cref="NotSupportedException"></exception>
    public override void RenderToString(DocxTextDocumentRenderer renderer, List<OpenXmlElement> runs)
    {
        var run = DocxBuilder.CreateLineBreak();
        runs.Add(run);
    }
}