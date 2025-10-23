// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System;
using System.Collections.Generic;

namespace Bodoconsult.Text.Documents;

//  https://github.com/verybadcat/CSharpMath

/// <summary>
/// Equation text block
/// </summary>
public sealed class Equation : ImageBase
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
    public Equation()
    {
        // Add allowed child inlines
        AllowedInlines.AddRange(AllAllowedInlines);

        // Tag to use
        TagToUse = string.Intern("Equation");
    }

    /// <summary>
    /// Ctor to load content
    /// </summary>
    /// <param name="content">Content</param>
    /// <param name="uri">URL of the equation image. Local file path, UNC path or a web link</param>
    public Equation(string content, string uri)
    {
        // Add allowed child inlines
        AllowedInlines.Add(typeof(Span));
        AllowedInlines.Add(typeof(Bold));
        AllowedInlines.Add(typeof(Italic));
        AllowedInlines.Add(typeof(Hyperlink));

        // Tag to use
        TagToUse = string.Intern("Equation");

        AddInline(new Span(content));

        Uri = uri;
    }

    /// <summary>
    /// Math equation in LaTex notation
    /// </summary>
    public string LaTex { get; set; }

    /// <summary>
    /// Math equation in MathML notation
    /// </summary>
    public string MathMl { get; set; }

}