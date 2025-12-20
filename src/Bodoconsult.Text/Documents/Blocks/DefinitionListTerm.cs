// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System;
using System.Collections.Generic;
using Bodoconsult.Text.Helpers;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Definition list term
/// </summary>
public class DefinitionListTerm : ParagraphBase
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
    public DefinitionListTerm()
    {
        // Add all allowed blocks
        AllowedBlocks.Add(typeof(DefinitionListItem));

        // Add all allowed inlines
        AllowedInlines.AddRange(AllAllowedInlines);

        // Tag to use
        TagToUse = string.Intern("DefinitionListTerm");

    }

    /// <summary>
    /// Ctor providing content
    /// </summary>
    public DefinitionListTerm(string content)
    {
        // Add all allowed blocks
        AllowedBlocks.Add(typeof(DefinitionListItem));

        // Add all allowed inlines
        AllowedInlines.AddRange(AllAllowedInlines);

        // Tag to use
        TagToUse = string.Intern("DefinitionListTerm");

        // Content
        ElementContentParser.Parse(content, this);
    }

    /// <summary>
    /// Definition list items
    /// </summary>
    public ReadOnlyLdmlList<DefinitionListItem> DefinitionListItems => Blocks.ToList<DefinitionListItem>(x => x.GetType() == typeof(DefinitionListItem));

    /// <summary>
    /// Add a block element
    /// </summary>
    /// <param name="block">Block element to add</param>
    public override void AddBlock(Block block)
    {
        var type = block.GetType();

        if (!AllowedBlocks.Contains(type))
        {
            throw new ArgumentException($"Type {type.Name} not allowed to add for the current element of type {GetType().Name}");
        }

        if (block.IsSingleton && Blocks.Exists(x => x.GetType() == type))
        {
            throw new ArgumentException($"Type {type.Name} not allowed to add for the current element of type {GetType().Name} if there is already an existing one (singleton)");
        }

        Blocks.Add(block);
        block.Parent = this;
    }

    ///// <summary>
    ///// Add the current element to a document defined in LDML (Logical document markup language)
    ///// </summary>
    ///// <param name="document">StringBuilder instance to create the LDML in</param>
    ///// <param name="indent">Current indent</param>
    //public override void ToLdmlString(StringBuilder document, string indent)
    //{
    //    AddTagWithAttributes(indent, TagToUse, document);

    //    // Add the items now
    //    document.AppendLine($"{indent}{Indentation}<DefinitionListItems>");
    //    foreach (var block in DefinitionListItems)
    //    {
    //        block.ToLdmlString(document, $"{indent}{Indentation}{Indentation}");
    //    }
    //    document.AppendLine($"{indent}{Indentation}</DefinitionListItems>");

    //    // Add the inlines now
    //    foreach (var inline in Inlines)
    //    {
    //        inline.ToLdmlString(document, $"{indent}{Indentation}");
    //    }

    //    document.AppendLine($"{indent}</{TagToUse}>");
    //}
}