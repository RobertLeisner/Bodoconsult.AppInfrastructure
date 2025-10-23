// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.PlainText;

/// <summary>
/// Plain text rendering element for <see cref="Styleset"/> instances
/// </summary>
public class StylesetPlainTextRendererElement : ITextRendererElement
{
    private readonly Styleset _styleset;

    /// <summary>
    /// Default ctor
    /// </summary>
    public StylesetPlainTextRendererElement(Styleset styleset)
    {
        _styleset = styleset;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public void RenderIt(ITextDocumentRenderer renderer)
    {
        // Do nothing
    }
}