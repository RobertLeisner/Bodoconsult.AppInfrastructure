// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;
using System;

namespace Bodoconsult.Text.Renderer.Html;

/// <summary>
/// HTML rendering element for <see cref="Citation"/> instances
/// </summary>
public class CitationHtmlTextRendererElement : HtmlTextRendererElementBase
{
    private readonly Citation _citation;

    /// <summary>
    /// Default ctor
    /// </summary>
    public CitationHtmlTextRendererElement(Citation citation) : base(citation)
    {
        _citation = citation;
        ClassName = citation.StyleName;
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
        renderer.Content.Append($"<{TagToUse} class=\"CitationSourceStyle\">");
        renderer.Content.Append($"{renderer.Document.DocumentMetaData.CitationSourcePrefix}{_citation.Source}");
        renderer.Content.Append($"</{TagToUse}>{Environment.NewLine}");
    }
}

