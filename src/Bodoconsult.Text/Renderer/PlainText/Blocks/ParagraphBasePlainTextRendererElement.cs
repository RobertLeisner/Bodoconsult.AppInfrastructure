// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Text;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.PlainText;

/// <summary>
/// Text rendering element for <see cref="Documents.Paragraph"/> instances
/// </summary>
public abstract class ParagraphBasePlainTextRendererElement : ITextRendererElement
{
    /// <summary>
    /// Current paragraph base element
    /// </summary>
    protected ParagraphBase Paragraph;

    /// <summary>
    /// Char used for left and right borders
    /// </summary>
    public string LeftRightBorderChar { get; set; } = "|";

    /// <summary>
    /// Char used for top and bottom borders
    /// </summary>
    public string TopBottomBorderChar { get; set; } = "-";

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public virtual void RenderIt(ITextDocumentRenderer renderer)
    {
        // Get the content of all inlines as string
        var sb = new StringBuilder();
        DocumentRendererHelper.RenderBlockChildsToPlain(renderer, Paragraph.ChildBlocks);
        DocumentRendererHelper.RenderInlineChildsToPlainText(renderer, sb, Paragraph.ChildInlines, string.Empty, true);

        //Debug.Print(sb.ToString());

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