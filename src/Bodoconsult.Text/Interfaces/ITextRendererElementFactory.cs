// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Interfaces;

/// <summary>
/// Interface for factories creating instances of <see cref="ITextRendererElement"/>
/// </summary>
public interface ITextRendererElementFactory
{
    /// <summary>
    /// Create an instance of <see cref="ITextRendererElement"/> related to the given <see cref="TextElement"/> instance
    /// </summary>
    /// <param name="textElement"><see cref="TextElement"/> instance</param>
    /// <returns><see cref="ITextRendererElement"/> instance</returns>
    ITextRendererElement CreateInstance(DocumentElement textElement);
}