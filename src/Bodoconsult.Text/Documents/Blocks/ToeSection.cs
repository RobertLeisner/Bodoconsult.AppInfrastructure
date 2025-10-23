// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Section containing an automatically caclulated table-of-equiation (TOE) section. All blocks and inlines are cleared before calculation of TOE during rendering process
/// </summary>
public class ToeSection : SectionBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public ToeSection()
    {
        TagToUse = "ToeSection";
        IncludeInToc = false;
        DoNotIncludeInNumbering = true;
        AllowedBlocks.Add(typeof(Toe));
        PageBreakBefore = true;
        PageNumberFormat = PageNumberFormatEnum.UpperRoman;
    }
}