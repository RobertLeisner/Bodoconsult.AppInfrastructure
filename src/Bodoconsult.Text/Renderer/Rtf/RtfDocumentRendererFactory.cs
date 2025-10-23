// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.Rtf;

/// <summary>
/// Current implementation of <see cref="IDocumentRendererFactory"/> for plain text rendering
/// </summary>
public class RtfDocumentRendererFactory : IDocumentRendererFactory
{
    /// <summary>
    /// Create an <see cref="IDocumentRenderer"/> instance
    /// </summary>
    /// <param name="document">Current document to render</param>
    /// <returns>Renderer instance</returns>
    public IDocumentRenderer CreateInstance(Document document)
    {
        var elementfactory = new RtfTextRendererElementFactory();
        var renderer = new RtfTextDocumentRenderer(document, elementfactory);
        return renderer;
    }
}