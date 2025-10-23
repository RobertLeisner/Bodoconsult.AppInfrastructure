// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Text;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.Html;

/// <summary>
/// HTML rendering element for <see cref="Styleset"/> instances
/// </summary>
public class StylesetHtmlTextRendererElement : HtmlTextRendererElementBase
{
    private readonly Styleset _styleset;

    /// <summary>
    /// Default ctor
    /// </summary>
    public StylesetHtmlTextRendererElement(Styleset styleset) : base(styleset)
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