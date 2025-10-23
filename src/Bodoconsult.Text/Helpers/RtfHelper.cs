﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using System.Text;
using Bodoconsult.App.Abstractions.Helpers;

namespace Bodoconsult.Text.Helpers;

/// <summary>
/// Rtf helper class
/// </summary>
public static class RtfHelper
{
    /// <summary>
    /// Get the RTF format settings for a paragraph setting
    /// </summary>
    /// <param name="style">Style</param>
    /// <param name="styleset">Current styleset</param>
    /// <param name="isTable">Is paragraph in a table</param>
    /// <returns>RTF format settings</returns>
    public static StringBuilder GetFormatSettings(ParagraphStyleBase style, Styleset styleset, bool isTable = false)
    {
        var sb = new StringBuilder();

        // Font name
        var index = styleset.Fonts.IndexOf(style.FontName);
        if (index == -1)
        {
            index = 0;
        }
        sb.Append($"\\f{index}");

        // Font size
        sb.Append($"\\fs{style.FontSize * 2}");

        // left margin
        sb.Append($"\\li{MeasurementHelper.GetTwipsFromPt(style.Margins.Left)}");

        // right margin
        sb.Append($"\\ri{MeasurementHelper.GetTwipsFromPt(style.Margins.Right)}");

        // top margin
        sb.Append($"\\sb{MeasurementHelper.GetTwipsFromPt(style.Margins.Top)}");

        // bottom margin
        sb.Append($"\\sa{MeasurementHelper.GetTwipsFromPt(style.Margins.Bottom)}");

        // bordor top
        if (style.BorderBrush != null && !isTable)
        {
            var colorIndex = styleset.GetIndexOfColor(style.BorderBrush.Color) + 1;

            if (style.BorderThickness.Top > 0)
            {
                sb.Append($@"\brdrt\brdrs\brdrw10\brsp60\brdrcf{colorIndex}");
            }

            // bordor bottom
            if (style.BorderThickness.Bottom > 0)
            {
                sb.Append($@"\brdrb\brdrs\brdrw10\brsp60\brdrcf{colorIndex}");
            }

            // bordor left
            if (style.BorderThickness.Left > 0)
            {
                sb.Append($@"\brdrl\brdrs\brdrw10\brsp60\brdrcf{colorIndex}");
            }

            // bordor right
            if (style.BorderThickness.Right > 0)
            {
                sb.Append($@"\brdrr\brdrs\brdrw10\brsp60\brdrcf{colorIndex}");
            }
        }
        
        // Horizontal alignment
        switch (style.TextAlignment)
        {
            case TextAlignment.Left:
                sb.Append("\\ql");
                break;
            case TextAlignment.Right:
                sb.Append("\\qr");
                break;
            case TextAlignment.Center:
                sb.Append("\\qc");
                break;
            case TextAlignment.Justify:
                sb.Append("\\qj");
                break;
        }

        // Italic
        if (style.Italic)
        {
            sb.Append("\\i");
        }

        // Bold
        if (style.Bold)
        {
            sb.Append("\\b");
        }

        // Pagebreak before?
        if (style.PageBreakBefore)
        {
            sb.Append("\\pagebb");
        }

        // keep with next paragraph
        if (style.PageBreakBefore)
        {
            sb.Append("\\keepn");
        }

        // keep paragraph together
        if (style.KeepTogether)
        {
            sb.Append("\\keep");
        }

        return sb;
    }
}