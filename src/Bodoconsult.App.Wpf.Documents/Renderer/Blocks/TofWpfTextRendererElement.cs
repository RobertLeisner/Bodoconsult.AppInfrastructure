// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Blocks;

/// <summary>
/// WPF rendering element for <see cref="Tof"/> instances
/// </summary>
public class TofWpfTextRendererElement : ParagraphWpfTextRendererElementBase
{
    private readonly Tof _tof;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TofWpfTextRendererElement(Tof tof) : base(tof)
    {
        _tof = tof;
        ClassName = tof.StyleName;
    }
}