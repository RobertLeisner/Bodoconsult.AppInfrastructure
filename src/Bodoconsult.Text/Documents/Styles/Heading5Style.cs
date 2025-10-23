// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for <see cref="Heading5"/> instances
/// </summary>
public class Heading5Style : ParagraphStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public Heading5Style()
    {
        TagToUse = "Heading5Style";
        Name = TagToUse;
        Italic = true;
        KeepWithNextParagraph = true;
    }
}