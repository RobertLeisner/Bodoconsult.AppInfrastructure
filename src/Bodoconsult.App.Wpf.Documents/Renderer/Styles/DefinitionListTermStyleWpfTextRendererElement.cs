// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.


// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="DefinitionListTermStyle"/> instances
/// </summary>
public class DefinitionListTermStyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    private readonly DefinitionListTermStyle _style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public DefinitionListTermStyleWpfTextRendererElement(DefinitionListTermStyle style) : base(style)
    {
        _style = style;
        ClassName = "DefinitionListTermStyle";
        AdditionalCss.Add("grid-column-start: 1;");
    }
}