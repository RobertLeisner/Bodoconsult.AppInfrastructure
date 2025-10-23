// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.PlainText;

/// <summary>
/// Current implementation of <see cref="IDocumentRendererFactory"/> for plain text rendering
/// </summary>
public class PlainTextDocumentRendererFactory : IDocumentRendererFactory
{
    /// <summary>
    /// Create an <see cref="IDocumentRenderer"/> instance
    /// </summary>
    /// <param name="document">Current document to render</param>
    /// <returns>Renderer instance</returns>
    public IDocumentRenderer CreateInstance(Document document)
    {
        var elementfactory = new PlainTextRendererElementFactory();
        var renderer = new PlainTextDocumentRenderer(document, elementfactory);
        return renderer;
    }
}