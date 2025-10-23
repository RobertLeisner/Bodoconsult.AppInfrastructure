// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for <see cref="List"/> instances
/// </summary>
public class ListStyle : ParagraphStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public ListStyle()
    {
        TagToUse = "ListStyle";
        Name = TagToUse;
    }
}