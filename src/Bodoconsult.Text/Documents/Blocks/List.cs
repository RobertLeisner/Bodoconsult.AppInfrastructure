// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System;
using System.Collections.Generic;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// List element
/// </summary>
public sealed class List : ParagraphBase
{
    /// <summary>
    /// Static list with all allowed block elements for lists
    /// </summary>
    public static List<Type> AllAllowedBlocks =
    [
        typeof(ListItem),
    ];

    /// <summary>
    /// Default ctor
    /// </summary>
    public List()
    {
        // Add allowed blocks
        AllowedBlocks.AddRange(AllAllowedBlocks);

        // Add allowed inlines

        // Tag
        TagToUse = string.Intern("List");
    }

    /// <summary>
    /// Default ctor
    /// </summary>
    public List(IList<string> items)
    {
        // Add allowed blocks
        AllowedBlocks.AddRange(AllAllowedBlocks);

        // Add allowed inlines

        // Tag
        TagToUse = string.Intern("List");

        // Content

        foreach (var item in items)
        {
            AddBlock(new ListItem(item));
        }
    }

    /// <summary>
    /// Default ctor
    /// </summary>
    public List(IList<ListItem> items)
    {
        // Add allowed blocks
        AllowedBlocks.AddRange(AllAllowedBlocks);

        // Add allowed inlines

        // Tag
        TagToUse = string.Intern("List");

        // Content

        foreach (var item in items)
        {
            AddBlock(item);
        }
    }


    /// <summary>
    /// List style type
    /// </summary>
    public ListStyleTypeEnum ListStyleType { get; set; }

    /// <summary>
    /// List style type char
    /// </summary>
    public char ListStyleTypeChar { get; set; } = ' ';

    /// <summary>
    /// Counter for numbered lists
    /// </summary>
    public int Counter { get; set; }

    /// <summary>
    /// Add a block element
    /// </summary>
    /// <param name="block">Block element to add</param>
    public override void AddBlock(Block block)
    {
        var type = block.GetType();

        if (!AllowedBlocks.Contains(type))
        {
            throw new ArgumentException($"Type {type.Name} not allowed to add for the current element of type {this.GetType().Name}");
        }

        Blocks.Add(block);
        block.Parent = this;
    }
}