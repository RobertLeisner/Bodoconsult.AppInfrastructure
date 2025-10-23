// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.PlainText;

/// <summary>
/// Text rendering element for <see cref="Figure"/> instances
/// </summary>
public class FigurePlainTextRendererElement : ITextRendererElement
{
    private readonly Figure _figure;

    /// <summary>
    /// Default ctor
    /// </summary>
    public FigurePlainTextRendererElement(Figure figure)
    {
        _figure = figure;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    public void RenderIt(ITextDocumentRenderer renderer)
    {
        DocumentRendererHelper.CreateImagePlainText(renderer, _figure);
    }
}