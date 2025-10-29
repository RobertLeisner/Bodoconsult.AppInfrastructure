// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System;
using System.Collections.Generic;
using Bodoconsult.Text.Helpers;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Definition list item
/// </summary>
public class DefinitionListItem : ParagraphBase
{
    /// <summary>
    /// Static list with all allowed inline elements for paragraphs
    /// </summary>
    public static List<Type> AllAllowedInlines =
    [
        typeof(Span),
        typeof(Bold),
        typeof(Italic),
        typeof(LineBreak),
        typeof(Hyperlink),
    ];

    /// <summary>
    /// Default ctor
    /// </summary>
    public DefinitionListItem()
    {

        // Add all allowed blocks

        // Add all allowed inlines
        AllowedInlines.AddRange(AllAllowedInlines);

        // Tag to use
        TagToUse = string.Intern("DefinitionListItem");
    }

    /// <summary>
    /// Ctor providing content
    /// </summary>
    public DefinitionListItem(string content)
    {

        // Add all allowed blocks

        // Add all allowed inlines
        AllowedInlines.AddRange(AllAllowedInlines);

        // Tag to use
        TagToUse = string.Intern("DefinitionListItem");

        // Content
        ElementContentParser.Parse(content, this);
    }
}