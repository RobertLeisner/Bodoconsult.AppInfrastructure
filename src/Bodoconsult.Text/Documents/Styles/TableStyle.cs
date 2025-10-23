// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for <see cref="Table"/> instances
/// </summary>
public class TableStyle : StyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public TableStyle()
    {
        TagToUse = "TableStyle";
        Name = TagToUse;
        
    }

    /// <summary>
    /// Margins. Margin left and right are ignored. Table is always centered
    /// </summary>
    public Thickness Margins { get; set; } = new(0, Styleset.DefaultFontSize, 0, 0);

    /// <summary>
    /// Border spacing in pt
    /// </summary>
    public int BorderSpacing { get; set; } = Styleset.DefaultTablePaddingWidth;
}