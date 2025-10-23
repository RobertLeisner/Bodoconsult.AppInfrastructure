// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Collections.Generic;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;
using Bodoconsult.Text.Pdf.Helpers;
using Bodoconsult.Text.Pdf.Interfaces;

namespace Bodoconsult.Text.Pdf.Renderer.Styles;

/// <summary>
/// Base class for <see cref="ParagraphStyleBase"/> based styles
/// </summary>
public class PdfParagraphStyleTextRendererElementBase : IPdfTextRendererElement
{

    /// <summary>
    /// Current block to renderer
    /// </summary>
    public ParagraphStyleBase Style { get; private set; }

    /// <summary>
    /// CSS class name
    /// </summary>
    public string ClassName { get; protected set; }

    /// <summary>
    /// Additonal CSS styling tags
    /// </summary>
    public List<string> AdditionalCss { get; } = new();

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="style">Current paragraph style</param>
    public PdfParagraphStyleTextRendererElementBase(ParagraphStyleBase style)
    {
        Style = style;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public virtual void RenderIt(ITextDocumentRenderer renderer)
    {
        throw new System.NotSupportedException();
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public void RenderIt(PdfTextDocumentRenderer renderer)
    {

        var styleName = Style.Name.Replace("Style", "");

        if (styleName == "Paragraph")
        {
            styleName = "Normal";
        }

        var pdfStyle = renderer.PdfDocument.GetStyle(styleName);

        PdfDocumentRendererHelper.RenderParagraphStyle(Style, pdfStyle);
    }
}