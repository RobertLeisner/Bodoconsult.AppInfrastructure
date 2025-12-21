// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;
using PdfSharp.Fonts;

namespace Bodoconsult.Text.Renderer.Docx;

/// <summary>
/// Current implementation of <see cref="IDocumentRendererFactory"/> for DOCX rendering
/// </summary>
public class DocxDocumentRendererFactory : IDocumentRendererFactory
{
    /// <summary>
    /// Create an <see cref="IDocumentRenderer"/> instance
    /// </summary>
    /// <param name="document">Current document to render</param>
    /// <returns>Renderer instance</returns>
    public IDocumentRenderer CreateInstance(Document document)
    {
        var elementfactory = new DocxTextRendererElementFactory();
        var renderer = new DocxTextDocumentRenderer(document, elementfactory);
        return renderer;
    }
}