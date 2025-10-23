// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System;
using System.Collections.Generic;
using System.Text;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Table cell
/// </summary>
public class Cell : ParagraphBase
{
    /// <summary>
    /// Static list with all allowed inline elements for paragraphs
    /// </summary>
    public static List<Type> AllAllowedInlines =
    [
        typeof(Span),
        typeof(Bold),
        typeof(Italic),
        typeof(LineBreak),
        typeof(Value)
    ];


    /// <summary>
    /// Default ctor
    /// </summary>
    public Cell()
    {
        // No blocks allowed

        // Add allowed inlines
        AllowedInlines.AddRange(AllAllowedInlines);

        TagToUse = string.Intern("Cell");
    }

    /// <summary>
    /// Ctor with string content
    /// </summary>
    public Cell(string content)
    {
        // No blocks allowed

        // Add allowed inlines
        AllowedInlines.AddRange(AllAllowedInlines);

        TagToUse = string.Intern("Cell");

        Inlines.Add(new Value { Content = content });
    }

    /// <summary>
    /// Column related to the cell
    /// </summary>
    [DoNotSerialize]
    public Column Column { get; set; }

    /// <summary>
    /// Add the current element to a document defined in LDML (Logical document markup language)
    /// </summary>
    /// <param name="document">StringBuilder instance to create the LDML in</param>
    /// <param name="indent">Current indent</param>
    public override void ToLdmlString(StringBuilder document, string indent)
    {
        document.AppendLine($"{indent}<{TagToUse}>");

        foreach (var item in Inlines)
        {
            item.ToLdmlString(document, $"{indent}{Indentation}");
        }

        document.AppendLine($"{indent}</{TagToUse}>");
    }
}