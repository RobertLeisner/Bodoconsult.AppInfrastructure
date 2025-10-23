// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.Pdf.PdfSharp;

/// <summary>
/// Table cell
/// </summary>
public class PdfCell
{
    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="content">Content of the cell</param>
    public PdfCell(string content)
    {
        Content = content;
    }

    /// <summary>
    /// Content of the cell
    /// </summary>
    public string Content { get; }

}