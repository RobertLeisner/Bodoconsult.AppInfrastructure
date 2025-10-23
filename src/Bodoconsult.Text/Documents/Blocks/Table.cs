// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Helpers;
using System;
using System.Collections.Generic;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// A table
/// </summary>
public class Table : Block
{

    /// <summary>
    /// Static list with all allowed block elements for paragraphs
    /// </summary>
    public static List<Type> AllAllowedBlocks =
    [
        typeof(Column),
        typeof(Row),
    ];

    /// <summary>
    /// Static list with all allowed inline elements for paragraphs
    /// </summary>
    public static List<Type> AllAllowedInlines =
    [
        typeof(Span),
        typeof(Bold),
        typeof(Italic),
        typeof(LineBreak),
    ];

    /// <summary>
    /// Default ctor
    /// </summary>
    public Table()
    {
        // Blocks allowed
        AllowedBlocks.AddRange(AllAllowedBlocks);

        // Inlines allowed
        AllowedInlines.AddRange(AllAllowedInlines);

        TagToUse = string.Intern("Table");
    }

    /// <summary>
    /// Ctor providing a table legend
    /// </summary>
    public Table(string content)
    {
        //Columns = new LdmlList<Column>(this);
        //Rows = new LdmlList<Row>(this);

        // Blocks allowed
        AllowedBlocks.AddRange(AllAllowedBlocks);

        // No inlines allowed
        AllowedInlines.AddRange(AllAllowedInlines);

        TagToUse = string.Intern("Table");

        ElementContentParser.Parse(content, this);
    }

    /// <summary>
    /// Columns of the table
    /// </summary>
    [DoNotSerialize]
    public List<Column> Columns => Blocks.ToList<Column>(x => x.GetType() == typeof(Column));

    /// <summary>
    /// Rows of the table
    /// </summary>
    [DoNotSerialize]

    public List<Row> Rows => Blocks.ToList<Row>(x => x.GetType() == typeof(Row));

    /// <summary>
    /// Prefix for the table
    /// </summary>
    public string CurrentPrefix { get; set; }

    ///// <summary>
    ///// Add the current element to a document defined in LDML (Logical document markup language)
    ///// </summary>
    ///// <param name="document">StringBuilder instance to create the LDML in</param>
    ///// <param name="indent">Current indent</param>
    //public override void ToLdmlString(StringBuilder document, string indent)
    //{
    //    AddTagWithAttributes($"{indent}", TagToUse, document, true);
    //    document.AppendLine($"{indent}</{TagToUse}>");
    //}
}