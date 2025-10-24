// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Windows;
using Bodoconsult.App.Wpf.Documents.Helpers;
using Bodoconsult.App.Wpf.Documents.Renderer;
using Bodoconsult.Text.Documents;
using System.Windows.Documents;


namespace Bodoconsult.App.Wpf.Documents.Renderer.Blocks;

/// <summary>
/// WPF rendering element for <see cref="TocSection"/> instances
/// </summary>
public class TocSectionWpfTextRendererElement : WpfTextRendererElementBase
{
    private readonly TocSection _tocSection;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TocSectionWpfTextRendererElement(TocSection tocSection) : base(tocSection)
    {
        _tocSection = tocSection;
        ClassName = tocSection.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(WpfTextDocumentRenderer renderer)
    {
        WpfDocumentRendererHelper.CreateSection(renderer, _tocSection, "TocHeadingStyle", renderer.Document.DocumentMetaData.TocHeading);
    }
}