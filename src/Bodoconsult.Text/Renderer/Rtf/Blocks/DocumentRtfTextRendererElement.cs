// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.Rtf.Blocks;

/// <summary>
/// Rtf rendering element for <see cref="Document"/> instances
/// </summary>
public class DocumentRtfTextRendererElement : RtfTextRendererElementBase
{
    private readonly Document _document;

    /// <summary>
    /// Default ctor
    /// </summary>
    public DocumentRtfTextRendererElement(Document document) : base(document)
    {
        _document = document;
        ClassName = document.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(ITextDocumentRenderer renderer)
    {
        renderer.Content.AppendLine(@"{\rtf1\ansi\deff0");
        DocumentRendererHelper.RenderBlockChildsToRtf(renderer,  _document.ChildBlocks);
        renderer.Content.AppendLine("}");

        // Some general fixes to be applied
        renderer.Content.Replace("\\par\r\n}\\cell", "}\\cell");
        renderer.Content.Replace("\\par}\\cell", "}\\cell");

    }
}