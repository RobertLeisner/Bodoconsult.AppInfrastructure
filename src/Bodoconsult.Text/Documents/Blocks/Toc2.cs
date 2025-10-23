// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Helpers;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Toc2
/// </summary>
public class Toc2 : TocBase
{

    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc2()
    {
        // No blocks allowed

        // Add allowed inlines
        AllowedInlines.AddRange(AllAllowedInlines);

        TagToUse = string.Intern("Toc2");
    }

    /// <summary>
    /// Ctor with string content
    /// </summary>
    public Toc2(string content)
    {
        // No blocks allowed

        // Add allowed inlines
        AllowedInlines.AddRange(AllAllowedInlines);

        TagToUse = string.Intern("Toc2");

        ElementContentParser.Parse(content, this);
    }
}