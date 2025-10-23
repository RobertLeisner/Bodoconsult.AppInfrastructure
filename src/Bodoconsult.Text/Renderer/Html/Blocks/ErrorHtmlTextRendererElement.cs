// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html;

/// <summary>
/// HTML rendering element for <see cref="Error"/> instances
/// </summary>
public class ErrorHtmlTextRendererElement : HtmlTextRendererElementBase
{
    private readonly Error _error;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ErrorHtmlTextRendererElement(Error error) : base(error)
    {
        _error = error;
        ClassName = error.StyleName;
    }
}