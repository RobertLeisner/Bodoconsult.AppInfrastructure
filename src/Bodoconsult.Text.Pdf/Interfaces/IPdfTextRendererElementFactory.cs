// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Pdf.Interfaces;

/// <summary>
/// Interface for factories creating instances of <see cref="IPdfTextRendererElement"/>
/// </summary>
public interface IPdfTextRendererElementFactory : ITextRendererElementFactory
{
    /// <summary>
    /// Create an instance of <see cref="ITextRendererElement"/> related to the given <see cref="TextElement"/> instance
    /// </summary>
    /// <param name="textElement"><see cref="TextElement"/> instance</param>
    /// <returns><see cref="ITextRendererElement"/> instance</returns>
    IPdfTextRendererElement CreateInstancePdf(DocumentElement textElement);
}
