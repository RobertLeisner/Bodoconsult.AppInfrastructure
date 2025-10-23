// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;
using PdfSharp.Fonts;

namespace Bodoconsult.Text.Pdf.Renderer;

/// <summary>
/// Current implementation of <see cref="IDocumentRendererFactory"/> for PDF rendering
/// </summary>
public class PdfDocumentRendererFactory : IDocumentRendererFactory
{
    private readonly IFontResolver _fontResolver;

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="fontResolver">Font resolver to use</param>
    public PdfDocumentRendererFactory(IFontResolver fontResolver)
    {
        _fontResolver = fontResolver;
    }

    /// <summary>
    /// Create an <see cref="IDocumentRenderer"/> instance
    /// </summary>
    /// <param name="document">Current document to render</param>
    /// <returns>Renderer instance</returns>
    public IDocumentRenderer CreateInstance(Document document)
    {
        var elementfactory = new PdfTextRendererElementFactory();
        var renderer = new PdfTextDocumentRenderer(document, elementfactory, _fontResolver);
        return renderer;
    }
}