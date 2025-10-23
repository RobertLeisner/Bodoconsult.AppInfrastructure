// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.Rtf.Blocks;

/// <summary>
/// Rtf rendering element for <see cref="TofSection"/> instances
/// </summary>
public class TofSectionRtfTextRendererElement : SectionBaseRtfTextRendererElement
{
    private readonly TofSection _tofSection;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TofSectionRtfTextRendererElement(TofSection tofSection) : base(tofSection)
    {
        _tofSection = tofSection;
        ClassName = tofSection.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(ITextDocumentRenderer renderer)
    {
        if (_tofSection.ChildBlocks.Count == 0)
        {
            return;
        }

        RenderItInternal(renderer, "TofHeadingStyle", renderer.Document.DocumentMetaData.TofHeading);

        //// Get the content of all inlines as string
        //var style = (ParagraphStyleBase)renderer.Styleset.FindStyle("TofHeadingStyle");
        //renderer.Content.Append($"\\pard\\plain\\q{renderer.Styleset.GetIndexOfStyle(Block.StyleName)} {RtfHelper.GetFormatSettings(style, renderer.Styleset)}{{");

        //var sb = new StringBuilder(renderer.CheckContent(renderer.Document.DocumentMetaData.TofHeading));
        //CleanRtfString(sb);
        //renderer.Content.Append(sb);
        //renderer.Content.Append($"\\par}}{Environment.NewLine}");

        //base.RenderIt(renderer);
    }
}