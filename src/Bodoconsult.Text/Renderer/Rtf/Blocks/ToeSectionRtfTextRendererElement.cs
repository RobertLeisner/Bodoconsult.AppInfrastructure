// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.Rtf.Blocks;

/// <summary>
/// Rtf rendering element for <see cref="ToeSection"/> instances
/// </summary>
public class ToeSectionRtfTextRendererElement : SectionBaseRtfTextRendererElement
{
    private readonly ToeSection _toeSection;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ToeSectionRtfTextRendererElement(ToeSection toeSection) : base(toeSection)
    {
        _toeSection = toeSection;
        ClassName = toeSection.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(ITextDocumentRenderer renderer)
    {
        if (_toeSection.ChildBlocks.Count == 0)
        {
            return;
        }

        RenderItInternal(renderer, "ToeHeadingStyle", renderer.Document.DocumentMetaData.ToeHeading);

        //// Get the content of all inlines as string
        //var style = (ParagraphStyleBase)renderer.Styleset.FindStyle("ToeHeadingStyle");
        //renderer.Content.Append($"\\pard\\plain\\q{renderer.Styleset.GetIndexOfStyle(Block.StyleName)} {RtfHelper.GetFormatSettings(style, renderer.Styleset)}{{");

        //var sb = new StringBuilder(renderer.CheckContent(renderer.Document.DocumentMetaData.ToeHeading));
        //CleanRtfString(sb);
        //renderer.Content.Append(sb);
        //renderer.Content.Append($"\\par}}{Environment.NewLine}");

        //base.RenderIt(renderer);
    }
}