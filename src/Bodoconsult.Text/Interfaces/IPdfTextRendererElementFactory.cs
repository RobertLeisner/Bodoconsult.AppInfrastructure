// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Interfaces;

/// <summary>
/// Interface for factories creating instances of <see cref="IPdfTextRendererElement"/>
/// </summary>
public interface IPdfTextRendererElementFactory : ITextRendererElementFactory
{
    /// <summary>
    /// Create an instance of <see cref="IPdfTextRendererElement"/> related to the given <see cref="TextElement"/> instance
    /// </summary>
    /// <param name="textElement"><see cref="TextElement"/> instance</param>
    /// <returns><see cref="IPdfTextRendererElement"/> instance</returns>
    IPdfTextRendererElement CreateInstancePdf(DocumentElement textElement);
}
