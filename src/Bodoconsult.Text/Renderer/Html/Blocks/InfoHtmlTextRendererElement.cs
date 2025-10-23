// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html;

/// <summary>
/// HTML rendering element for <see cref="Info"/> instances
/// </summary>
public class InfoHtmlTextRendererElement : HtmlTextRendererElementBase
{
    private readonly Info _info;

    /// <summary>
    /// Default ctor
    /// </summary>
    public InfoHtmlTextRendererElement(Info info) : base(info)
    {
        _info = info;
        ClassName = info.StyleName;
    }
}