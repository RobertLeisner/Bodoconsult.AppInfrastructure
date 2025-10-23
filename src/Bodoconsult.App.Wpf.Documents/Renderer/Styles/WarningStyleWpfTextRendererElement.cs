// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="WarningStyle"/> instances
/// </summary>
public class WarningStyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    private readonly WarningStyle _warningStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public WarningStyleWpfTextRendererElement(WarningStyle warningStyle) : base(warningStyle)
    {
        _warningStyle = warningStyle;
        ClassName = "WarningStyle";
    }
}

