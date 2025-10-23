// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.Rtf.Blocks;

/// <summary>
/// Rtf rendering element for <see cref="Section"/> instances
/// </summary>
public class SectionRtfTextRendererElement : SectionBaseRtfTextRendererElement
{
    private readonly Section _section;

    /// <summary>
    /// Default ctor
    /// </summary>
    public SectionRtfTextRendererElement(Section section) : base(section)
    {
        _section = section;
        ClassName = section.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(ITextDocumentRenderer renderer)
    {
        if (_section.ChildBlocks.Count == 0)
        {
            return;
        }

        RenderItInternal(renderer, "SectionStyle", string.Empty);
    }
}