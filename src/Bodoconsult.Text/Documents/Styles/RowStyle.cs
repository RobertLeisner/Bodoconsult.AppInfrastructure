// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for <see cref="Row"/> instances
/// </summary>
public class RowStyle : StyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public RowStyle()
    {
        TagToUse = "RowStyle";
        Name = TagToUse;
    }
}