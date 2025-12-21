// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Blocks;

/// <summary>
/// Docx rendering element for <see cref="Warning"/> instances
/// </summary>
public class WarningDocxTextRendererElement : ParagraphDocxTextRendererElementBase
{
    private readonly Warning _warning;

    /// <summary>
    /// Default ctor
    /// </summary>
    public WarningDocxTextRendererElement(Warning warning) : base(warning)
    {
        _warning = warning;
        ClassName = warning.StyleName;
    }
}