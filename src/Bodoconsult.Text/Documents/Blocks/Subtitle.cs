// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System;
using System.Collections.Generic;
using Bodoconsult.Text.Helpers;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Subtitle
/// </summary>
public class Subtitle : ParagraphBase
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
    public Subtitle()
    {
        // No blocks allowed

        // Add allowed inlines
        AllowedInlines.AddRange(AllAllowedInlines);

        TagToUse = string.Intern("Subtitle");
    }

    /// <summary>
    /// Ctor with string content
    /// </summary>
    public Subtitle(string content)
    {
        // No blocks allowed

        // Add allowed inlines
        AllowedInlines.AddRange(AllAllowedInlines);

        TagToUse = string.Intern("Subtitle");

        ElementContentParser.Parse(content, this);
    }
}