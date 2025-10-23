// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.Rtf.Styles;

/// <summary>
/// Base class for <see cref="PageStyleBase"/> based styles
/// </summary>
public abstract class RtfPageStyleTextRendererElementBase : ITextRendererElement
{

    /// <summary>
    /// Current block to renderer
    /// </summary>
    public PageStyleBase Style { get; private set; }

    /// <summary>
    /// CSS class name
    /// </summary>
    public string ClassName { get; protected set; }

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="style">Current page style</param>
    protected RtfPageStyleTextRendererElementBase(PageStyleBase style)
    {
        Style = style;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public virtual void RenderIt(ITextDocumentRenderer renderer)
    {
        // Do nothing

    //    var sb = new StringBuilder();

    //    sb.AppendLine(Style.PageHeight < Style.PageWidth ? "\\landscape" : "\\portrait");

    //    sb.AppendLine(
    //        $"\\paperw{MeasurementHelper.GetTwipsFromCm((float)Style.PageWidth)}\\paperh{MeasurementHelper.GetTwipsFromCm((float)Style.PageHeight)}\\margl{MeasurementHelper.GetTwipsFromCm((float)Style.MarginLeft)}\\margr{MeasurementHelper.GetTwipsFromCm((float)Style.MarginRight)}\\margt{MeasurementHelper.GetTwipsFromCm((float)Style.MarginTop)}\\margb{MeasurementHelper.GetTwipsFromCm((float)Style.MarginBottom)} ");
    }

        
}