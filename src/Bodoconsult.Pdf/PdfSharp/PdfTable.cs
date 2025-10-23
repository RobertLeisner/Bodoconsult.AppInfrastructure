// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Collections.Generic;

namespace Bodoconsult.Pdf.PdfSharp;

/// <summary>
/// A table in Pdf
/// </summary>
public class PdfTable
{
    /// <summary>
    /// Caption for the table
    /// </summary>
    public string Caption { get; set; }

    /// <summary>
    /// Link tag for the table
    /// </summary>
    public string Tag { get; set; }

    /// <summary>
    /// Columns of the table
    /// </summary>
    public List<PdfColumn> Columns { get;  } = new();

    /// <summary>
    /// Data rows of the table
    /// </summary>
    public List<PdfRow> Rows { get;  } = new();
}