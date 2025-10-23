// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.PlainText;

/// <summary>
/// Text rendering element for <see cref="Equation"/> instances
/// </summary>
public class EquationPlainTextRendererElement : ITextRendererElement
{
    private readonly Equation _equation;

    /// <summary>
    /// Default ctor
    /// </summary>
    public EquationPlainTextRendererElement(Equation equation)
    {
        _equation = equation;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    public void RenderIt(ITextDocumentRenderer renderer)
    {
        DocumentRendererHelper.CreateImagePlainText(renderer, _equation);
    }
}