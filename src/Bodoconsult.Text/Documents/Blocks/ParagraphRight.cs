// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System;
using System.Collections.Generic;
using Bodoconsult.Text.Helpers;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Paragraph right 
/// </summary>
public class ParagraphRight: ParagraphBase
{

    /// <summary>
    /// Static list with all allowed inline elements for paragraphs
    /// </summary>
    public static List<Type>AllAllowedInlines =
    [
        typeof(Span),
        typeof(Bold),
        typeof(Italic),
        typeof(LineBreak),
        typeof(Hyperlink),
        typeof(Image),
        typeof(Figure),
        typeof(Equation)
    ];


    /// <summary>
    /// Default ctor
    /// </summary>
    public ParagraphRight()
    {
        // No blocks allowed

        // Add allowed inlines
        AllowedInlines.AddRange(AllAllowedInlines);
        TagToUse = string.Intern("ParagraphRight");
    }

    /// <summary>
    /// Ctor with string content
    /// </summary>
    public ParagraphRight(string content)
    {
        // No blocks allowed

        // Add allowed inlines
        AllowedInlines.AddRange(AllAllowedInlines);

        ElementContentParser.Parse(content, this);
        TagToUse = string.Intern("ParagraphRight");
    }

    /// <summary>
    /// Add a block element
    /// </summary>
    /// <param name="block">Block element to add</param>
    public override void AddBlock(Block block)
    {
        // Do nothing
    }

}