// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.App.Wpf.Documents.Interfaces;

/// <summary>
/// Interface for factories creating instances of <see cref="IWpfTextRendererElement"/>
/// </summary>
public interface IWpfTextRendererElementFactory : ITextRendererElementFactory
{
    /// <summary>
    /// Create an instance of <see cref="ITextRendererElement"/> related to the given <see cref="TextElement"/> instance
    /// </summary>
    /// <param name="textElement"><see cref="TextElement"/> instance</param>
    /// <returns><see cref="ITextRendererElement"/> instance</returns>
    IWpfTextRendererElement CreateInstanceWpf(DocumentElement textElement);
}
