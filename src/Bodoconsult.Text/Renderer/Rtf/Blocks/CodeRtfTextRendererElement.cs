// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Blocks;

/// <summary>
/// Rtf rendering element for <see cref="Code"/> instances
/// </summary>
public class CodeRtfTextRendererElement : RtfTextRendererElementBase
{
    private readonly Code _code;

    /// <summary>
    /// Default ctor
    /// </summary>
    public CodeRtfTextRendererElement(Code code) : base(code)
    {
        _code = code;
        ClassName = code.StyleName;
    }
}