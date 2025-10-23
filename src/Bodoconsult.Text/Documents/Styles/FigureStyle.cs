// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for <see cref="Figure"/> instances
/// </summary>
public class FigureStyle : ImageStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public FigureStyle()
    {
        TagToUse = "FigureStyle";
        Name = TagToUse;
    }
}