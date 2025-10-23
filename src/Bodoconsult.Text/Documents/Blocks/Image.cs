// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System;
using System.Collections.Generic;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Image block
/// </summary>
public sealed class Image : ImageBase
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
    public Image()
    {
        // Add allowed child inlines
        AllowedInlines.AddRange(AllAllowedInlines);

        // Tag to use
        TagToUse = string.Intern("Image");
    }

    /// <summary>
    /// Ctor to load content
    /// </summary>
    /// <param name="content">Content</param>
    /// <param name="uri">URL of the equation image. Local file path, UNC path or a web link</param>
    public Image(string content, string uri)
    {
        // Add allowed child inlines
        AllowedInlines.Add(typeof(Span));
        AllowedInlines.Add(typeof(Bold));
        AllowedInlines.Add(typeof(Italic));
        AllowedInlines.Add(typeof(Hyperlink));

        // Tag to use
        TagToUse = string.Intern("Image");

        AddInline(new Span(content));

        Uri = uri;
    }


    ///// <summary>
    ///// Add the current element to a document defined in LDML (Logical document markup language)
    ///// </summary>
    ///// <param name="document">StringBuilder instance to create the LDML in</param>
    ///// <param name="indent">Current indent</param>
    //public override void ToLdmlString(StringBuilder document, string indent)
    //{
    //    AddTagWithAttributes(indent, TagToUse, document);

    //    // Add the blocks now
    //    foreach (var block in ChildBlocks)
    //    {
    //        block.ToLdmlString(document, $"{indent}{Indentation}");
    //    }

    //    // Add the inlines now
    //    foreach (var inline in Inlines)
    //    {
    //        inline.ToLdmlString(document, $"{indent}{Indentation}");
    //    }


    //    document.AppendLine($"{indent}</{TagToUse}>");
    //}
}