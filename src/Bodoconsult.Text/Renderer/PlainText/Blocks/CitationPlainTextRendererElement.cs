// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;
using System.Text;

namespace Bodoconsult.Text.Renderer.PlainText;

/// <summary>
/// Text rendering element for <see cref="Citation"/> instances
/// </summary>
public class CitationPlainTextRendererElement : ParagraphBasePlainTextRendererElement
{
    private readonly Citation _citation;
    /// <summary>
    /// Default ctor
    /// </summary>
    public CitationPlainTextRendererElement(Citation citation)
    {
        _citation = citation;
        Paragraph= citation;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(ITextDocumentRenderer renderer)
    {
        base.RenderIt(renderer);

        if (string.IsNullOrEmpty(_citation.Source))
        {
            return;
        }

        var sb = new StringBuilder();

        sb.Append($"{renderer.Document.DocumentMetaData.CitationSourcePrefix}{_citation.Source}");

        // Now let the formatter work
        var style = (ParagraphStyleBase)renderer.Styleset.FindStyle($"{Paragraph.GetType().Name}Style");
        var formatter = new PlainTextParagraphFormatter(sb.ToString(), style, renderer.PageStyleBase)
        {
            LeftRightBorderChar = LeftRightBorderChar,
            TopBottomBorderChar = TopBottomBorderChar
        };
        formatter.FormatText();

        // Now add the formatted text to the rendered content
        renderer.Content.Append($"{formatter.GetFormattedText()}");
    }
}

