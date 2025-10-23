// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using Bodoconsult.Text.Interfaces;
using System;

namespace Bodoconsult.Text.Renderer.Rtf.Blocks;

/// <summary>
/// Rtf rendering element for <see cref="Citation"/> instances
/// </summary>
public class CitationRtfTextRendererElement : RtfTextRendererElementBase
{
    private readonly Citation _citation;

    /// <summary>
    /// Default ctor
    /// </summary>
    public CitationRtfTextRendererElement(Citation citation) : base(citation)
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
        var style = (ParagraphStyleBase)renderer.Styleset.FindStyle("CitationSourceStyle");
        renderer.Content.Append($@"\pard\plain\q{renderer.Styleset.GetIndexOfStyle("CitationSourceStyle")} {RtfHelper.GetFormatSettings(style, renderer.Styleset)} {{");
        renderer.Content.Append($"{renderer.Document.DocumentMetaData.CitationSourcePrefix}{_citation.Source}");
        renderer.Content.Append($"\\par }}{Environment.NewLine}");
    }
}