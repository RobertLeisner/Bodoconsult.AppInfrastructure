// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

/*
 *
 *
 * System.Windows.Media is part of the WPF environment by Microsoft.

 * System.Windows.Media is released as open source under the MIT license

 * License-Url: https://github.com/dotnet/wpf/blob/main/LICENSE.TXT

 * Project-Url: https://github.com/dotnet/wpf

 * The MIT License (MIT)

 * Copyright (c) .NET Foundation and Contributors

 * All rights reserved.

 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:

 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.

 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

namespace Bodoconsult.App.Abstractions.Interfaces;

/// <summary>
/// Colors - A collection of well-known Colors
/// </summary>
public static class TypoColors
{
    #region Constructors

    // Colors only has static members, so it shouldn't be constructable.

    #endregion Constructors

    #region static Known Colors

    /// <summary>
    /// Well-known color: AliceBlue
    /// </summary>
    public static TypoColor AliceBlue => TypoColor.FromUInt32((uint)KnownColor.AliceBlue);

    /// <summary>
    /// Well-known color: AntiqueWhite
    /// </summary>
    public static TypoColor AntiqueWhite => TypoColor.FromUInt32((uint)KnownColor.AntiqueWhite);

    /// <summary>
    /// Well-known color: Aqua
    /// </summary>
    public static TypoColor Aqua => TypoColor.FromUInt32((uint)KnownColor.Aqua);

    /// <summary>
    /// Well-known color: Aquamarine
    /// </summary>
    public static TypoColor Aquamarine => TypoColor.FromUInt32((uint)KnownColor.Aquamarine);

    /// <summary>
    /// Well-known color: Azure
    /// </summary>
    public static TypoColor Azure => TypoColor.FromUInt32((uint)KnownColor.Azure);

    /// <summary>
    /// Well-known color: Beige
    /// </summary>
    public static TypoColor Beige => TypoColor.FromUInt32((uint)KnownColor.Beige);

    /// <summary>
    /// Well-known color: Bisque
    /// </summary>
    public static TypoColor Bisque => TypoColor.FromUInt32((uint)KnownColor.Bisque);

    /// <summary>
    /// Well-known color: Black
    /// </summary>
    public static TypoColor Black => TypoColor.FromUInt32((uint)KnownColor.Black);

    /// <summary>
    /// Well-known color: BlanchedAlmond
    /// </summary>
    public static TypoColor BlanchedAlmond => TypoColor.FromUInt32((uint)KnownColor.BlanchedAlmond);

    /// <summary>
    /// Well-known color: Blue
    /// </summary>
    public static TypoColor Blue => TypoColor.FromUInt32((uint)KnownColor.Blue);

    /// <summary>
    /// Well-known color: BlueViolet
    /// </summary>
    public static TypoColor BlueViolet => TypoColor.FromUInt32((uint)KnownColor.BlueViolet);

    /// <summary>
    /// Well-known color: Brown
    /// </summary>
    public static TypoColor Brown => TypoColor.FromUInt32((uint)KnownColor.Brown);

    /// <summary>
    /// Well-known color: BurlyWood
    /// </summary>
    public static TypoColor BurlyWood => TypoColor.FromUInt32((uint)KnownColor.BurlyWood);

    /// <summary>
    /// Well-known color: CadetBlue
    /// </summary>
    public static TypoColor CadetBlue => TypoColor.FromUInt32((uint)KnownColor.CadetBlue);

    /// <summary>
    /// Well-known color: Chartreuse
    /// </summary>
    public static TypoColor Chartreuse => TypoColor.FromUInt32((uint)KnownColor.Chartreuse);

    /// <summary>
    /// Well-known color: Chocolate
    /// </summary>
    public static TypoColor Chocolate => TypoColor.FromUInt32((uint)KnownColor.Chocolate);

    /// <summary>
    /// Well-known color: Coral
    /// </summary>
    public static TypoColor Coral => TypoColor.FromUInt32((uint)KnownColor.Coral);

    /// <summary>
    /// Well-known color: CornflowerBlue
    /// </summary>
    public static TypoColor CornflowerBlue => TypoColor.FromUInt32((uint)KnownColor.CornflowerBlue);

    /// <summary>
    /// Well-known color: Cornsilk
    /// </summary>
    public static TypoColor Cornsilk => TypoColor.FromUInt32((uint)KnownColor.Cornsilk);

    /// <summary>
    /// Well-known color: Crimson
    /// </summary>
    public static TypoColor Crimson => TypoColor.FromUInt32((uint)KnownColor.Crimson);

    /// <summary>
    /// Well-known color: Cyan
    /// </summary>
    public static TypoColor Cyan => TypoColor.FromUInt32((uint)KnownColor.Cyan);

    /// <summary>
    /// Well-known color: DarkBlue
    /// </summary>
    public static TypoColor DarkBlue => TypoColor.FromUInt32((uint)KnownColor.DarkBlue);

    /// <summary>
    /// Well-known color: DarkCyan
    /// </summary>
    public static TypoColor DarkCyan => TypoColor.FromUInt32((uint)KnownColor.DarkCyan);

    /// <summary>
    /// Well-known color: DarkGoldenrod
    /// </summary>
    public static TypoColor DarkGoldenrod => TypoColor.FromUInt32((uint)KnownColor.DarkGoldenrod);

    /// <summary>
    /// Well-known color: DarkGray
    /// </summary>
    public static TypoColor DarkGray => TypoColor.FromUInt32((uint)KnownColor.DarkGray);

    /// <summary>
    /// Well-known color: DarkGreen
    /// </summary>
    public static TypoColor DarkGreen => TypoColor.FromUInt32((uint)KnownColor.DarkGreen);

    /// <summary>
    /// Well-known color: DarkKhaki
    /// </summary>
    public static TypoColor DarkKhaki => TypoColor.FromUInt32((uint)KnownColor.DarkKhaki);

    /// <summary>
    /// Well-known color: DarkMagenta
    /// </summary>
    public static TypoColor DarkMagenta => TypoColor.FromUInt32((uint)KnownColor.DarkMagenta);

    /// <summary>
    /// Well-known color: DarkOliveGreen
    /// </summary>
    public static TypoColor DarkOliveGreen => TypoColor.FromUInt32((uint)KnownColor.DarkOliveGreen);

    /// <summary>
    /// Well-known color: DarkOrange
    /// </summary>
    public static TypoColor DarkOrange => TypoColor.FromUInt32((uint)KnownColor.DarkOrange);

    /// <summary>
    /// Well-known color: DarkOrchid
    /// </summary>
    public static TypoColor DarkOrchid => TypoColor.FromUInt32((uint)KnownColor.DarkOrchid);

    /// <summary>
    /// Well-known color: DarkRed
    /// </summary>
    public static TypoColor DarkRed => TypoColor.FromUInt32((uint)KnownColor.DarkRed);

    /// <summary>
    /// Well-known color: DarkSalmon
    /// </summary>
    public static TypoColor DarkSalmon => TypoColor.FromUInt32((uint)KnownColor.DarkSalmon);

    /// <summary>
    /// Well-known color: DarkSeaGreen
    /// </summary>
    public static TypoColor DarkSeaGreen => TypoColor.FromUInt32((uint)KnownColor.DarkSeaGreen);

    /// <summary>
    /// Well-known color: DarkSlateBlue
    /// </summary>
    public static TypoColor DarkSlateBlue => TypoColor.FromUInt32((uint)KnownColor.DarkSlateBlue);

    /// <summary>
    /// Well-known color: DarkSlateGray
    /// </summary>
    public static TypoColor DarkSlateGray => TypoColor.FromUInt32((uint)KnownColor.DarkSlateGray);

    /// <summary>
    /// Well-known color: DarkTurquoise
    /// </summary>
    public static TypoColor DarkTurquoise => TypoColor.FromUInt32((uint)KnownColor.DarkTurquoise);

    /// <summary>
    /// Well-known color: DarkViolet
    /// </summary>
    public static TypoColor DarkViolet => TypoColor.FromUInt32((uint)KnownColor.DarkViolet);

    /// <summary>
    /// Well-known color: DeepPink
    /// </summary>
    public static TypoColor DeepPink => TypoColor.FromUInt32((uint)KnownColor.DeepPink);

    /// <summary>
    /// Well-known color: DeepSkyBlue
    /// </summary>
    public static TypoColor DeepSkyBlue => TypoColor.FromUInt32((uint)KnownColor.DeepSkyBlue);

    /// <summary>
    /// Well-known color: DimGray
    /// </summary>
    public static TypoColor DimGray => TypoColor.FromUInt32((uint)KnownColor.DimGray);

    /// <summary>
    /// Well-known color: DodgerBlue
    /// </summary>
    public static TypoColor DodgerBlue => TypoColor.FromUInt32((uint)KnownColor.DodgerBlue);

    /// <summary>
    /// Well-known color: Firebrick
    /// </summary>
    public static TypoColor Firebrick => TypoColor.FromUInt32((uint)KnownColor.Firebrick);

    /// <summary>
    /// Well-known color: FloralWhite
    /// </summary>
    public static TypoColor FloralWhite => TypoColor.FromUInt32((uint)KnownColor.FloralWhite);

    /// <summary>
    /// Well-known color: ForestGreen
    /// </summary>
    public static TypoColor ForestGreen => TypoColor.FromUInt32((uint)KnownColor.ForestGreen);

    /// <summary>
    /// Well-known color: Fuchsia
    /// </summary>
    public static TypoColor Fuchsia => TypoColor.FromUInt32((uint)KnownColor.Fuchsia);

    /// <summary>
    /// Well-known color: Gainsboro
    /// </summary>
    public static TypoColor Gainsboro => TypoColor.FromUInt32((uint)KnownColor.Gainsboro);

    /// <summary>
    /// Well-known color: GhostWhite
    /// </summary>
    public static TypoColor GhostWhite => TypoColor.FromUInt32((uint)KnownColor.GhostWhite);

    /// <summary>
    /// Well-known color: Gold
    /// </summary>
    public static TypoColor Gold => TypoColor.FromUInt32((uint)KnownColor.Gold);

    /// <summary>
    /// Well-known color: Goldenrod
    /// </summary>
    public static TypoColor Goldenrod => TypoColor.FromUInt32((uint)KnownColor.Goldenrod);

    /// <summary>
    /// Well-known color: Gray
    /// </summary>
    public static TypoColor Gray => TypoColor.FromUInt32((uint)KnownColor.Gray);

    /// <summary>
    /// Well-known color: Green
    /// </summary>
    public static TypoColor Green => TypoColor.FromUInt32((uint)KnownColor.Green);

    /// <summary>
    /// Well-known color: GreenYellow
    /// </summary>
    public static TypoColor GreenYellow => TypoColor.FromUInt32((uint)KnownColor.GreenYellow);

    /// <summary>
    /// Well-known color: Honeydew
    /// </summary>
    public static TypoColor Honeydew => TypoColor.FromUInt32((uint)KnownColor.Honeydew);

    /// <summary>
    /// Well-known color: HotPink
    /// </summary>
    public static TypoColor HotPink => TypoColor.FromUInt32((uint)KnownColor.HotPink);

    /// <summary>
    /// Well-known color: IndianRed
    /// </summary>
    public static TypoColor IndianRed => TypoColor.FromUInt32((uint)KnownColor.IndianRed);

    /// <summary>
    /// Well-known color: Indigo
    /// </summary>
    public static TypoColor Indigo => TypoColor.FromUInt32((uint)KnownColor.Indigo);

    /// <summary>
    /// Well-known color: Ivory
    /// </summary>
    public static TypoColor Ivory => TypoColor.FromUInt32((uint)KnownColor.Ivory);

    /// <summary>
    /// Well-known color: Khaki
    /// </summary>
    public static TypoColor Khaki => TypoColor.FromUInt32((uint)KnownColor.Khaki);

    /// <summary>
    /// Well-known color: Lavender
    /// </summary>
    public static TypoColor Lavender => TypoColor.FromUInt32((uint)KnownColor.Lavender);

    /// <summary>
    /// Well-known color: LavenderBlush
    /// </summary>
    public static TypoColor LavenderBlush => TypoColor.FromUInt32((uint)KnownColor.LavenderBlush);

    /// <summary>
    /// Well-known color: LawnGreen
    /// </summary>
    public static TypoColor LawnGreen => TypoColor.FromUInt32((uint)KnownColor.LawnGreen);

    /// <summary>
    /// Well-known color: LemonChiffon
    /// </summary>
    public static TypoColor LemonChiffon => TypoColor.FromUInt32((uint)KnownColor.LemonChiffon);

    /// <summary>
    /// Well-known color: LightBlue
    /// </summary>
    public static TypoColor LightBlue => TypoColor.FromUInt32((uint)KnownColor.LightBlue);

    /// <summary>
    /// Well-known color: LightCoral
    /// </summary>
    public static TypoColor LightCoral => TypoColor.FromUInt32((uint)KnownColor.LightCoral);

    /// <summary>
    /// Well-known color: LightCyan
    /// </summary>
    public static TypoColor LightCyan => TypoColor.FromUInt32((uint)KnownColor.LightCyan);

    /// <summary>
    /// Well-known color: LightGoldenrodYellow
    /// </summary>
    public static TypoColor LightGoldenrodYellow => TypoColor.FromUInt32((uint)KnownColor.LightGoldenrodYellow);

    /// <summary>
    /// Well-known color: LightGray
    /// </summary>
    public static TypoColor LightGray => TypoColor.FromUInt32((uint)KnownColor.LightGray);

    /// <summary>
    /// Well-known color: LightGreen
    /// </summary>
    public static TypoColor LightGreen => TypoColor.FromUInt32((uint)KnownColor.LightGreen);

    /// <summary>
    /// Well-known color: LightPink
    /// </summary>
    public static TypoColor LightPink => TypoColor.FromUInt32((uint)KnownColor.LightPink);

    /// <summary>
    /// Well-known color: LightSalmon
    /// </summary>
    public static TypoColor LightSalmon => TypoColor.FromUInt32((uint)KnownColor.LightSalmon);

    /// <summary>
    /// Well-known color: LightSeaGreen
    /// </summary>
    public static TypoColor LightSeaGreen => TypoColor.FromUInt32((uint)KnownColor.LightSeaGreen);

    /// <summary>
    /// Well-known color: LightSkyBlue
    /// </summary>
    public static TypoColor LightSkyBlue => TypoColor.FromUInt32((uint)KnownColor.LightSkyBlue);

    /// <summary>
    /// Well-known color: LightSlateGray
    /// </summary>
    public static TypoColor LightSlateGray => TypoColor.FromUInt32((uint)KnownColor.LightSlateGray);

    /// <summary>
    /// Well-known color: LightSteelBlue
    /// </summary>
    public static TypoColor LightSteelBlue => TypoColor.FromUInt32((uint)KnownColor.LightSteelBlue);

    /// <summary>
    /// Well-known color: LightYellow
    /// </summary>
    public static TypoColor LightYellow => TypoColor.FromUInt32((uint)KnownColor.LightYellow);

    /// <summary>
    /// Well-known color: Lime
    /// </summary>
    public static TypoColor Lime => TypoColor.FromUInt32((uint)KnownColor.Lime);

    /// <summary>
    /// Well-known color: LimeGreen
    /// </summary>
    public static TypoColor LimeGreen => TypoColor.FromUInt32((uint)KnownColor.LimeGreen);

    /// <summary>
    /// Well-known color: Linen
    /// </summary>
    public static TypoColor Linen => TypoColor.FromUInt32((uint)KnownColor.Linen);

    /// <summary>
    /// Well-known color: Magenta
    /// </summary>
    public static TypoColor Magenta => TypoColor.FromUInt32((uint)KnownColor.Magenta);

    /// <summary>
    /// Well-known color: Maroon
    /// </summary>
    public static TypoColor Maroon => TypoColor.FromUInt32((uint)KnownColor.Maroon);

    /// <summary>
    /// Well-known color: MediumAquamarine
    /// </summary>
    public static TypoColor MediumAquamarine => TypoColor.FromUInt32((uint)KnownColor.MediumAquamarine);

    /// <summary>
    /// Well-known color: MediumBlue
    /// </summary>
    public static TypoColor MediumBlue => TypoColor.FromUInt32((uint)KnownColor.MediumBlue);

    /// <summary>
    /// Well-known color: MediumOrchid
    /// </summary>
    public static TypoColor MediumOrchid => TypoColor.FromUInt32((uint)KnownColor.MediumOrchid);

    /// <summary>
    /// Well-known color: MediumPurple
    /// </summary>
    public static TypoColor MediumPurple => TypoColor.FromUInt32((uint)KnownColor.MediumPurple);

    /// <summary>
    /// Well-known color: MediumSeaGreen
    /// </summary>
    public static TypoColor MediumSeaGreen => TypoColor.FromUInt32((uint)KnownColor.MediumSeaGreen);

    /// <summary>
    /// Well-known color: MediumSlateBlue
    /// </summary>
    public static TypoColor MediumSlateBlue => TypoColor.FromUInt32((uint)KnownColor.MediumSlateBlue);

    /// <summary>
    /// Well-known color: MediumSpringGreen
    /// </summary>
    public static TypoColor MediumSpringGreen => TypoColor.FromUInt32((uint)KnownColor.MediumSpringGreen);

    /// <summary>
    /// Well-known color: MediumTurquoise
    /// </summary>
    public static TypoColor MediumTurquoise => TypoColor.FromUInt32((uint)KnownColor.MediumTurquoise);

    /// <summary>
    /// Well-known color: MediumVioletRed
    /// </summary>
    public static TypoColor MediumVioletRed => TypoColor.FromUInt32((uint)KnownColor.MediumVioletRed);

    /// <summary>
    /// Well-known color: MidnightBlue
    /// </summary>
    public static TypoColor MidnightBlue => TypoColor.FromUInt32((uint)KnownColor.MidnightBlue);

    /// <summary>
    /// Well-known color: MintCream
    /// </summary>
    public static TypoColor MintCream => TypoColor.FromUInt32((uint)KnownColor.MintCream);

    /// <summary>
    /// Well-known color: MistyRose
    /// </summary>
    public static TypoColor MistyRose => TypoColor.FromUInt32((uint)KnownColor.MistyRose);

    /// <summary>
    /// Well-known color: Moccasin
    /// </summary>
    public static TypoColor Moccasin => TypoColor.FromUInt32((uint)KnownColor.Moccasin);

    /// <summary>
    /// Well-known color: NavajoWhite
    /// </summary>
    public static TypoColor NavajoWhite => TypoColor.FromUInt32((uint)KnownColor.NavajoWhite);

    /// <summary>
    /// Well-known color: Navy
    /// </summary>
    public static TypoColor Navy => TypoColor.FromUInt32((uint)KnownColor.Navy);

    /// <summary>
    /// Well-known color: OldLace
    /// </summary>
    public static TypoColor OldLace => TypoColor.FromUInt32((uint)KnownColor.OldLace);

    /// <summary>
    /// Well-known color: Olive
    /// </summary>
    public static TypoColor Olive => TypoColor.FromUInt32((uint)KnownColor.Olive);

    /// <summary>
    /// Well-known color: OliveDrab
    /// </summary>
    public static TypoColor OliveDrab => TypoColor.FromUInt32((uint)KnownColor.OliveDrab);

    /// <summary>
    /// Well-known color: Orange
    /// </summary>
    public static TypoColor Orange => TypoColor.FromUInt32((uint)KnownColor.Orange);

    /// <summary>
    /// Well-known color: OrangeRed
    /// </summary>
    public static TypoColor OrangeRed => TypoColor.FromUInt32((uint)KnownColor.OrangeRed);

    /// <summary>
    /// Well-known color: Orchid
    /// </summary>
    public static TypoColor Orchid => TypoColor.FromUInt32((uint)KnownColor.Orchid);

    /// <summary>
    /// Well-known color: PaleGoldenrod
    /// </summary>
    public static TypoColor PaleGoldenrod => TypoColor.FromUInt32((uint)KnownColor.PaleGoldenrod);

    /// <summary>
    /// Well-known color: PaleGreen
    /// </summary>
    public static TypoColor PaleGreen => TypoColor.FromUInt32((uint)KnownColor.PaleGreen);

    /// <summary>
    /// Well-known color: PaleTurquoise
    /// </summary>
    public static TypoColor PaleTurquoise => TypoColor.FromUInt32((uint)KnownColor.PaleTurquoise);

    /// <summary>
    /// Well-known color: PaleVioletRed
    /// </summary>
    public static TypoColor PaleVioletRed => TypoColor.FromUInt32((uint)KnownColor.PaleVioletRed);

    /// <summary>
    /// Well-known color: PapayaWhip
    /// </summary>
    public static TypoColor PapayaWhip => TypoColor.FromUInt32((uint)KnownColor.PapayaWhip);

    /// <summary>
    /// Well-known color: PeachPuff
    /// </summary>
    public static TypoColor PeachPuff => TypoColor.FromUInt32((uint)KnownColor.PeachPuff);

    /// <summary>
    /// Well-known color: Peru
    /// </summary>
    public static TypoColor Peru => TypoColor.FromUInt32((uint)KnownColor.Peru);

    /// <summary>
    /// Well-known color: Pink
    /// </summary>
    public static TypoColor Pink => TypoColor.FromUInt32((uint)KnownColor.Pink);

    /// <summary>
    /// Well-known color: Plum
    /// </summary>
    public static TypoColor Plum => TypoColor.FromUInt32((uint)KnownColor.Plum);

    /// <summary>
    /// Well-known color: PowderBlue
    /// </summary>
    public static TypoColor PowderBlue => TypoColor.FromUInt32((uint)KnownColor.PowderBlue);

    /// <summary>
    /// Well-known color: Purple
    /// </summary>
    public static TypoColor Purple => TypoColor.FromUInt32((uint)KnownColor.Purple);

    /// <summary>
    /// Well-known color: Red
    /// </summary>
    public static TypoColor Red => TypoColor.FromUInt32((uint)KnownColor.Red);

    /// <summary>
    /// Well-known color: RosyBrown
    /// </summary>
    public static TypoColor RosyBrown => TypoColor.FromUInt32((uint)KnownColor.RosyBrown);

    /// <summary>
    /// Well-known color: RoyalBlue
    /// </summary>
    public static TypoColor RoyalBlue => TypoColor.FromUInt32((uint)KnownColor.RoyalBlue);

    /// <summary>
    /// Well-known color: SaddleBrown
    /// </summary>
    public static TypoColor SaddleBrown => TypoColor.FromUInt32((uint)KnownColor.SaddleBrown);

    /// <summary>
    /// Well-known color: Salmon
    /// </summary>
    public static TypoColor Salmon => TypoColor.FromUInt32((uint)KnownColor.Salmon);

    /// <summary>
    /// Well-known color: SandyBrown
    /// </summary>
    public static TypoColor SandyBrown => TypoColor.FromUInt32((uint)KnownColor.SandyBrown);

    /// <summary>
    /// Well-known color: SeaGreen
    /// </summary>
    public static TypoColor SeaGreen => TypoColor.FromUInt32((uint)KnownColor.SeaGreen);

    /// <summary>
    /// Well-known color: SeaShell
    /// </summary>
    public static TypoColor SeaShell => TypoColor.FromUInt32((uint)KnownColor.SeaShell);

    /// <summary>
    /// Well-known color: Sienna
    /// </summary>
    public static TypoColor Sienna => TypoColor.FromUInt32((uint)KnownColor.Sienna);

    /// <summary>
    /// Well-known color: Silver
    /// </summary>
    public static TypoColor Silver => TypoColor.FromUInt32((uint)KnownColor.Silver);

    /// <summary>
    /// Well-known color: SkyBlue
    /// </summary>
    public static TypoColor SkyBlue => TypoColor.FromUInt32((uint)KnownColor.SkyBlue);

    /// <summary>
    /// Well-known color: SlateBlue
    /// </summary>
    public static TypoColor SlateBlue => TypoColor.FromUInt32((uint)KnownColor.SlateBlue);

    /// <summary>
    /// Well-known color: SlateGray
    /// </summary>
    public static TypoColor SlateGray => TypoColor.FromUInt32((uint)KnownColor.SlateGray);

    /// <summary>
    /// Well-known color: Snow
    /// </summary>
    public static TypoColor Snow => TypoColor.FromUInt32((uint)KnownColor.Snow);

    /// <summary>
    /// Well-known color: SpringGreen
    /// </summary>
    public static TypoColor SpringGreen => TypoColor.FromUInt32((uint)KnownColor.SpringGreen);

    /// <summary>
    /// Well-known color: SteelBlue
    /// </summary>
    public static TypoColor SteelBlue => TypoColor.FromUInt32((uint)KnownColor.SteelBlue);

    /// <summary>
    /// Well-known color: Tan
    /// </summary>
    public static TypoColor Tan => TypoColor.FromUInt32((uint)KnownColor.Tan);

    /// <summary>
    /// Well-known color: Teal
    /// </summary>
    public static TypoColor Teal => TypoColor.FromUInt32((uint)KnownColor.Teal);

    /// <summary>
    /// Well-known color: Thistle
    /// </summary>
    public static TypoColor Thistle => TypoColor.FromUInt32((uint)KnownColor.Thistle);

    /// <summary>
    /// Well-known color: Tomato
    /// </summary>
    public static TypoColor Tomato => TypoColor.FromUInt32((uint)KnownColor.Tomato);

    /// <summary>
    /// Well-known color: Transparent
    /// </summary>
    public static TypoColor Transparent => TypoColor.FromUInt32((uint)KnownColor.Transparent);

    /// <summary>
    /// Well-known color: Turquoise
    /// </summary>
    public static TypoColor Turquoise => TypoColor.FromUInt32((uint)KnownColor.Turquoise);

    /// <summary>
    /// Well-known color: Violet
    /// </summary>
    public static TypoColor Violet => TypoColor.FromUInt32((uint)KnownColor.Violet);

    /// <summary>
    /// Well-known color: Wheat
    /// </summary>
    public static TypoColor Wheat => TypoColor.FromUInt32((uint)KnownColor.Wheat);

    /// <summary>
    /// Well-known color: White
    /// </summary>
    public static TypoColor White => TypoColor.FromUInt32((uint)KnownColor.White);

    /// <summary>
    /// Well-known color: WhiteSmoke
    /// </summary>
    public static TypoColor WhiteSmoke => TypoColor.FromUInt32((uint)KnownColor.WhiteSmoke);

    /// <summary>
    /// Well-known color: Yellow
    /// </summary>
    public static TypoColor Yellow => TypoColor.FromUInt32((uint)KnownColor.Yellow);

    /// <summary>
    /// Well-known color: YellowGreen
    /// </summary>
    public static TypoColor YellowGreen => TypoColor.FromUInt32((uint)KnownColor.YellowGreen);

    #endregion static Known Colors
}