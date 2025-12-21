// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Office;
using Bodoconsult.Text.Documents;
using DocumentFormat.OpenXml;
using System;
using System.Collections.Generic;
using System.Text;
using Paragraph = MigraDoc.DocumentObjectModel.Paragraph;

namespace Bodoconsult.Text.Renderer.Docx.Inlines;

/// <summary>
/// Render a <see cref="Value"/> element
/// </summary>
public class ValueDocxTextRendererElement : InlineDocxTextRendererElementBase
{
    private readonly Value _value;

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="value">Paragraph</param>
    public ValueDocxTextRendererElement(Value value)
    {
        _value = value;
    }

    /// <summary>
    /// Render the inline to a run
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    /// <param name="runs">Current list of runs</param>
    /// <exception cref="NotSupportedException"></exception>
    public override void RenderToString(DocxTextDocumentRenderer renderer, List<OpenXmlElement> runs)
    {
        var run = DocxBuilder.CreateRun(_value.Content);
        runs.Add(run);
    }
}