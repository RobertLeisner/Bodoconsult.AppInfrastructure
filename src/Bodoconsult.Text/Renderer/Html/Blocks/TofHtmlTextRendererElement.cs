// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html;

/// <summary>
/// HTML rendering element for <see cref="Tof"/> instances
/// </summary>
public class TofHtmlTextRendererElement : HtmlLinkTextRendererElementBase
{
    private readonly Tof _tof;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TofHtmlTextRendererElement(Tof tof) : base(tof)
    {
        _tof = tof;
        ClassName = tof.StyleName;
    }
}