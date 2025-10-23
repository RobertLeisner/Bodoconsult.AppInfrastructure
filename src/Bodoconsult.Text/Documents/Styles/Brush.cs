// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Base class for brushes
/// </summary>
public abstract class Brush : PropertyAsBlockElement
{
    /// <summary>
    /// Color to use if only one color is possible to render
    /// </summary>
    public Color Color { get; set; } = Styleset.DefaultColor;
}