// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Blocks;

/// <summary>
/// Base renderer implementation for HTML link elements
/// </summary>
public class PdfLinkTextRendererElementBase : PdfTextRendererElementBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="block">Current block</param>
    public PdfLinkTextRendererElementBase(Block block) : base(block)
    { }
}