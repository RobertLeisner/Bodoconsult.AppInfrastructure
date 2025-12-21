// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Blocks;

/// <summary>
/// Docx rendering element for <see cref="Document"/> instances
/// </summary>
public class DocumentDocxTextRendererElement : DocxTextRendererElementBase
{
    private readonly Document _document;

    /// <summary>
    /// Default ctor
    /// </summary>
    public DocumentDocxTextRendererElement(Document document) : base(document)
    {
        _document = document;
        ClassName = document.StyleName;
    }
}