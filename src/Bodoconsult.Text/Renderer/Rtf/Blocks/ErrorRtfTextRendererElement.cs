// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Blocks;

/// <summary>
/// Rtf rendering element for <see cref="Error"/> instances
/// </summary>
public class ErrorRtfTextRendererElement : RtfTextRendererElementBase
{
    private readonly Error _error;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ErrorRtfTextRendererElement(Error error) : base(error)
    {
        _error = error;
        ClassName = error.StyleName;
    }
}