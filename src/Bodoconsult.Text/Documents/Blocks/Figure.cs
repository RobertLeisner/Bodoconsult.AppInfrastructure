// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System;
using System.Collections.Generic;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Image text
/// </summary>
public sealed class Figure : ImageBase
{
    /// <summary>
    /// Static list with all allowed inline elements for paragraphs
    /// </summary>
    public static List<Type> AllAllowedInlines =
    [
        typeof(Span),
        typeof(Bold),
        typeof(Italic),
        typeof(Hyperlink)
    ];

    /// <summary>
    /// Default ctor
    /// </summary>
    public Figure()
    {
        // Add allowed child inlines
        AllowedInlines.AddRange(AllAllowedInlines);

        // Tag to use
        TagToUse = string.Intern("Figure");
    }

    /// <summary>
    /// Ctor to load content
    /// </summary>
    /// <param name="content">Content</param>
    /// <param name="uri">URL of the equation image. Local file path, UNC path or a web link</param>
    public Figure(string content, string uri)
    {
        // Add allowed child inlines
        AllowedInlines.Add(typeof(Span));
        AllowedInlines.Add(typeof(Bold));
        AllowedInlines.Add(typeof(Italic));
        AllowedInlines.Add(typeof(Hyperlink));

        // Tag to use
        TagToUse = string.Intern("Figure");

        AddInline(new Span(content));
        Uri = uri;
    }
}