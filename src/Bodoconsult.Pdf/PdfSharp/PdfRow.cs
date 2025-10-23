// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Collections.Generic;

namespace Bodoconsult.Pdf.PdfSharp;

/// <summary>
/// A table row
/// </summary>
public class PdfRow
{
    /// <summary>
    /// Cells in the row
    /// </summary>
    public List<PdfCell> Cells { get;  } = new();
}