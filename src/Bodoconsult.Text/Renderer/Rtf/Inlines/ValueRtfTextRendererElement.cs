// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Text;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.Rtf.Inlines;

/// <summary>
/// Render a <see cref="Value"/> element
/// </summary>
public class ValueRtfTextRendererElement : InlineRtfTextRendererElementBase
{
    private readonly Value _value;

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="value">Value instance</param>
    public ValueRtfTextRendererElement(Value value)
    {
        _value = value;
    }

    /// <summary>
    /// Render the inline element to string
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    /// <param name="sb">String to add the inline element rendered</param>
    public override void RenderToString(ITextDocumentRenderer renderer, StringBuilder sb)
    {
        sb.Append($"{{{renderer.CheckContent(_value.Content)}}}");
    }
}