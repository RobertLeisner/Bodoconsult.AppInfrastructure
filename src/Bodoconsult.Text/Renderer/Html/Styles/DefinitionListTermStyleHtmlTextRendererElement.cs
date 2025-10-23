// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="DefinitionListTermStyle"/> instances
/// </summary>
public class DefinitionListTermStyleHtmlTextRendererElement : HtmlParagraphStyleTextRendererElementBase
{
    private readonly DefinitionListTermStyle _style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public DefinitionListTermStyleHtmlTextRendererElement(DefinitionListTermStyle style) : base(style)
    {
        _style = style;
        ClassName = "DefinitionListTermStyle";
        AdditionalCss.Add("grid-column-start: 1;");
    }
}