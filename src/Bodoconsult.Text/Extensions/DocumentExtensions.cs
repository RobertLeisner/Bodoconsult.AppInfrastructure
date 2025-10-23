// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Extensions;

/// <summary>
/// Extension methods for <see cref="Document"/>
/// </summary>
public static class DocumentExtensions
{
    /// <summary>
    /// Add base sections TOC, TOF and TOE
    /// </summary>
    public static void AddBaseSections(this Document document)
    {
        if (document.DocumentMetaData.IsTocRequired)
        {
            var tocSection = new TocSection();
            document.AddBlock(tocSection);
        }

        if (document.DocumentMetaData.IsFiguresTableRequired)
        {
            var tofSection = new TofSection();
            document.AddBlock(tofSection);
        }

        if (document.DocumentMetaData.IsTablesTableRequired)
        {
            var totSection = new TotSection();
            document.AddBlock(totSection);
        }

        if (document.DocumentMetaData.IsEquationsTableRequired)
        {
            var toeSection = new ToeSection();
            document.AddBlock(toeSection);
        }
    }
}