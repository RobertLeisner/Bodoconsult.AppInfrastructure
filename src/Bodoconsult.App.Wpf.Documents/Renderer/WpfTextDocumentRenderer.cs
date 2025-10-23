// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;
using Bodoconsult.Text.Renderer;

namespace Bodoconsult.App.Wpf.Documents.Renderer;

/// <summary>
/// Render a <see cref="Document"/> to a PDF file
/// </summary>
public class WpfTextDocumentRenderer : BaseDocumentRenderer
{
    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="document">Document to render</param>
    /// <param name="textRendererElementFactory">Current factory for text renderer elements</param>
    public WpfTextDocumentRenderer(Document document, ITextRendererElementFactory textRendererElementFactory) : base(document)
    {
        var metaData = document.DocumentMetaData;

    }

    /// <summary>
    /// Render the document
    /// </summary>
    public override void RenderIt()
    {

    }

    /// <summary>
    /// Save the rendered document as file
    /// </summary>
    /// <param name="fileName">Full file path. Existing file will be overwritten</param>
    public override void SaveAsFile(string fileName)
    {
        
    }
}