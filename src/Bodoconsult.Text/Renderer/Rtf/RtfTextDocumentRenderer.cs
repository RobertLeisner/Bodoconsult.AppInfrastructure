// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.Rtf;

/// <summary>
/// Render a <see cref="Document"/> to a plain UTF-8 text file
/// </summary>
public class RtfTextDocumentRenderer : BaseTextDocumentRenderer
{
    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="document">Document to render</param>
    /// <param name="textRendererElementFactory">Current factory for text renderer elements</param>
    public RtfTextDocumentRenderer(Document document, ITextRendererElementFactory textRendererElementFactory) : base(document)
    {
        TextRendererElementFactory = textRendererElementFactory;
    }
}