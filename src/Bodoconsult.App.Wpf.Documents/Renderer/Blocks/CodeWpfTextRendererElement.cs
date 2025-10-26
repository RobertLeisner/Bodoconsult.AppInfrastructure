// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Blocks;

/// <summary>
/// WPF rendering element for <see cref="Code"/> instances
/// </summary>
public class CodeWpfTextRendererElement : ParagraphWpfTextRendererElementBase
{
    private readonly Code _code;

    /// <summary>
    /// Default ctor
    /// </summary>
    public CodeWpfTextRendererElement(Code code) : base(code)
    {
        _code = code;
        ClassName = code.StyleName;
    }
}