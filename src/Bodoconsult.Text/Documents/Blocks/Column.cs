// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System;
using System.Text;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// A table column
/// </summary>
public class Column : Block
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public Column()
    {
        // No blocks allowed

        // No inlines allowed

        TagToUse = string.Intern("Column");
    }

    /// <summary>
    /// Column data type
    /// </summary>
    public Type DataType { get; set; }

    /// <summary>
    /// Format string to format the value
    /// </summary>
    public string Format { get; set; }

    /// <summary>
    /// Maximum length of the content
    /// </summary>
    [DoNotSerialize]
    public int MaxLength { get; set; }

    /// <summary>
    /// Add the current element to a document defined in LDML (Logical document markup language)
    /// </summary>
    /// <param name="document">StringBuilder instance to create the LDML in</param>
    /// <param name="indent">Current indent</param>
    public override void ToLdmlString(StringBuilder document, string indent)
    {
        if (string.IsNullOrEmpty(Format))
        {
            document.AppendLine($"{indent}<{TagToUse} Name=\"{Name}\" DataType=\"{DataType}\"/>");
        }
        else
        {
            document.AppendLine($"{indent}<{TagToUse} Name=\"{Name}\" DataType=\"{DataType}\" Format=\"{Format}\"/>");
        }
    }
}