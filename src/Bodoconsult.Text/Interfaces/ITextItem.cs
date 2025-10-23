// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using Bodoconsult.Text.Enums;

namespace Bodoconsult.Text.Interfaces;

/// <summary>
/// A text item as part of a message
/// </summary>
public interface ITextItem
{

    /// <summary>
    /// Logical type of the item
    /// </summary>
    TextItemType LogicalType { get; set; }

    /// <summary>
    /// Content of the item
    /// </summary>
    string Content { get; set; }

    /// <summary>
    /// Class name representing the name of the formatting class i.e. in CSS
    /// </summary>
    string ClassName { get; set; }

}