// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Text;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;
using Bodoconsult.Text.Renderer.Rtf.Blocks;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Rtf rendering element for <see cref="Styleset"/> instances
/// </summary>
public class StylesetRtfTextRendererElement : RtfTextRendererElementBase
{
    private readonly Styleset _styleset;

    /// <summary>
    /// Default ctor
    /// </summary>
    public StylesetRtfTextRendererElement(Styleset styleset) : base(styleset)
    {
        _styleset = styleset;
        ClassName = styleset.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(ITextDocumentRenderer renderer)
    {
        renderer.Content.AppendLine("<style>");

        var sb = new StringBuilder();

        foreach (var style in _styleset.StyleDictionary.Values)
        {
            var rendererElement = renderer.TextRendererElementFactory.CreateInstance(style);
            rendererElement.RenderIt(renderer);
        }
        renderer.Content.Append(sb);

        renderer.Content.AppendLine("</style>");
        renderer.Content.AppendLine("</head>");
        renderer.Content.AppendLine("<body>");
    }
}