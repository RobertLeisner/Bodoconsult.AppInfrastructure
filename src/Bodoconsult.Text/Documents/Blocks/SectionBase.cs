// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System;
using System.Collections.Generic;
using System.Text;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Base class for sections
/// </summary>
public abstract class SectionBase : Block
{

    /// <summary>
    /// Static list with all allowed inline elements for paragraphs
    /// </summary>
    public static List<Type> AllAllowedBlocks =
    [
        typeof(Paragraph),
        typeof(Heading1),
        typeof(Heading2),
        typeof(Heading3),
        typeof(Heading4),
        typeof(Heading5),
        typeof(Title),
        typeof(Subtitle),
        typeof(SectionTitle),
        typeof(SectionSubtitle),
        typeof(Toc1),
        typeof(Toc2),
        typeof(Toc3),
        typeof(Toc4),
        typeof(Toc5),
        typeof(ParagraphCenter),
        typeof(ParagraphJustify),
        typeof(ParagraphRight),
        typeof(Image),
        typeof(Figure),
        typeof(Equation),
        typeof(List),
        typeof(Citation),
        typeof(Code),
        typeof(Error),
        typeof(Warning),
        typeof(Info),
        typeof(Table),
        typeof(DefinitionList)
    ];

    /// <summary>
    /// Default ctor
    /// </summary>
    protected SectionBase()
    {
        // Add all allowed blocks
        AllowedBlocks.AddRange(AllAllowedBlocks);

        // No inlines allowed

        // Tag
        TagToUse = string.Intern("Section");
    }

    /// <summary>
    /// Inherit the page settings from document. Default: true
    /// </summary>
    public bool InheritFromParent { get; set; } = true;

    /// <summary>
    /// Include this section in the table of content
    /// </summary>
    public bool IncludeInToc { get; set; } = true;

    /// <summary>
    /// Add a page break before the section
    /// </summary>
    public bool PageBreakBefore { get; set; }

    /// <summary>
    /// Is the section the first section. Default false
    /// </summary>
    [DoNotSerialize]
    public bool IsFirstSection { get; set; }

    /// <summary>
    /// Do not include the current section in the numbering for TOC, TOE and TOF
    /// </summary>
    public bool DoNotIncludeInNumbering { get; set; }

    /// <summary>
    /// Is a header required? Default: true
    /// </summary>
    public bool IsHeaderRequired { get; set; } = true;

    /// <summary>
    /// Is a footer required? Default: true
    /// </summary>
    public bool IsFooterRequired { get; set; } = true;

    /// <summary>
    /// Is a restart of the page numbering required? Default: false
    /// </summary>
    public bool IsRestartPageNumberingRequired { get; set; } = false;

    /// <summary>
    /// Page number format
    /// </summary>
    public PageNumberFormatEnum PageNumberFormat { get; set; } = PageNumberFormatEnum.Decimal;
    
    /// <summary>
    /// Add the current element to a document defined in LDML (Logical document markup language)
    /// </summary>
    /// <param name="stringBuilder">StringBuilder instance to create the LDML in</param>
    /// <param name="indent">Current indent</param>
    public override void ToLdmlString(StringBuilder stringBuilder, string indent)
    {
        AddTagWithAttributes(indent, TagToUse, stringBuilder);

        // Add the blocks now
        foreach (var block in ChildBlocks)
        {
            block.ToLdmlString(stringBuilder, $"{indent}{Indentation}");
        }

        stringBuilder.AppendLine($"{indent}</{TagToUse}>");
    }

    /// <summary>
    /// Add an inline element: not allowed on document level
    /// </summary>
    /// <param name="inline">Inline element to add</param>
    public override void AddInline(Inline inline)
    {
        // Do nothing
    }
}