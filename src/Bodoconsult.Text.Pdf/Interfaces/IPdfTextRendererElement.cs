// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Interfaces;
using Bodoconsult.Text.Pdf.Renderer;

namespace Bodoconsult.Text.Pdf.Interfaces;

/// <summary>
/// Interface for text rendering elements
/// </summary>
public interface IPdfTextRendererElement: ITextRendererElement
{
    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    void RenderIt(PdfTextDocumentRenderer renderer);
}