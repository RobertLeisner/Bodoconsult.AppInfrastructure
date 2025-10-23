// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.PlainText;

/// <summary>
/// HTML rendering element for <see cref="DefinitionListItem"/> instances
/// </summary>
public class DefinitionListItemPlainTextRendererElement : ParagraphBasePlainTextRendererElement
{
    private readonly DefinitionListItem _item;

    /// <summary>
    /// Default ctor
    /// </summary>
    public DefinitionListItemPlainTextRendererElement(DefinitionListItem item)
    {
        _item = item;
        Paragraph = item;
    }
}