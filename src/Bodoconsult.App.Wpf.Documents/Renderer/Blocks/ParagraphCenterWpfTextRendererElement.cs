// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Blocks;

/// <summary>
/// WPF rendering element for <see cref="ParagraphCenter"/> instances
/// </summary>
public class ParagraphCenterWpfTextRendererElement : ParagraphWpfTextRendererElementBase
{
    private readonly ParagraphCenter _paragraphCenter;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ParagraphCenterWpfTextRendererElement(ParagraphCenter paragraphCenter) : base(paragraphCenter)
    {
        _paragraphCenter = paragraphCenter;
        ClassName = paragraphCenter.StyleName;
    }
}