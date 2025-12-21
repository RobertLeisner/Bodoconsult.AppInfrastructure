// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Interfaces;

/// <summary>
/// Interface for factories creating instances of <see cref="IDocxTextRendererElement"/>
/// </summary>
public interface IDocxTextRendererElementFactory : ITextRendererElementFactory
{
    /// <summary>
    /// Create an instance of <see cref="IDocxTextRendererElement"/> related to the given <see cref="TextElement"/> instance
    /// </summary>
    /// <param name="textElement"><see cref="TextElement"/> instance</param>
    /// <returns><see cref="IDocxTextRendererElement"/> instance</returns>
    IDocxTextRendererElement CreateInstanceDocx(DocumentElement textElement);
}