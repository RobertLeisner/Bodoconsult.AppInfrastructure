// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using Bodoconsult.Text.Interfaces;
using System.Text;

namespace Bodoconsult.Text.Renderer.PlainText;

/// <summary>
/// Plain text rendering element for <see cref="TocSection"/> instances
/// </summary>
public class TocSectionPlainTextRendererElement : ITextRendererElement
{
    private readonly TocSection _tocSection;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TocSectionPlainTextRendererElement(TocSection tocSection) 
    {
        _tocSection = tocSection;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public void RenderIt(ITextDocumentRenderer renderer)
    {
        // Get the content of all inlines as string
        if (_tocSection.ChildBlocks.Count == 0)
        {
            return;
        }

        var style = (ParagraphStyleBase)renderer.Styleset.FindStyle("TocHeadingStyle");
        var sectionStyle = (PageStyleBase)renderer.Styleset.FindStyle("DocumentStyle");

        // Get the content of all inlines as string
        var sb = new StringBuilder();

        var pr = new PlainTextParagraphFormatter(renderer.CheckContent(renderer.Document.DocumentMetaData.TocHeading),
            style, sectionStyle);
        pr.CalculateValues();
        pr.FormatText();
        sb.Append(pr.GetFormattedText());

        DocumentRendererHelper.RenderBlockChildsToPlain(renderer, _tocSection.ChildBlocks);

        DocumentRendererHelper.RenderInlineChildsToPlainText(renderer, sb, _tocSection.ChildInlines, string.Empty, true);
        renderer.Content.Append(sb);
    }
}