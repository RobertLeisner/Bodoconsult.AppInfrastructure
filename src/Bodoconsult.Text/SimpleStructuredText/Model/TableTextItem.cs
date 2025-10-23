// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System.Data;
using Bodoconsult.Text.Enums;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Model;

/// <summary>
/// Creates a table structure from a <see cref="DataTable"/> with a table-tag results in HTML. 
/// In plain text the table is formatted with blanks.
/// </summary>
public struct TableTextItem : ITextItem
{

    /// <summary>
    /// Logical type of the item
    /// </summary>
    public TextItemType LogicalType { get; set; }

    /// <summary>
    /// Title of the table (may be null) (HTML: dt)
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// Contains a XML serialized <see cref="DataTable"/> object as content for the table. Results in a HTML table.
    /// </summary>
    public string DataTableXml { get; set; }

    /// <summary>
    /// Class name representing the name of the formatting class i.e. in CSS
    /// </summary>
    public string ClassName { get; set; }

}