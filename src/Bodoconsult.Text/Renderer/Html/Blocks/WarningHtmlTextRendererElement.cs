// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html;

/// <summary>
/// HTML rendering element for <see cref="Warning"/> instances
/// </summary>
public class WarningHtmlTextRendererElement : HtmlTextRendererElementBase
{
    private readonly Warning _warning;

    /// <summary>
    /// Default ctor
    /// </summary>
    public WarningHtmlTextRendererElement(Warning warning) : base(warning)
    {
        _warning = warning;
        ClassName = warning.StyleName;
    }
}