// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Blocks;

/// <summary>
/// Base renderer implementation for HTML link elements
/// </summary>
public class DocxLinkTextRendererElementBase : DocxTextRendererElementBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="block">Current block</param>
    public DocxLinkTextRendererElementBase(Block block) : base(block)
    { }
}