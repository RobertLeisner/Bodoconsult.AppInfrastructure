// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Helpers;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Toc1
/// </summary>
public class Toc1 : TocBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc1()
    {
        // No blocks allowed

        // Add allowed inlines
        AllowedInlines.AddRange(AllAllowedInlines);

        TagToUse = string.Intern("Toc1");
    }

    /// <summary>
    /// Ctor with string content
    /// </summary>
    public Toc1(string content)
    {
        // No blocks allowed

        // Add allowed inlines
        AllowedInlines.AddRange(AllAllowedInlines);

        TagToUse = string.Intern("Toc1");

        ElementContentParser.Parse(content, this);
    }
}