// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Extensions;
using Bodoconsult.Text.Helpers;
using Bodoconsult.Text.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Base class for <see cref="Document"/> based documents like documents etc.
/// </summary>
public abstract class DocumentFactoryBase : IDocumentFactory
{
    /// <summary>
    /// Default ctor
    /// </summary>
    protected DocumentFactoryBase()
    {
        Document = new Document();
    }

    /// <summary>
    /// Ctor to provide a predefined document as base for the document
    /// </summary>
    /// <param name="document"></param>
    protected DocumentFactoryBase(Document document)
    {
        Document = document;
    }

    /// <summary>
    /// Metadata to use for the document
    /// </summary>
    public DocumentMetaData DocumentMetaData { get; private set; } = new();

    /// <summary>
    /// Styleset to use for the document
    /// </summary>
    public Styleset Styleset { get; private set; } = StylesetHelper.CreateDefaultStyleset();

    /// <summary>
    /// Current LDML document
    /// </summary>
    public Document Document { get; }

    /// <summary>
    /// Current section to add content to
    /// </summary>
    public Section CurrentSection { get; protected set; }


    /// <summary>
    /// Load existing document metadata and replace the existing one
    /// </summary>
    /// <param name="documentMetaData">Document metadata</param>
    public void LoadDocumentMetaData(DocumentMetaData documentMetaData)
    {
        DocumentMetaData = documentMetaData;
    }

    /// <summary>
    /// Load a styleset and replace the existing one
    /// </summary>
    /// <param name="styleset">Styleset to load</param>
    public void LoadStyleset(Styleset styleset)
    {
        Styleset = styleset;
    }

    /// <summary>
    /// Load the styleset and the metadata to the document and create a default section "Body"
    /// </summary>
    public void PrepareTheDocument()
    {
        Document.AddBlock(DocumentMetaData);
        Document.AddBlock(Styleset);

        Document.AddBaseSections();

        var section = CreateNewSection("Body");
        section.IsRestartPageNumberingRequired = true;
    }


    /// <summary>
    /// Create a new section in the document
    /// </summary>
    /// <param name="sectionName">Name of the new section</param>
    public Section CreateNewSection(string sectionName)
    {
        var section = new Section
        {
            Name = sectionName
        };
        Document.AddBlock(section);
        CurrentSection = section;
        return section;
    }

    /// <summary>
    /// Add a heading of a certain heading level
    /// </summary>
    /// <param name="content">Content</param>
    /// <param name="headingLevel">Heading level</param>
    public void AddHeading(HeadingLevel headingLevel, string content)
    {
        switch (headingLevel)
        {
            case HeadingLevel.Level1:
                CurrentSection.AddBlock(new Heading1(content));
                break;
            case HeadingLevel.Level2:
                CurrentSection.AddBlock(new Heading2(content));
                break;
            case HeadingLevel.Level3:
                CurrentSection.AddBlock(new Heading3(content));
                break;
            case HeadingLevel.Level4:
                CurrentSection.AddBlock(new Heading4(content));
                break;
            case HeadingLevel.Level5:
                CurrentSection.AddBlock(new Heading5(content));
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(headingLevel), headingLevel, null);
        }
    }

    /// <summary>
    /// Add a paragraph to a document
    /// </summary>
    /// <param name="paragraphType">Paragraph type</param>
    /// <param name="content">Content</param>
    /// <param name="source">Source for citation</param>
    /// <exception cref="ArgumentOutOfRangeException">Paragraph type not found</exception>
    public void AddParagraph(ParagraphType paragraphType, string content, string source = null)
    {
        switch (paragraphType)
        {
            case ParagraphType.Paragraph:
                CurrentSection.AddBlock(new Paragraph(content));
                break;
            case ParagraphType.ParagraphCenter:
                CurrentSection.AddBlock(new ParagraphCenter(content));
                break;
            case ParagraphType.ParagraphRight:
                CurrentSection.AddBlock(new ParagraphRight(content));
                break;
            case ParagraphType.ParagraphJustify:
                CurrentSection.AddBlock(new ParagraphJustify(content));
                break;
            case ParagraphType.Citation:
                CurrentSection.AddBlock(new Citation(content)
                {
                    Source = source
                });
                break;
            case ParagraphType.Code:
                CurrentSection.AddBlock(new Code(content));
                break;
            case ParagraphType.Info:
                CurrentSection.AddBlock(new Info(content));
                break;
            case ParagraphType.Warning:
                CurrentSection.AddBlock(new Warning(content));
                break;
            case ParagraphType.Error:
                CurrentSection.AddBlock(new Error(content));
                break;
            case ParagraphType.Title:
                CurrentSection.AddBlock(new Title(content));
                break;
            case ParagraphType.SubTitle:
                CurrentSection.AddBlock(new Subtitle(content));
                break;
            case ParagraphType.SectionTitle:
                CurrentSection.AddBlock(new SectionTitle(content));
                break;
            case ParagraphType.SectionSubtitle:
                CurrentSection.AddBlock(new SectionSubtitle(content));
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(paragraphType), paragraphType, null);
        }
    }

    /// <summary>
    /// Add a list
    /// </summary>
    /// <param name="list">List items</param>
    /// <param name="listStyle">List style</param>
    public void AddList(List<string> list, ListStyleTypeEnum listStyle)
    {
        var block = new List();

        foreach (var item in list)
        {
            var listItem = new ListItem(item);
            block.AddBlock(listItem);
        }

        CurrentSection.AddBlock(block);
    }

    /// <summary>
    /// Add an image
    /// </summary>
    /// <param name="content">Title of the equation</param>
    /// <param name="uri">URI of the equation image</param>
    /// <param name="originalWidth">Original image width</param>
    /// <param name="originalHeight">Original image height</param>
    /// <returns>Equation instance for setting enhanced properties</returns>
    public void AddImage(string content, string uri, int originalWidth, int originalHeight)
    {
        var result = new Image(content, uri)
        {
            OriginalWidth = originalWidth,
            OriginalHeight = originalHeight
        };
        CurrentSection.AddBlock(result);
    }

    /// <summary>
    /// Add a figure
    /// </summary>
    /// <param name="content">Title of the equation</param>
    /// <param name="uri">URI of the equation image</param>
    /// <param name="originalWidth">Original image width</param>
    /// <param name="originalHeight">Original image height</param>
    /// <returns>Equation instance for setting enhanced properties</returns>
    public void AddFigure(string content, string uri, int originalWidth, int originalHeight)
    {
        var result = new Figure(content, uri)
        {
            OriginalWidth = originalWidth,
            OriginalHeight = originalHeight
        };
        CurrentSection.AddBlock(result);
    }

    /// <summary>
    /// Add an equation
    /// </summary>
    /// <param name="content">Title of the equation</param>
    /// <param name="uri">URI of the equation image</param>
    /// <param name="originalWidth">Original image width</param>
    /// <param name="originalHeight">Original image height</param>
    /// <returns>Equation instance for setting enhanced properties</returns>
    public Equation AddEquation(string content, string uri, int originalWidth, int originalHeight)
    {
        var result = new Equation(content, uri)
        {
            OriginalWidth = originalWidth,
            OriginalHeight = originalHeight
        };
        CurrentSection.AddBlock(result);
        return result;
    }

    /// <summary>
    /// Add a table
    /// </summary>
    /// <param name="table">Table to add</param>
    /// <param name="legend">Legend for the table</param>
    public void AddTable(DataTable table, string legend)
    {
        var dtp = new DataTableParser(table);
        dtp.ParseColumns();
        dtp.ParseRows();

        ElementContentParser.Parse(legend, dtp.Table);

        CurrentSection.AddBlock(dtp.Table);
    }

    /// <summary>
    /// Create the full document. Implement all logic needed to create the full document you want to get
    /// </summary>
    public virtual void CreateDocument()
    {
        throw new NotSupportedException("Override this method in your derived document factory class");
    }
}