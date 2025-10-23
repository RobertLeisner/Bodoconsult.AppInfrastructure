// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Document block element. Root element
/// </summary>
public class Document : Block
{
    private bool _isFirstSection;



    /// <summary>
    /// Default ctor
    /// </summary>
    public Document()
    {
        // Add all allowed blocks
        AllowedBlocks.Add(typeof(Section));
        AllowedBlocks.Add(typeof(DocumentMetaData));
        AllowedBlocks.Add(typeof(Styleset));
        AllowedBlocks.Add(typeof(TocSection));
        AllowedBlocks.Add(typeof(ToeSection));
        AllowedBlocks.Add(typeof(TofSection));
        AllowedBlocks.Add(typeof(TotSection));

        // No inlines allowed

        // Tag to use
        TagToUse = string.Intern("Document");
    }

    /// <summary>
    /// Styleset to use for the document
    /// </summary>
    [DoNotSerialize]
    public Styleset Styleset { get; private set; }

    /// <summary>
    /// Metadata to use for the document
    /// </summary>
    [DoNotSerialize]
    public DocumentMetaData DocumentMetaData { get; private set; }

    /// <summary>
    /// Current TOC section or null if no TOC is required 
    /// </summary>
    [DoNotSerialize]
    public TocSection TocSection { get; private set; }

    /// <summary>
    /// Current TOF section or null if no TOF is required 
    /// </summary>
    [DoNotSerialize]
    public TofSection TofSection { get; private set; }

    /// <summary>
    /// Current TOE section or null if no TOE is required 
    /// </summary>
    [DoNotSerialize]
    public ToeSection ToeSection { get; private set; }

    /// <summary>
    /// Current TOT section or null if no TOT is required 
    /// </summary>
    [DoNotSerialize]
    public TotSection TotSection { get; private set; }

    /// <summary>
    /// Add the current element to a document defined in LDML (Logical document markup language)
    /// </summary>
    /// <param name="document">StringBuilder instance to create the LDML in</param>
    /// <param name="indent">Current indent</param>
    public override void ToLdmlString(StringBuilder document, string indent)
    {
        AddTagWithAttributes(indent, TagToUse, document);

        // Add the blocks now
        foreach (var block in Blocks)
        {
            block.ToLdmlString(document, $"{indent}{Indentation}");
        }

        document.AppendLine($"{indent}</{TagToUse}>");
    }

    /// <summary>
    /// Add an inline element: not allowed on document level
    /// </summary>
    /// <param name="inline">Inline element to add</param>
    public override void AddInline(Inline inline)
    {
        // Do nothing
    }

    /// <summary>
    /// Add a block element
    /// </summary>
    /// <param name="block">Block element to add</param>
    public override void AddBlock(Block block)
    {
        switch (block)
        {
            case Styleset styleset:
                Styleset = styleset;
                break;
            case DocumentMetaData documentMetaData:
                DocumentMetaData = documentMetaData;
                break;
            case TocSection tocSection:
                if (!_isFirstSection)
                {
                    tocSection.IsFirstSection = true;
                    _isFirstSection = true;
                }
                TocSection = tocSection;
                break;
            case TofSection tofSection:
                if (!_isFirstSection)
                {
                    tofSection.IsFirstSection = true;
                    _isFirstSection = true;
                }
                TofSection = tofSection;
                break;
            case ToeSection toeSection:
                if (!_isFirstSection)
                {
                    toeSection.IsFirstSection = true;
                    _isFirstSection = true;
                }
                ToeSection = toeSection;
                break;
            case TotSection totSection:
                if (!_isFirstSection)
                {
                    totSection.IsFirstSection = true;
                    _isFirstSection = true;
                }
                TotSection = totSection;
                break;
            case Section section:
                if (!_isFirstSection)
                {
                    section.IsFirstSection = true;
                    _isFirstSection = true;
                }
                break;
        }

        base.AddBlock(block);
    }
}

/// <summary>
/// Definition list
/// </summary>
public class DefinitionList : Block
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public DefinitionList()
    {

        // Add all allowed blocks
        AllowedBlocks.Add(typeof(DefinitionListTerm));

        // No inlines allowed

        // Tag to use
        TagToUse = string.Intern("DefinitionList");

    }

    /// <summary>
    /// Add the current element to a document defined in LDML (Logical document markup language)
    /// </summary>
    /// <param name="document">StringBuilder instance to create the LDML in</param>
    /// <param name="indent">Current indent</param>
    public override void ToLdmlString(StringBuilder document, string indent)
    {
        AddTagWithAttributes(indent, TagToUse, document);

        // Add the blocks now
        foreach (var block in ChildBlocks)
        {
            block.ToLdmlString(document, $"{indent}{Indentation}");
        }

        //// Add the inlines now
        //foreach (var inline in Inlines)
        //{
        //    inline.ToLdmlString(document, $"{indent}{Indentation}");
        //}

        document.AppendLine($"{indent}</{TagToUse}>");
    }
}

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
            throw new ArgumentException($"Type {type.Name} not allowed to add for the current element of type {this.GetType().Name}");
        }

        if (block.IsSingleton && Blocks.Exists(x => x.GetType() == type))
        {
            throw new ArgumentException($"Type {type.Name} not allowed to add for the current element of type {this.GetType().Name} if there is already an existing one (singleton)");
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

/// <summary>
/// List for LDML text elements
/// </summary>
/// <typeparam name="T"></typeparam>
public class LdmlList<T> : List<T> where T : DocumentElement
{
    private readonly object _parent;

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="parent">Parent text element</param>
    public LdmlList(object parent)
    {
        _parent = parent;
    }

    /// <summary>
    /// Add an item to the list
    /// </summary>
    /// <param name="item"></param>
    public new void Add(T item)
    {
        item.Parent = (DocumentElement)_parent;
        base.Add(item);
    }

    /// <summary>
    /// Copy instance to a new instance
    /// </summary>
    /// <returns>Returns copied list</returns>
    public ReadOnlyLdmlList<T> ToList()
    {
        var result = new ReadOnlyLdmlList<T>(_parent);
        result.AddRange(this);
        return result;
    }

    /// <summary>
    /// Copy instance to a new instance
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns>Returns copied list</returns>
    public ReadOnlyLdmlList<T> ToList(Func<T, bool> predicate)
    {
        var result = new ReadOnlyLdmlList<T>(_parent);
        result.AddRange(this.Where(predicate));
        return result;
    }

    /// <summary>
    /// Copy instance to a new instance
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns>Returns copied list</returns>
    public ReadOnlyLdmlList<TTarget> ToList<TTarget>(Func<T, bool> predicate) where TTarget : DocumentElement
    {
        var result = new ReadOnlyLdmlList<TTarget>(_parent);

        foreach (var item in this.Where(predicate))
        {
            if (item is TTarget target)
            {
                result.AddInternal(target);
            }
        }
        return result;
    }
}

/// <summary>
/// List for LDML text elements
/// </summary>
/// <typeparam name="T"></typeparam>
public class ReadOnlyLdmlList<T> : List<T> where T : DocumentElement
{
    private readonly object _parent;

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="parent">Parent text element</param>
    public ReadOnlyLdmlList(object parent)
    {
        _parent = parent;
    }

    /// <summary>
    /// Add an item to the list
    /// </summary>
    /// <param name="item"></param>
    public new void Add(T item)
    {
        throw new NotSupportedException("Not allowed to add items to this readonly list");
    }

    /// <summary>
    /// Add an item to the list
    /// </summary>
    /// <param name="item"></param>
    public void AddInternal(T item)
    {
        base.Add(item);
    }
}