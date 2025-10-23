// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="DefinitionListItemStyle"/> instances
/// </summary>
public class DefinitionListItemStyleHtmlTextRendererElement : HtmlParagraphStyleTextRendererElementBase
{
    private readonly DefinitionListItemStyle _style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public DefinitionListItemStyleHtmlTextRendererElement(DefinitionListItemStyle style) : base(style)
    {
        _style = style;
        ClassName = "DefinitionListItemStyle";
        AdditionalCss.Add("grid-column-start: 2;");
    }
}