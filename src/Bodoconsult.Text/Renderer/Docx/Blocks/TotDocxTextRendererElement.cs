// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Blocks;

/// <summary>
/// Docx rendering element for <see cref="Tot"/> instances
/// </summary>
public class TotDocxTextRendererElement : ParagraphDocxTextRendererElementBase
{
    private readonly Tot _tot;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TotDocxTextRendererElement(Tot tot) : base(tot)
    {
        _tot = tot;
        ClassName = tot.StyleName;
    }
}