// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.Rtf.Blocks;

/// <summary>
/// Rtf rendering element for <see cref="TotSection"/> instances
/// </summary>
public class TotSectionRtfTextRendererElement : SectionBaseRtfTextRendererElement
{
    private readonly TotSection _totSection;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TotSectionRtfTextRendererElement(TotSection totSection) : base(totSection)
    {
        _totSection = totSection;
        ClassName = totSection.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(ITextDocumentRenderer renderer)
    {
        if (_totSection.ChildBlocks.Count == 0)
        {
            return;
        }

        RenderItInternal(renderer, "TotHeadingStyle", renderer.Document.DocumentMetaData.TotHeading);

        //// Get the content of all inlines as string
        //var style = (ParagraphStyleBase)renderer.Styleset.FindStyle("TotHeadingStyle");
        //renderer.Content.Append($"\\pard\\plain\\q{renderer.Styleset.GetIndexOfStyle(Block.StyleName)} {RtfHelper.GetFormatSettings(style, renderer.Styleset)}{{");

        //var sb = new StringBuilder(renderer.CheckContent(renderer.Document.DocumentMetaData.TotHeading));
        //CleanRtfString(sb);
        //renderer.Content.Append(sb);
        //renderer.Content.Append($"\\par}}{Environment.NewLine}");

        //base.RenderIt(renderer);
    }
}