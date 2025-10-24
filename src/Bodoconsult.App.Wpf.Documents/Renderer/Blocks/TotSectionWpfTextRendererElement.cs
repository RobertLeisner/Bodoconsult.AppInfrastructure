// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Windows.Documents;
using Bodoconsult.App.Wpf.Documents.Helpers;
using Bodoconsult.App.Wpf.Documents.Renderer;
using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Blocks;

/// <summary>
/// WPF rendering element for <see cref="TotSection"/> instances
/// </summary>
public class TotSectionWpfTextRendererElement : WpfTextRendererElementBase
{
    private readonly TotSection _totSection;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TotSectionWpfTextRendererElement(TotSection totSection) : base(totSection)
    {
        _totSection = totSection;
        ClassName = totSection.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(WpfTextDocumentRenderer renderer)
    {
        WpfDocumentRendererHelper.CreateSection(renderer, _totSection, "TotHeadingStyle", renderer.Document.DocumentMetaData.TotHeading);
    }
}