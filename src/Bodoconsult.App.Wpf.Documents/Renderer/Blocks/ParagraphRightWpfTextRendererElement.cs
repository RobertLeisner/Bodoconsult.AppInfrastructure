// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Blocks;

/// <summary>
/// WPF rendering element for <see cref="ParagraphRight"/> instances
/// </summary>
public class ParagraphRightWpfTextRendererElement : ParagraphWpfTextRendererElementBase
{
    private readonly ParagraphRight _paragraphRight;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ParagraphRightWpfTextRendererElement(ParagraphRight paragraphRight) : base(paragraphRight)
    {
        _paragraphRight = paragraphRight;
        ClassName = paragraphRight.StyleName;
    }
}