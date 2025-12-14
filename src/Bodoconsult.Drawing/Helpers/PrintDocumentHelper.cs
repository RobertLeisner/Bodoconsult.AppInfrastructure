// Copyright (c) Bodoconsult EDV-Dienstleistungen. All rights reserved.

using System.Drawing.Printing;
using System.Runtime.Versioning;

namespace Bodoconsult.Drawing.Helpers;

/// <summary>
/// Helper class for printing documents
/// </summary>
[SupportedOSPlatform("windows")]
public static class PrintDocumentHelper
{
    /// <summary>
    /// Get the papersize for a document and a paper size name like A4
    /// </summary>
    /// <param name="document">Current document</param>
    /// <param name="paperName">Paper name like A4</param>
    /// <returns>Paper size</returns>
    public static PaperSize GetPaperSize(PrintDocument document, string paperName)
    {
        PaperSize size1 = null;
        paperName = paperName.ToUpper();
        var settings = document.PrinterSettings;
        foreach (PaperSize size in settings.PaperSizes)
        {
            if (size.Kind.ToString().ToUpper() != paperName)
            {
                continue;
            }
            size1 = size;
            break;
        }
        return size1;
    }
}