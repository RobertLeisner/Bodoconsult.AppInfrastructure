// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

namespace Bodoconsult.Pdf.PdfSharp;

/// <summary>
/// Collects data for presentation of an object field in a PDF table
/// </summary>
public struct PdfTableField
{
    /// <summary>
    /// Header text
    /// </summary>
    public string Header;

    /// <summary>
    /// Name of the table field
    /// </summary>
    public string Name;

    /// <summary>
    /// Width in cm
    /// </summary>
    public double Width;

    /// <summary>
    /// Number or date format to use for the field
    /// </summary>
    public string Format;

    /// <summary>
    /// Alignment of the content
    /// </summary>
    public PdfTextAlignment TextAlign;
}