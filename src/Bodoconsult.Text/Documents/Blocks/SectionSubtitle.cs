// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System;
using System.Collections.Generic;
using Bodoconsult.Text.Helpers;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// SectionSubtitle
/// </summary>
public class SectionSubtitle : ParagraphBase
{
    /// <summary>
    /// Static list with all allowed inline elements for paragraphs
    /// </summary>
    public static List<Type> AllAllowedInlines =
    [
        typeof(Span),
        typeof(Bold),
        typeof(Italic),
        typeof(LineBreak)
    ];


    /// <summary>
    /// Default ctor
    /// </summary>
    public SectionSubtitle()
    {
        // No blocks allowed

        // Add allowed inlines
        AllowedInlines.AddRange(AllAllowedInlines);

        TagToUse = string.Intern("SectionSubtitle");
    }

    /// <summary>
    /// Ctor with string content
    /// </summary>
    public SectionSubtitle(string content)
    {
        // No blocks allowed

        // Add allowed inlines
        AllowedInlines.AddRange(AllAllowedInlines);

        TagToUse = string.Intern("SectionSubtitle");

        ElementContentParser.Parse(content, this);
    }
}