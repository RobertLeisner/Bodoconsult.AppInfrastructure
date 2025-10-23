// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="CodeStyle"/> instances
/// </summary>
public class CodeStyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    private readonly CodeStyle _style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public CodeStyleWpfTextRendererElement(CodeStyle style) : base(style)
    {
        _style = style;
        ClassName = "CodeStyle";
    }
}