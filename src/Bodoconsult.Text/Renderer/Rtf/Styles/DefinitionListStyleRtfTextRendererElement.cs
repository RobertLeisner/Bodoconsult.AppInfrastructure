// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="DefinitionListStyle"/> instances
/// </summary>
public class DefinitionListStyleRtfTextRendererElement : ITextRendererElement
{
    private readonly DefinitionListStyle _style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public DefinitionListStyleRtfTextRendererElement(DefinitionListStyle style)
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
}