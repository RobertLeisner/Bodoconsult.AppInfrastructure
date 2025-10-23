// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Text;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.PlainText;

/// <summary>
/// Plain text rendering element for <see cref="DocumentMetaData"/> instances
/// </summary>
public class DocumentMetaDataPlainTextRendererElement : ITextRendererElement
{
    private readonly DocumentMetaData _documentMetaData;

    /// <summary>
    /// Default ctor
    /// </summary>
    public DocumentMetaDataPlainTextRendererElement(DocumentMetaData documentMetaData) 
    {
        _documentMetaData = documentMetaData;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public void RenderIt(ITextDocumentRenderer renderer)
    {
        // Get the content of all inlines as string
        var sb = new StringBuilder();

        // ToDo: Add data

        renderer.Content.Append(sb);
    }
}