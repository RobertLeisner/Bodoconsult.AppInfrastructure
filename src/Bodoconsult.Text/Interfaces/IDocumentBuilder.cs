// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Interfaces;

/// <summary>
/// Interface for document builder instances
/// </summary>
internal interface IDocumentBuilder
{
    /// <summary>
    /// Current document metadata to use
    /// </summary>
    DocumentMetaData DocumentMetaData { get; set; }

    /// <summary>
    /// Current styleset to use
    /// </summary>
    Styleset Styleset { get; set; }

    /// <summary>
    /// Current document factory
    /// </summary>
    public IDocumentFactory DocumentFactory { get; }

    /// <summary>
    /// The document renderer factory instance to use
    /// </summary>
    public IDocumentRendererFactory DocumentRendererFactory { get;  }

    /// <summary>
    /// Current document
    /// </summary>
    public Document Document { get;  }

    /// <summary>
    /// Create the document
    /// </summary>
    public void CreateDocument();

    /// <summary>
    /// Calculate TOC, TOF and TOE for the document
    /// </summary>
    public void CalculateDocument();

    /// <summary>
    /// Render the document
    /// </summary>
    public void RenderDocument();

    /// <summary>
    /// Save the rendered content as file
    /// </summary>
    /// <param name="fileName">Full file pah for saving the rendered content into. Existing file will be overwritten.</param>
    public void SaveAsFile(string fileName);

}