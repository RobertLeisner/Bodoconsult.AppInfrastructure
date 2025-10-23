// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System;
using System.Text;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.Html;

/// <summary>
/// Base renderer implementation for HTML elements
/// </summary>
public abstract class HtmlTextRendererElementBase : ITextRendererElement
{
    /// <summary>
    /// Current block to renderer
    /// </summary>
    public Block Block { get; private set; }

    /// <summary>
    /// CSS class name
    /// </summary>
    public string ClassName { get; protected set; }

    /// <summary>
    /// CSS to be added to the local tag
    /// </summary>
    public string LocalCss { get; set; }

    /// <summary>
    /// HTML tag to use for rendering
    /// </summary>
    protected string TagToUse = "p";

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="block">Current block</param>
    public HtmlTextRendererElementBase(Block block)
    {
        Block = block;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public virtual void RenderIt(ITextDocumentRenderer renderer)
    {
        // Get the content of all inlines as string
        var sb = new StringBuilder();

        if (string.IsNullOrEmpty(LocalCss))
        {
            renderer.Content.AppendLine($"<{TagToUse} class=\"{ClassName}\">");
        }
        else
        {
            renderer.Content.AppendLine($"<{TagToUse} class=\"{ClassName}\" style=\"{LocalCss}\">");
        }

        DocumentRendererHelper.RenderBlockChildsToHtml(renderer, Block.ChildBlocks);

        DocumentRendererHelper.RenderInlineChildsToHtml(renderer, sb, Block.ChildInlines);
        renderer.Content.Append(sb);
        renderer.Content.Append($"</{TagToUse}>{Environment.NewLine}");
    }
}

/// <summary>
/// Base renderer implementation for HTML link elements
/// </summary>
public class HtmlLinkTextRendererElementBase : HtmlTextRendererElementBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="block">Current block</param>
    public HtmlLinkTextRendererElementBase(Block block) : base(block)
    { }

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

        sb.Append($"<a href=\"#{Block.TagName}\">");

        DocumentRendererHelper.RenderInlineChildsToHtml(renderer, sb, Block.ChildInlines);

        sb.Append("</a>");

        renderer.Content.Append(sb);
        renderer.Content.Append($"</{TagToUse}>{Environment.NewLine}");
    }
}