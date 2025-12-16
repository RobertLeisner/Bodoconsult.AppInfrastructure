// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

namespace Bodoconsult.Office.Interfaces;

/// <summary>
/// Styles used to format OpenXml XLSX files
/// </summary>
public enum SpreadsheetStyles
{
    /// <summary>
    /// Default style
    /// </summary>
    Default,
    /// <summary>
    /// Header style
    /// </summary>
    Header,
    /// <summary>
    /// Table header style
    /// </summary>
    TableHeader,
    /// <summary>
    /// Table content style: string
    /// </summary>
    TableContent,
    /// <summary>
    /// Table content style: date
    /// </summary>
    TableContentDate,
    /// <summary>
    /// Table content style: numeric
    /// </summary>
    TableContentNumeric,
    /// <summary>
    /// Table content style: integer
    /// </summary>
    TableContentInteger,
    /// <summary>
    /// Table content style alternative row: string
    /// </summary>
    TableContentAlternate,
    /// <summary>
    /// Table content style alternative row: date
    /// </summary>
    TableContentAlternateDate,
    /// <summary>
    /// Table content style alternative row: numeric
    /// </summary>
    TableContentAlternateNumeric,
    /// <summary>
    /// Table content style alternative row: integer
    /// </summary>
    TableContentAlternateInteger,
    /// <summary>
    /// Header2 style
    /// </summary>
    Header2
}