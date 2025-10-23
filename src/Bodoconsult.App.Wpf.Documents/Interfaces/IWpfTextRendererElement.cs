// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Wpf.Documents.Renderer;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.App.Wpf.Documents.Interfaces;

/// <summary>
/// Interface for text rendering elements
/// </summary>
public interface IWpfTextRendererElement: ITextRendererElement
{
    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    void RenderIt(WpfTextDocumentRenderer renderer);
}