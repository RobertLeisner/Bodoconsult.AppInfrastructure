// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Section containing an automatically caclulated table-of-content (TOC) section. All blocks and inlines are cleared before calculation of TOC during rendering process
/// </summary>
public class TocSection : SectionBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public TocSection()
    {
        TagToUse = "TocSection";
        IncludeInToc = false;
        DoNotIncludeInNumbering = true;
        AllowedBlocks.Clear();
        AllowedBlocks.Add(typeof(Toc1));
        AllowedBlocks.Add(typeof(Toc2));
        AllowedBlocks.Add(typeof(Toc3));
        AllowedBlocks.Add(typeof(Toc4));
        AllowedBlocks.Add(typeof(Toc5));
        PageBreakBefore = true;
        PageNumberFormat = PageNumberFormatEnum.UpperRoman;
    }
}