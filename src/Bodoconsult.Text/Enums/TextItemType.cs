// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System.Data;

namespace Bodoconsult.Text.Enums;

/// <summary>
/// Logical type of a text item
/// </summary>
public enum TextItemType
{

    /// <summary>
    /// Heading level 1
    /// </summary>
    H1,

    /// <summary>
    /// Heading level 2
    /// </summary>
    H2,

    /// <summary>
    /// Heading level 3
    /// </summary>
    H3,

    /// <summary>
    /// Heading level 4
    /// </summary>
    H4,

    /// <summary>
    /// Text paragraph
    /// </summary>
    P,

    /// <summary>
    /// Info paragraph 
    /// </summary>
    Info,

    /// <summary>
    /// Warning paragraph
    /// </summary>
    Warning,

    /// <summary>
    /// Error message paragraph
    /// </summary>
    Error,

    /// <summary>
    /// Add a XML
    /// </summary>
    Xml,
    /// <summary>
    /// Adds preformatted text without encoding. Internal use only!
    /// </summary>
    Plain,
    /// <summary>
    /// Adds a code paragraph
    /// </summary>
    Code,
    /// <summary>
    /// Add a definition list line (results in HTML in a dl-Tag with dt-Tag and dd-Tag)
    /// </summary>
    DefinitionListLine,

    /// <summary>
    /// Defines a list item (results in HTML in a ul-Tag with li-Tag items)
    /// </summary>
    ListItem,
    /// <summary>
    /// Add a table to the text (table data to be defined as <see cref="DataTable"/>
    /// </summary>
    Table


}