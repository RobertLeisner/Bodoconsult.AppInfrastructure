// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.Rtf.Blocks;

/// <summary>
/// Rtf rendering element for <see cref="Column"/> instances
/// </summary>
public class ColumnRtfTextRendererElement : ITextRendererElement
{
    private readonly Column _column;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ColumnRtfTextRendererElement(Column column)
    {
        _column = column;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public void RenderIt(ITextDocumentRenderer renderer)
    {
        
    }
}