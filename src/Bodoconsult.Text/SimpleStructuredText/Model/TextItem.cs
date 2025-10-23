// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using Bodoconsult.Text.Enums;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Model;

/// <summary>
/// Basic class for a text item as part of a message.
/// </summary>
public struct TextItem : ITextItem
{

    /// <summary>
    /// Logical type of the item
    /// </summary>
    public TextItemType LogicalType { get; set; }

    /// <summary>
    /// Content of the item
    /// </summary>
    public string Content { get; set; }


    /// <summary>
    /// Class name representing the name of the formatting class i.e. in CSS
    /// </summary>
    public string ClassName { get; set; }

}