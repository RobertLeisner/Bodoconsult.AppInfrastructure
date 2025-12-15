// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


namespace Bodoconsult.Office;

/// <summary>
/// Styles used to format OpenXml XLSX files via late binding
/// </summary>
public enum ExcelStyles
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
    /// Tabel content style: string
    /// </summary>
    TableContent,
    /// <summary>
    /// Tabel content style: date
    /// </summary>
    TableContentDate,
    /// <summary>
    /// Tabel content style: numeric
    /// </summary>
    TableContentNumeric,
    /// <summary>
    /// Tabel content style: integer
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