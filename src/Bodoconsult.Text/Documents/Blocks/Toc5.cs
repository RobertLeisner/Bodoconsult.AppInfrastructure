// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Helpers;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Toc5
/// </summary>
public class Toc5 :TocBase
{

    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc5()
    {
        // No blocks allowed

        // Add allowed inlines
        AllowedInlines.AddRange(AllAllowedInlines);

        TagToUse = string.Intern("Toc5");
    }

    /// <summary>
    /// Ctor with string content
    /// </summary>
    public Toc5(string content)
    {
        // No blocks allowed

        // Add allowed inlines
        AllowedInlines.AddRange(AllAllowedInlines);

        TagToUse = string.Intern("Toc5");

        ElementContentParser.Parse(content, this);
    }
}