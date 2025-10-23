// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.Html;

/// <summary>
/// Current implementation of <see cref="IDocumentRendererFactory"/> for HTML rendering
/// </summary>
public class HtmlDocumentRendererFactory : IDocumentRendererFactory
{
    /// <summary>
    /// Create an <see cref="IDocumentRenderer"/> instance
    /// </summary>
    /// <param name="document">Current document to render</param>
    /// <returns>Renderer instance</returns>
    public IDocumentRenderer CreateInstance(Document document)
    {
        var elementfactory = new HtmlTextRendererElementFactory();
        var renderer = new HtmlTextDocumentRenderer(document, elementfactory);
        return renderer;
    }
}