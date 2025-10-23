// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using Bodoconsult.Text.Enums;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Model;

/// <summary>
/// Keeps text for a definition list. <see cref="Content"/> is used as left column (HTML: dt), 
/// <see cref="Content2"/> as right column (HTML: dd)
/// </summary>
public struct DefinitionListTextItem : ITextItem
{

    /// <summary>
    /// Logical type of the item
    /// </summary>
    public TextItemType LogicalType { get; set; }

    /// <summary>
    /// Content is used as left column (HTML: dt)
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// Content is used as right column (HTML: dd)
    /// </summary>
    public string Content2 { get; set; }

    /// <summary>
    /// Class name representing the name of the formatting class i.e. in CSS
    /// </summary>
    public string ClassName { get; set; }

}