// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System;
using System.Collections.Generic;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Bold text span
/// </summary>
public class Bold : SpanBase
{
    /// <summary>
    /// Static list with all allowed inline elements for paragraphs
    /// </summary>
    public static List<Type> AllAllowedInlines =
    [
        typeof(Italic),
        typeof(LineBreak)
    ];

    /// <summary>
    /// Default ctor
    /// </summary>
    public Bold()
    {
        // Add allowed child inlines
        AllowedInlines.AddRange(AllAllowedInlines);

        // Tag to use
        TagToUse = string.Intern("Bold");
    }

    /// <summary>
    /// Ctor to provide content
    /// </summary>
    /// <param name="content">Content</param>
    public Bold(string content)
    {
        // Add allowed child inlines
        AllowedInlines.Add(typeof(Italic));
        AllowedInlines.Add(typeof(Hyperlink));

        // Tag to use
        TagToUse = string.Intern("Bold");

        Content = content;
    }
}