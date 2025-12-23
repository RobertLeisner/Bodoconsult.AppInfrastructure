// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.Office;

/// <summary>
/// Row data of a DOCX table row
/// </summary>
public class DocxTableRow
{
    /// <summary>
    ///  The list of cells in the row
    /// </summary>
    public List<DocxTableCell> Cells { get; set; } = [];
}