// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for <see cref="Column"/> instances
/// </summary>
public class ColumnStyle : StyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public ColumnStyle()
    {
        TagToUse = "ColumnStyle";
        Name = TagToUse;
    }
}