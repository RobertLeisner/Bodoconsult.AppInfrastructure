// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using Bodoconsult.Text.Interfaces;
using System;
using System.Text;

namespace Bodoconsult.Text.Renderer.PlainText;

/// <summary>
/// Text rendering element for <see cref="List"/> instances
/// </summary>
public class ListPlainTextRendererElement : ParagraphBasePlainTextRendererElement
{
    private List _list;


    /// <summary>
    /// Default ctor
    /// </summary>
    public ListPlainTextRendererElement(List list)
    {
        Paragraph = list;
        _list = list;
    }

    /// <summary>
    /// List style
    /// </summary>
    public ListStyle ListStyle { get; set; }


    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(ITextDocumentRenderer renderer)
    {
        ListStyle = (ListStyle)renderer.Styleset.FindStyle("ListStyle");

        // Margin top
        AddMargin(renderer, ListStyle.Margins.Top);

        // Get the content of all inlines as string
        var sb = new StringBuilder();
        DocumentRendererHelper.RenderBlockChildsToPlain(renderer, Paragraph.ChildBlocks);
        DocumentRendererHelper.RenderInlineChildsToPlainText(renderer, sb, Paragraph.ChildInlines, string.Empty, true);

        // Now add the formatted text to the rendered content
        renderer.Content.Append(sb);

        // Margin bottom
        AddMargin(renderer, ListStyle.Margins.Bottom);
    }

    private void AddMargin(ITextDocumentRenderer renderer, double thickness)
    {
        if (thickness <= 0)
        {
            return;
        }

        var lineNumber = (int)Math.Ceiling(thickness / ListStyle.FontSize);

        for (var i = 0; i < lineNumber; i++)
        {
            renderer.Content.AppendLine("");
        }
    }
}