// Copyright (c) Bodoconsult EDV-Dienstleistungen. All rights reserved.

using Bodoconsult.App.Abstractions.Interfaces;
using ScottPlot;
using SkiaSharp;

namespace Bodoconsult.Charting.Extensions;

/// <summary>
/// Extension methods for <see cref="TypoColor"/>
/// </summary>
public static class TypoColorExtensions
{
    /// <summary>
    /// Map a <see cref="TypoColor"/> instance in a <see cref="ScottPlot.Color"/>
    /// </summary>
    /// <param name="typoColor">Typo color instance</param>
    /// <returns>ScottPlot color instance</returns>
    public static Color ToScottPlotColor(this TypoColor typoColor)
    {
        return new Color(typoColor.R, typoColor.G, typoColor.B, typoColor.A);
    }

    /// <summary>
    /// Map a <see cref="TypoColor"/> instance in a <see cref="SKColor"/>
    /// </summary>
    /// <param name="typoColor">Typo color instance</param>
    /// <returns>ScottPlot color instance</returns>
    public static SKColor ToSkiaColor(this TypoColor typoColor)
    {
        return new SKColor(typoColor.R, typoColor.G, typoColor.B, typoColor.A);
    }
}