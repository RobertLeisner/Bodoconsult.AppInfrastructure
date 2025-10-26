// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Wpf.Documents.Interfaces;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// Base class for styles
/// </summary>
public abstract class WpfStyleTextRendererElementBase : IWpfTextRendererElement
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
        throw new NotSupportedException();
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public void RenderIt(WpfTextDocumentRenderer renderer)
    {
        
    }
}