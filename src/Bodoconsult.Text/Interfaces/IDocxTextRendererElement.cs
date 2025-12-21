// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Renderer.Docx;

namespace Bodoconsult.Text.Interfaces;

/// <summary>
/// Interface for DOCX text rendering elements
/// </summary>
public interface IDocxTextRendererElement : ITextRendererElement
{
    /// <summary>
    /// Render the elxement
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    void RenderIt(DocxTextDocumentRenderer renderer);
}