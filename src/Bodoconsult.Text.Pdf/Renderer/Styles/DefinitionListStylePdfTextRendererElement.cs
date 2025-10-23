// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;
using Bodoconsult.Text.Pdf.Interfaces;

namespace Bodoconsult.Text.Pdf.Renderer.Styles;

/// <summary>
/// HTML rendering element for <see cref="DefinitionListStyle"/> instances
/// </summary>
public class DefinitionListStylePdfTextRendererElement : IPdfTextRendererElement
{
    private readonly DefinitionListStyle _style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public DefinitionListStylePdfTextRendererElement(DefinitionListStyle style)
    {
        _style = style;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public void RenderIt(ITextDocumentRenderer renderer)
    {

    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public void RenderIt(PdfTextDocumentRenderer renderer)
    {

    }
}