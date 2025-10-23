// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System;
using System.Collections.Generic;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Italic text span
/// </summary>
public class Hyperlink : SpanBase
{
    /// <summary>
    /// Static list with all allowed inline elements for paragraphs
    /// </summary>
    public static List<Type> AllAllowedInlines =
    [
        typeof(Span),
        typeof(Bold),
        typeof(Italic),
    ];

    /// <summary>
    /// Default ctor
    /// </summary>
    public Hyperlink()
    {
        // Add allowed child inlines
        AllowedInlines.AddRange(AllAllowedInlines);

        // Tag to use
        TagToUse = string.Intern("Hyperlink");
    }

    /// <summary>
    /// Ctor to load content
    /// </summary>
    /// <param name="content">Clear text description of the URL</param>
    public Hyperlink(string content)
    {
        // Add allowed child inlines

        // Tag to use
        TagToUse = string.Intern("Hyperlink");

        Content = content;
    }

    /// <summary>
    /// URL of the hyperlink
    /// </summary>
    public string Uri { get; set; }
}