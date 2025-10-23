// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Section containing an automatically caclulated table-of-tables (TOF) section. All blocks and inlines are cleared before calculation of TOT during rendering process
/// </summary>
public class TotSection : SectionBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public TotSection()
    {
        TagToUse = "TotSection";
        IncludeInToc = false;
        DoNotIncludeInNumbering = true;
        AllowedBlocks.Clear();
        AllowedBlocks.Add(typeof(Tot));
        PageBreakBefore = true;
        PageNumberFormat = PageNumberFormatEnum.UpperRoman;
    }
}