// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html;

/// <summary>
/// HTML rendering element for <see cref="Code"/> instances
/// </summary>
public class CodeHtmlTextRendererElement : HtmlTextRendererElementBase
{
    private readonly Code _code;

    /// <summary>
    /// Default ctor
    /// </summary>
    public CodeHtmlTextRendererElement(Code code) : base(code)
    {
        _code = code;
        ClassName = code.StyleName;
    }
}