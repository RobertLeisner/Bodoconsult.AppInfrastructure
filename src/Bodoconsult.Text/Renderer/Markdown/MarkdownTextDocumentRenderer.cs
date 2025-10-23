// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Markdown;

/// <summary>
/// Render a <see cref="Document"/> to a Markdown file
/// </summary>
public class MarkdownTextDocumentRenderer : BaseTextDocumentRenderer
{
    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="document">Document to render</param>
    public MarkdownTextDocumentRenderer(Document document) : base(document)
    { }
}