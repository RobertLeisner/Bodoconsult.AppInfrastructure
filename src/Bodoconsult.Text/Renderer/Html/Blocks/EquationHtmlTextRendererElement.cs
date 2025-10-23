// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.Html;

/// <summary>
/// HTML rendering element for <see cref="Equation"/> instances
/// </summary>
public class EquationHtmlTextRendererElement : HtmlTextRendererElementBase
{
    private readonly Equation _equation;

    /// <summary>
    /// Default ctor
    /// </summary>
    public EquationHtmlTextRendererElement(Equation equation) : base(equation)
    {
        _equation = equation;
        ClassName = equation.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(ITextDocumentRenderer renderer)
    {
        DocumentRendererHelper.CreateImageHtml(renderer, _equation, TagToUse, LocalCss, ClassName);

        //// Get the content of all inlines as string
        //var sb = new StringBuilder();

        //if (string.IsNullOrEmpty(LocalCss))
        //{
        //    renderer.Content.Append($"<{TagToUse} class=\"{ClassName}\">");
        //}
        //else
        //{
        //    renderer.Content.Append($"<{TagToUse} class=\"{ClassName}\" style=\"{LocalCss}\">");
        //}

        //renderer.Content.Append($"<a name=\"{_equation.TagName}\" />");

        //var childs = new List<Inline>();

        //if (!string.IsNullOrEmpty(_equation.CurrentPrefix))
        //{
        //    childs.Add(new Span(_equation.CurrentPrefix));
        //}

        //childs.AddRange(_equation.ChildInlines);
        //DocumentRendererHelper.RenderInlineChildsToHtml(renderer, sb, childs);

        //// Get max height and with for images in twips
        //StylesetHelper.GetMaxWidthAndHeight(renderer.Styleset, out var maxWidth, out var maxHeight);

        //StylesetHelper.GetWidthAndHeight(MeasurementHelper.GetTwipsFromPx(_equation.OriginalWidth), MeasurementHelper.GetTwipsFromPx(_equation.OriginalHeight), maxWidth, maxHeight, out var width, out var height);

        //renderer.Content.Append($"<img src=\"{_equation.Uri}\" alt=\"{sb}\" width=\"{MeasurementHelper.GetPxFromTwips(width)}px\" height=\"{MeasurementHelper.GetPxFromTwips(height)}px\"/><br/>");

        //renderer.Content.Append(sb);
        //renderer.Content.Append($"</{TagToUse}>{Environment.NewLine}");
    }
}