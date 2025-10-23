// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// Base class for <see cref="PageStyleBase"/> based styles
/// </summary>
public abstract class HtmlPageStyleTextRendererElementBase : ITextRendererElement
{

    /// <summary>
    /// Current block to renderer
    /// </summary>
    public PageStyleBase Style { get; private set; }

    /// <summary>
    /// CSS class name
    /// </summary>
    public string ClassName { get; protected set; }

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="style">Current page style</param>
    protected HtmlPageStyleTextRendererElementBase(PageStyleBase style)
    {
        Style = style;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public virtual void RenderIt(ITextDocumentRenderer renderer)
    {
        // Do nothing
    }
}