// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using Bodoconsult.Text.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bodoconsult.Text.Renderer.Html;

/// <summary>
/// HTML rendering element for <see cref="HeadingBase"/> instances
/// </summary>
public class HeadingBaseHtmlTextRendererElement : HtmlTextRendererElementBase
{
    private readonly HeadingBase _headingBase;

    /// <summary>
    /// Default ctor
    /// </summary>
    public HeadingBaseHtmlTextRendererElement(HeadingBase headingBase) : base(headingBase)
    {
        _headingBase = headingBase;
        ClassName = headingBase.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(ITextDocumentRenderer renderer)
    {
        // Get the content of all inlines as string
        var sb = new StringBuilder();

        if (string.IsNullOrEmpty(LocalCss))
        {
            renderer.Content.Append($"<{TagToUse} class=\"{ClassName}\">");
        }
        else
        {
            renderer.Content.Append($"<{TagToUse} class=\"{ClassName}\" style=\"{LocalCss}\">");
        }

        sb.Append($"<a name=\"{_headingBase.TagName}\" />");

        //DocumentRendererHelper.RenderBlockChildsToHtml(renderer, sb, Block.ChildBlocks);

        var childs = new List<Inline>();

        if (!string.IsNullOrEmpty(_headingBase.CurrentPrefix))
        {
            childs.Add(new Span(_headingBase.CurrentPrefix));
        }

        childs.AddRange(_headingBase.ChildInlines);

        DocumentRendererHelper.RenderInlineChildsToHtml(renderer, sb, childs);
        renderer.Content.Append(sb);
        renderer.Content.Append($"</{TagToUse}>{Environment.NewLine}");
    }
}