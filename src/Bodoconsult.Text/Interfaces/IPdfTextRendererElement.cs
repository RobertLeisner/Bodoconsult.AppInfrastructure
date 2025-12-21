// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Renderer.Pdf;

namespace Bodoconsult.Text.Interfaces;

/// <summary>
/// Interface for PDF text rendering elements
/// </summary>
public interface IPdfTextRendererElement: ITextRendererElement
{
    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    void RenderIt(PdfTextDocumentRenderer renderer);
}