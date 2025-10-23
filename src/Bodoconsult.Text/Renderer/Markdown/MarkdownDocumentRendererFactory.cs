//// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

//using Bodoconsult.Text.Documents;
//using Bodoconsult.Text.Interfaces;

//namespace Bodoconsult.Text.Renderer.Markdown;

///// <summary>
///// Current implementation of <see cref="IDocumentRendererFactory"/> for MarkDown rendering
///// </summary>
//public class MarkdownDocumentRendererFactory : IDocumentRendererFactory
//{
//    /// <summary>
//    /// Create an <see cref="IDocumentRenderer"/> instance
//    /// </summary>
//    /// <param name="document">Current document to render</param>
//    /// <returns>Renderer instance</returns>
//    public IDocumentRenderer CreateInstance(Document document)
//    {
//        var elementfactory = new MarkdownTextRendererElementFactory();
//        var renderer = new MarkdownTextDocumentRenderer(document, elementfactory);
//        return renderer;
//    }
//}