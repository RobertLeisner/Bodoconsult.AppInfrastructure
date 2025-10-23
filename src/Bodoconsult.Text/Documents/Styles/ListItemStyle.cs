// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for <see cref="ListItem"/> instances
/// </summary>
public class ListItemStyle : ParagraphStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public ListItemStyle()
    {
        TagToUse = "ListItemStyle";
        Name = TagToUse;
        Margins.Left = Styleset.DefaultMarginLeft;
    }
}