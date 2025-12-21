// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Blocks;

/// <summary>
/// Docx rendering element for <see cref="Code"/> instances
/// </summary>
public class CodeDocxTextRendererElement : ParagraphDocxTextRendererElementBase
{
    private readonly Code _code;

    /// <summary>
    /// Default ctor
    /// </summary>
    public CodeDocxTextRendererElement(Code code) : base(code)
    {
        _code = code;
        ClassName = code.StyleName;
    }
}