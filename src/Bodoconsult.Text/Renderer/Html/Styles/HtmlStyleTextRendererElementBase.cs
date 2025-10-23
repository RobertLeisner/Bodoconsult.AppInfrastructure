// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// Base class for styles
/// </summary>
public abstract class HtmlStyleTextRendererElementBase : ITextRendererElement
{
    /// <summary>
    /// CSS class name
    /// </summary>
    public string ClassName { get; protected set; }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public virtual void RenderIt(ITextDocumentRenderer renderer)
    {
        // Do nothing
    }
}