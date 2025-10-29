// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

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