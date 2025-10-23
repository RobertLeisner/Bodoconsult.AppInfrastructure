// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for <see cref="Equation"/> instances
/// </summary>
public class EquationStyle : ImageStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public EquationStyle()
    {
        TagToUse = "EquationStyle";
        Name = TagToUse;
    }
}