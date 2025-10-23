// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Interfaces;

/// <summary>
/// Interface for document renderer factories
/// </summary>
public interface IDocumentRendererFactory
{
    /// <summary>
    /// Create an <see cref="IDocumentRenderer"/> instance
    /// </summary>
    /// <param name="document">Current document to render</param>
    /// <returns>Renderer instance</returns>
    IDocumentRenderer CreateInstance(Document document);
}