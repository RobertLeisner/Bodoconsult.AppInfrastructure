// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Blocks;

/// <summary>
/// WPF rendering element for <see cref="Info"/> instances
/// </summary>
public class InfoWpfTextRendererElement : ParagraphWpfTextRendererElementBase
{
    private readonly Info _info;

    /// <summary>
    /// Default ctor
    /// </summary>
    public InfoWpfTextRendererElement(Info info) : base(info)
    {
        _info = info;
        ClassName = info.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(WpfTextDocumentRenderer renderer)
    {

    }
}