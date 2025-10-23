// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using Bodoconsult.Text.Interfaces;
using System.Text;

namespace Bodoconsult.Text.Renderer.PlainText;

/// <summary>
/// Plain rendering element for <see cref="ToeSection"/> instances
/// </summary>
public class ToeSectionPlainTextRendererElement : ITextRendererElement
{
    private readonly ToeSection _toeSection;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ToeSectionPlainTextRendererElement(ToeSection toeSection)
    {
        _toeSection = toeSection;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public void RenderIt(ITextDocumentRenderer renderer)
    {
        // Get the content of all inlines as string
        if (_toeSection.ChildBlocks.Count == 0)
        {
            return;
        }

        var style = (ParagraphStyleBase)renderer.Styleset.FindStyle("ToeHeadingStyle");
        var sectionStyle = (PageStyleBase)renderer.Styleset.FindStyle("DocumentStyle");

        // Get the content of all inlines as string
        var sb = new StringBuilder();

        var pr = new PlainTextParagraphFormatter(renderer.CheckContent(renderer.Document.DocumentMetaData.ToeHeading),
            style, sectionStyle);
        pr.CalculateValues();
        pr.FormatText();
        sb.Append(pr.GetFormattedText());

        DocumentRendererHelper.RenderBlockChildsToPlain(renderer, _toeSection.ChildBlocks);

        DocumentRendererHelper.RenderInlineChildsToPlainText(renderer, sb, _toeSection.ChildInlines, string.Empty, true);
        renderer.Content.Append(sb);
    }
}