// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System.Text;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.PlainText;

/// <summary>
/// Plain text rendering element for <see cref="TofSection"/> instances
/// </summary>
public class TofSectionPlainTextRendererElement : ITextRendererElement
{
    private readonly TofSection _tofSection;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TofSectionPlainTextRendererElement(TofSection tofSection)
    {
        _tofSection = tofSection;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public void RenderIt(ITextDocumentRenderer renderer)
    {
        // Get the content of all inlines as string
        if (_tofSection.ChildBlocks.Count == 0)
        {
            return;
        }

        var style = (ParagraphStyleBase)renderer.Styleset.FindStyle("TotHeadingStyle");
        var sectionStyle = (PageStyleBase)renderer.Styleset.FindStyle("DocumentStyle");

        // Get the content of all inlines as string
        var sb = new StringBuilder();

        var pr = new PlainTextParagraphFormatter(renderer.CheckContent(renderer.Document.DocumentMetaData.TofHeading),
            style, sectionStyle);
        pr.CalculateValues();
        pr.FormatText();
        sb.Append(pr.GetFormattedText());

        DocumentRendererHelper.RenderBlockChildsToPlain(renderer, _tofSection.ChildBlocks);

        DocumentRendererHelper.RenderInlineChildsToPlainText(renderer, sb, _tofSection.ChildInlines, string.Empty, true);
        renderer.Content.Append(sb);
    }
}