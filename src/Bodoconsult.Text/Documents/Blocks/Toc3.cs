// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Helpers;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Toc3
/// </summary>
public class Toc3 : TocBase
{

    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc3()
    {
        // No blocks allowed

        // Add allowed inlines
        AllowedInlines.AddRange(AllAllowedInlines);

        TagToUse = string.Intern("Toc3");
    }

    /// <summary>
    /// Ctor with string content
    /// </summary>
    public Toc3(string content)
    {
        // No blocks allowed

        // Add allowed inlines
        AllowedInlines.AddRange(AllAllowedInlines);

        TagToUse = string.Intern("Toc3");

        ElementContentParser.Parse(content, this);
    }
}