// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.Docx.Styles;

/// <summary>
/// Base class for <see cref="PageStyleBase"/> based styles
/// </summary>
public abstract class DocxPageStyleTextRendererElementBase : IDocxTextRendererElement
{

    /// <summary>
    /// Current block to renderer
    /// </summary>
    public PageStyleBase Style { get; private set; }

    /// <summary>
    /// CSS class name
    /// </summary>
    public string ClassName { get; protected set; }

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="style">Current page style</param>
    protected DocxPageStyleTextRendererElementBase(PageStyleBase style)
    {
        Style = style;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public void RenderIt(DocxTextDocumentRenderer renderer)
    {
        //var DocxStyle = renderer.DocxDocument.PageSetup;

        //DocxStyle.Orientation = Style.TypeAreaHeight < Style.TypeAreaWidth ? Orientation.Landscape : Orientation.Portrait;
        //DocxStyle.PageWidth = Unit.FromCentimeter(Style.PageWidth);
        //DocxStyle.PageHeight = Unit.FromCentimeter(Style.PageHeight);
        //DocxStyle.LeftMargin = Unit.FromCentimeter(Style.MarginLeft);
        //DocxStyle.RightMargin = Unit.FromCentimeter(Style.MarginRight);
        //DocxStyle.TopMargin = Unit.FromCentimeter(Style.MarginTop);
        //DocxStyle.BottomMargin = Unit.FromCentimeter(Style.MarginBottom);

        //// ToDo: other formats
        //DocxStyle.PageFormat = PageFormat.A4;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public void RenderIt(ITextDocumentRenderer renderer)
    {
        throw new NotSupportedException();
    }
}