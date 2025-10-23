// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System;
using System.Collections.Generic;
using Bodoconsult.Text.Helpers;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Tof element for TOF content
/// </summary>
public class Tof : ParagraphBase
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
    public Tof()
    {
        // No blocks allowed

        // Add allowed inlines
        AllowedInlines.AddRange(AllAllowedInlines);

        TagToUse = string.Intern("Tof");
    }

    /// <summary>
    /// Ctor with string content
    /// </summary>
    public Tof(string content)
    {
        // No blocks allowed

        // Add allowed inlines
        AllowedInlines.AddRange(AllAllowedInlines);

        TagToUse = string.Intern("Tof");

        ElementContentParser.Parse(content, this);
    }
}