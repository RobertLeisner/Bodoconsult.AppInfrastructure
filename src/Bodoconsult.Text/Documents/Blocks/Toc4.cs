// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Helpers;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Toc4
/// </summary>
public class Toc4: TocBase
{
   


    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc4()
    {
        // No blocks allowed

        // Add allowed inlines
        AllowedInlines.AddRange(AllAllowedInlines);

        TagToUse = string.Intern("Toc4");
    }

    /// <summary>
    /// Ctor with string content
    /// </summary>
    public Toc4(string content)
    {
        // No blocks allowed

        // Add allowed inlines
        AllowedInlines.AddRange(AllAllowedInlines);

        TagToUse = string.Intern("Toc4");

        ElementContentParser.Parse(content, this);
    }
}