// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System;
using System.Collections.Generic;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Italic text span
/// </summary>
public class Italic : SpanBase
{
    /// <summary>
    /// Static list with all allowed inline elements for paragraphs
    /// </summary>
    public static List<Type> AllAllowedInlines =
    [
        typeof(Bold),
        typeof(LineBreak)
    ];

    /// <summary>
    /// Default ctor
    /// </summary>
    public Italic()
    {
        // Add allowed child inlines
        AllowedInlines.AddRange(AllAllowedInlines);
        
        // Tag to use
        TagToUse = string.Intern("Italic");
    }

    /// <summary>
    /// Ctor to load content
    /// </summary>
    /// <param name="content">Content</param>
    public Italic(string content)
    {
        // Add allowed child inlines
        AllowedInlines.Add(typeof(Bold));
        AllowedInlines.Add(typeof(Hyperlink));

        // Tag to use
        TagToUse = string.Intern("Italic");

        Content = content;
    }

}