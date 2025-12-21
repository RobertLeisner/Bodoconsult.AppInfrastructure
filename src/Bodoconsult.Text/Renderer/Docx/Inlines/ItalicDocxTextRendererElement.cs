// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Office;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using DocumentFormat.OpenXml;
using MigraDoc.DocumentObjectModel;
using System;
using System.Collections.Generic;
using System.Text;
using Paragraph = MigraDoc.DocumentObjectModel.Paragraph;

namespace Bodoconsult.Text.Renderer.Docx.Inlines;

/// <summary>
/// Render a <see cref="Italic"/> element
/// </summary>
public class ItalicDocxTextRendererElement : InlineDocxTextRendererElementBase
{
    private readonly Italic _span;

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="span">Paragraph</param>
    public ItalicDocxTextRendererElement(Italic span)
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
        // No childs
        if (_span.ChildInlines.Count == 0)
        {
            var run = DocxBuilder.CreateRunItalic(_span.Content);
            runs.Add(run);
        }
        else // Childs
        {
            List<OpenXmlElement> runs2 = new();

            foreach (var inline in _span.ChildInlines)
            {
                var item = (InlineDocxTextRendererElementBase)renderer.PdfTextRendererElementFactory.CreateInstanceDocx(inline);
                item.RenderToString(renderer, runs2);
            }

            var run = DocxBuilder.CreateRunItalic(runs2);
            runs.Add(run);
        }
    }
}