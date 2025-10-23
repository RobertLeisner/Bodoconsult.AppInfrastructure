// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Blocks;

/// <summary>
/// HTML rendering element for <see cref="DocumentMetaData"/> instances
/// </summary>
public class DocumentMetaDataPdfTextRendererElement : PdfTextRendererElementBase
{
    private readonly DocumentMetaData _documentMetaData;

    /// <summary>
    /// Default ctor
    /// </summary>
    public DocumentMetaDataPdfTextRendererElement(DocumentMetaData documentMetaData) : base(documentMetaData)
    {
        _documentMetaData = documentMetaData;
        ClassName = documentMetaData.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(PdfTextDocumentRenderer renderer)
    {
        // Do nothing
    }
}