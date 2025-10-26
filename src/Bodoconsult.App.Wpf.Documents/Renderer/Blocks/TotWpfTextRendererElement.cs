// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Blocks;

/// <summary>
/// WPF rendering element for <see cref="Tot"/> instances
/// </summary>
public class TotWpfTextRendererElement : ParagraphWpfTextRendererElementBase
{
    private readonly Tot _tot;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TotWpfTextRendererElement(Tot tot) : base(tot)
    {
        _tot = tot;
        ClassName = tot.StyleName;
    }
}