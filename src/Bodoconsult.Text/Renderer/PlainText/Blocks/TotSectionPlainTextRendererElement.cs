// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System.Text;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.PlainText;

/// <summary>
/// Plain text rendering element for <see cref="TotSection"/> instances
/// </summary>
public class TotSectionPlainTextRendererElement : ITextRendererElement
{
    private readonly TotSection _totSection;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TotSectionPlainTextRendererElement(TotSection totSection)
    {
        _totSection = totSection;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public void RenderIt(ITextDocumentRenderer renderer)
    {
        // Get the content of all inlines as string
        if (_totSection.ChildBlocks.Count == 0)
        {
            return;
        }

        var style = (ParagraphStyleBase)renderer.Styleset.FindStyle("TotHeadingStyle");
        var sectionStyle = (PageStyleBase)renderer.Styleset.FindStyle("DocumentStyle");

        // Get the content of all inlines as string
        var sb = new StringBuilder();

        var pr = new PlainTextParagraphFormatter(renderer.CheckContent(renderer.Document.DocumentMetaData.TotHeading),
            style, sectionStyle);
        pr.CalculateValues();
        pr.FormatText();
        sb.Append(pr.GetFormattedText());

        DocumentRendererHelper.RenderBlockChildsToPlain(renderer, _totSection.ChildBlocks);

        DocumentRendererHelper.RenderInlineChildsToPlainText(renderer, sb, _totSection.ChildInlines, string.Empty, true);
        renderer.Content.Append(sb);
    }
}