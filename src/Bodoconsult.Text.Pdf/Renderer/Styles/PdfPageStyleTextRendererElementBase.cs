// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;
using Bodoconsult.Text.Pdf.Interfaces;
using MigraDoc.DocumentObjectModel;

namespace Bodoconsult.Text.Pdf.Renderer.Styles;

/// <summary>
/// Base class for <see cref="PageStyleBase"/> based styles
/// </summary>
public abstract class PdfPageStyleTextRendererElementBase : IPdfTextRendererElement
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
    protected PdfPageStyleTextRendererElementBase(PageStyleBase style)
    {
        Style = style;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public void RenderIt(PdfTextDocumentRenderer renderer)
    {
        var pdfStyle = renderer.PdfDocument.PageSetup;

        pdfStyle.Orientation = Style.TypeAreaHeight < Style.TypeAreaWidth ? Orientation.Landscape : Orientation.Portrait;
        pdfStyle.PageWidth = Unit.FromCentimeter(Style.PageWidth);
        pdfStyle.PageHeight = Unit.FromCentimeter(Style.PageHeight);
        pdfStyle.LeftMargin = Unit.FromCentimeter(Style.MarginLeft);
        pdfStyle.RightMargin = Unit.FromCentimeter(Style.MarginRight);
        pdfStyle.TopMargin = Unit.FromCentimeter(Style.MarginTop);
        pdfStyle.BottomMargin = Unit.FromCentimeter(Style.MarginBottom);

        // ToDo: other formats
        pdfStyle.PageFormat = PageFormat.A4;
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