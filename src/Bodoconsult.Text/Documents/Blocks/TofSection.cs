// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Section containing an automatically caclulated table-of-figures (TOF) section. All blocks and inlines are cleared before calculation of TOF during rendering process
/// </summary>
public class TofSection : SectionBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public TofSection()
    {
        TagToUse = "TofSection";
        IncludeInToc = false;
        DoNotIncludeInNumbering = true;
        AllowedBlocks.Clear();
        AllowedBlocks.Add(typeof(Tof));
        PageBreakBefore = true;
        PageNumberFormat = PageNumberFormatEnum.UpperRoman;
    }
}