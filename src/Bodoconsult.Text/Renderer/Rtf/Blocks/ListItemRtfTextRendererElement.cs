// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Blocks;

/// <summary>
/// Rtf rendering element for <see cref="ListItem"/> instances
/// </summary>
public class ListItemRtfTextRendererElement : RtfTextRendererElementBase
{
    private readonly ListItem _listItem;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ListItemRtfTextRendererElement(ListItem listItem) : base(listItem)
    {
        _listItem = listItem;
        ClassName = listItem.StyleName;
    }
}