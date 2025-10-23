// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Interfaces;

/// <summary>
/// interface for document builder instances
/// </summary>
public interface IDocumentFactory
{
    /// <summary>
    /// Current LDML document
    /// </summary>
    Document Document { get; }

    /// <summary>
    /// Load existing document metadata and replace the existing one
    /// </summary>
    /// <param name="documentMetaData">Document metadata</param>
    void LoadDocumentMetaData(DocumentMetaData documentMetaData);

    /// <summary>
    /// Load a styleset and replace the existing one
    /// </summary>
    /// <param name="styleset">Styleset to load</param>
    void LoadStyleset(Styleset styleset);

    /// <summary>
    /// Load the styleset and the metadata to the document and create a default section "Body"
    /// </summary>
    void PrepareTheDocument();

    /// <summary>
    /// Create the full document. Implement all logic needed to create the full document you want to get
    /// </summary>
    void CreateDocument();
}