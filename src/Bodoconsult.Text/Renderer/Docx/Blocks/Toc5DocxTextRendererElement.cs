// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Blocks;

/// <summary>
/// Docx rendering element for <see cref="Toc5"/> instances
/// </summary>
public class Toc5DocxTextRendererElement : ParagraphDocxTextRendererElementBase
{
    private readonly Toc5 _toc5;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc5DocxTextRendererElement(Toc5 toc5) : base(toc5)
    {
        _toc5 = toc5;
        ClassName = toc5.StyleName;
    }
}