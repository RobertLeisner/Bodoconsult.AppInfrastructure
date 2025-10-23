// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Wpf.Documents.Interfaces;
using Bodoconsult.App.Wpf.Documents.Renderer;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="DefinitionListStyle"/> instances
/// </summary>
public class DefinitionListStyleWpfTextRendererElement : IWpfTextRendererElement
{
    private readonly DefinitionListStyle _style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public DefinitionListStyleWpfTextRendererElement(DefinitionListStyle style)
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
    public void RenderIt(WpfTextDocumentRenderer renderer)
    {

    }
}