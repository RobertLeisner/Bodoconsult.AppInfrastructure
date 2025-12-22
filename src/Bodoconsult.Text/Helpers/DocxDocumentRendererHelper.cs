// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Renderer.Docx;
using Bodoconsult.Text.Renderer.Docx.Inlines;
using DocumentFormat.OpenXml;
using System.Collections.Generic;

namespace Bodoconsult.Text.Helpers;

/// <summary>
/// Helper class for DOCX rendering
/// </summary>
public static class DocxDocumentRendererHelper
{
    /// <summary>
    /// Render inlines to runs
    /// </summary>
    /// <param name="renderer">Current DOCX renderer</param>
    /// <param name="childInlines">Child inlines</param>
    /// <param name="runs">Current runs</param>
    public static void RenderBlockInlinesToRunsForDocx(DocxTextDocumentRenderer renderer, List<Documents.Inline> childInlines, List<OpenXmlElement> runs)
    {
        foreach (var inline in childInlines)
        {
            var item = (InlineDocxTextRendererElementBase)renderer.PdfTextRendererElementFactory.CreateInstanceDocx(inline);
            item.RenderToString(renderer, runs);
        }
    }

    /// <summary>
    /// Render child blocks to DOCX
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    /// <param name="childBlocks">Child blocks</param>
    public static void RenderBlockChildsToDocx(DocxTextDocumentRenderer renderer, ReadOnlyLdmlList<Block> childBlocks)
    {
        foreach (var block in childBlocks)
        {
            var item = renderer.PdfTextRendererElementFactory.CreateInstanceDocx(block);
            item.RenderIt(renderer);
        }
    }
}