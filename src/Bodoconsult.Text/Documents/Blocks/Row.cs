// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System;
using System.Collections.Generic;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// A table row
/// </summary>
public class Row : Block
{
    /// <summary>
    /// Static list with all allowed inline elements for rows
    /// </summary>
    public static List<Type> AllAllowedBlocks =
    [
        typeof(Cell),
    ];

    /// <summary>
    /// Default ctor
    /// </summary>
    public Row()
    {
        // Blocks allowed
        AllowedBlocks.Add(typeof(Cell));

        // No inlines allowed

        TagToUse = string.Intern("Row");
    }

    /// <summary>
    /// Cells in the row
    /// </summary>
    public ReadOnlyLdmlList<Cell> Cells => Blocks.ToList<Cell>(x => x.GetType() == typeof(Cell));

    ///// <summary>
    ///// Add the current element to a document defined in LDML (Logical document markup language)
    ///// </summary>
    ///// <param name="document">StringBuilder instance to create the LDML in</param>
    ///// <param name="indent">Current indent</param>
    //public override void ToLdmlString(StringBuilder document, string indent)
    //{
    //    document.AppendLine($"{indent}<{TagToUse}>");
    //    document.AppendLine($"{indent}{Indentation}<Cells>");
    //    foreach (var cell in Cells)
    //    {
    //        cell.ToLdmlString(document, $"{indent}{Indentation}{Indentation}");
    //    }
    //    document.AppendLine($"{indent}{Indentation}</Cells>");
    //    document.AppendLine($"{indent}</{TagToUse}>");
    //}
}