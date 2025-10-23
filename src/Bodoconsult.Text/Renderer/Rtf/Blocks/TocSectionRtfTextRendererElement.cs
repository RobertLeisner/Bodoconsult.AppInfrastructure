// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.Rtf.Blocks;

/// <summary>
/// Rtf rendering element for <see cref="TocSection"/> instances
/// </summary>
public class TocSectionRtfTextRendererElement : SectionBaseRtfTextRendererElement
{
    private readonly TocSection _tocSection;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TocSectionRtfTextRendererElement(TocSection tocSection) : base(tocSection)
    {
        _tocSection = tocSection;
        ClassName = tocSection.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(ITextDocumentRenderer renderer)
    {
        if (_tocSection.ChildBlocks.Count == 0)
        {
            return;
        }

        RenderItInternal(renderer, "TocHeadingStyle", renderer.Document.DocumentMetaData.TocHeading);

        //// Get the content of all inlines as string
        //var style = (ParagraphStyleBase)renderer.Styleset.FindStyle("TocHeadingStyle");
        //renderer.Content.Append($"\\pard\\plain\\q{renderer.Styleset.GetIndexOfStyle(Block.StyleName)} {RtfHelper.GetFormatSettings(style, renderer.Styleset)}{{");

        //var sb = new StringBuilder(renderer.CheckContent(renderer.Document.DocumentMetaData.TocHeading));
        //CleanRtfString(sb);
        //renderer.Content.Append(sb);
        //renderer.Content.Append($"\\par}}{Environment.NewLine}");

        //base.RenderIt(renderer);
    }
}