// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.


// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="DefinitionListItemStyle"/> instances
/// </summary>
public class DefinitionListItemStyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    private readonly DefinitionListItemStyle _style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public DefinitionListItemStyleWpfTextRendererElement(DefinitionListItemStyle style) : base(style)
    {
        _style = style;
        ClassName = "DefinitionListItemStyle";
        AdditionalCss.Add("grid-column-start: 2;");
    }
}