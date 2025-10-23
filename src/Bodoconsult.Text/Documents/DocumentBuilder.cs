// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Helpers;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Current implementation of <see cref="IDocumentBuilder"/>
/// </summary>
public class DocumentBuilder: IDocumentBuilder
{

    private IDocumentRenderer _renderer;

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="documentFactory">Current document factory</param>
    /// <param name="documentRendererFactory">The document renderer instance to use</param>
    public DocumentBuilder(IDocumentFactory documentFactory, IDocumentRendererFactory documentRendererFactory)
    {
        DocumentFactory = documentFactory;
        DocumentRendererFactory = documentRendererFactory;
        Document = DocumentFactory.Document;
    }

    /// <summary>
    /// Current document metadata to use
    /// </summary>
    public DocumentMetaData DocumentMetaData { get; set; } = new();

    /// <summary>
    /// Current styleset to use
    /// </summary>
    public Styleset Styleset { get; set; }

    /// <summary>
    /// Current document factory
    /// </summary>
    public IDocumentFactory DocumentFactory { get; }

    /// <summary>
    /// The document renderer factory instance to use
    /// </summary>
    public IDocumentRendererFactory DocumentRendererFactory { get; }

    /// <summary>
    /// Current document
    /// </summary>
    public Document Document { get; private set; }

    /// <summary>
    /// Create the document
    /// </summary>
    public void CreateDocument()
    {


        DocumentMetaData ??= new DocumentMetaData();
        DocumentFactory.LoadDocumentMetaData(DocumentMetaData);

        Styleset ??= StylesetHelper.CreateDefaultStyleset();
        DocumentFactory.LoadStyleset(Styleset);


        DocumentFactory.PrepareTheDocument();

        DocumentFactory.CreateDocument();
        Document = DocumentFactory.Document;
    }

    /// <summary>
    /// Calculate TOC, TOF and TOE for the document
    /// </summary>
    public void CalculateDocument()
    {
        var calc = new LdmlCalculator(Document);
        calc.UpdateAllTables();
        calc.EnumerateAllItems();
        calc.PrepareAllItems();
        calc.PrepareAllSections();
    }

    /// <summary>
    /// Render the document
    /// </summary>
    public void RenderDocument()
    {
        _renderer = DocumentRendererFactory.CreateInstance(Document);
        _renderer.RenderIt();
    }

    /// <summary>
    /// Save the rendered content as file
    /// </summary>
    /// <param name="fileName">Full file pah for saving the rendered content into. Existing file will be overwritten.</param>
    public void SaveAsFile(string fileName)
    {
        _renderer?.SaveAsFile(fileName);
    }
}