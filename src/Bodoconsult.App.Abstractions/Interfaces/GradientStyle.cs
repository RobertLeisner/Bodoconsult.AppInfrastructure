// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

namespace Bodoconsult.App.Abstractions.Interfaces;

/// <summary>
/// Specifies a gradient style to be used for a chart element.
/// </summary>
public enum GradientStyle
{
#pragma warning disable 1591
    None,
    LeftRight,
    TopBottom,
    Center,
    DiagonalLeft,
    DiagonalRight,
    HorizontalCenter,
    VerticalCenter,
#pragma warning restore 1591
}