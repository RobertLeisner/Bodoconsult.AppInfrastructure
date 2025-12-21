// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.Docx.Styles;

/// <summary>
/// Docx rendering element for <see cref="DefinitionListStyle"/> instances
/// </summary>
public class DefinitionListStyleDocxTextRendererElement : IDocxTextRendererElement
{
    private readonly DefinitionListStyle _style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public DefinitionListStyleDocxTextRendererElement(DefinitionListStyle style)
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
    public void RenderIt(DocxTextDocumentRenderer renderer)
    {

    }
}