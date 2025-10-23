// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.App.Wpf.Documents.Renderer;

/// <summary>
/// Current implementation of <see cref="IDocumentRendererFactory"/> for WPF rendering
/// </summary>
public class WpfDocumentRendererFactory : IDocumentRendererFactory
{

    /// <summary>
    /// Default ctor
    /// </summary>
    public WpfDocumentRendererFactory()
    {

    }

    /// <summary>
    /// Create an <see cref="IDocumentRenderer"/> instance
    /// </summary>
    /// <param name="document">Current document to render</param>
    /// <returns>Renderer instance</returns>
    public IDocumentRenderer CreateInstance(Document document)
    {
        //var elementfactory = new WpfTextRendererElementFactory();
        //var renderer = new WpfTextDocumentRenderer(document, elementfactory, _fontResolver);
        //return renderer;
        throw new NotImplementedException();
    }
}