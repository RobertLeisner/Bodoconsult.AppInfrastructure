// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Abstractions.Interfaces;
using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Interfaces;

/// <summary>
/// Interface for rendering <see cref="Document"/> instances
/// </summary>
public interface IDocumentRenderer
{
    /// <summary>
    /// Current instance used for I18N handling
    /// </summary>
    public II18N CurrentI18NInstance { get; }


    /// <summary>
    /// The document to render
    /// </summary>
    Document Document { get; }

    /// <summary>
    /// Current styleset
    /// </summary>
    public Styleset Styleset { get; set; }

    /// <summary>
    /// Current page settings to apply
    /// </summary>
    public PageStyleBase PageStyleBase { get; set; }

    /// <summary>
    /// Render the document
    /// </summary>
    void RenderIt();


    /// <summary>
    /// Save the rendered document as file
    /// </summary>
    /// <param name="fileName">Full file path. Existing file will be overwritten</param>
    void SaveAsFile(string fileName);
}