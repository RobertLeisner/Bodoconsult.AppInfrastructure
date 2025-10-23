// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Blocks;

/// <summary>
/// Base renderer implementation for HTML link elements
/// </summary>
public class WpfLinkTextRendererElementBase : WpfTextRendererElementBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="block">Current block</param>
    public WpfLinkTextRendererElementBase(Block block) : base(block)
    { }
}