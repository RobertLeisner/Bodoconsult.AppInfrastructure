// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for <see cref="Heading4"/> instances
/// </summary>
public class Heading4Style : ParagraphStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public Heading4Style()
    {
        TagToUse = "Heading4Style";
        Name = TagToUse;
        Bold = true;
        Margins.Top = Styleset.DefaultFontSize;
        Paddings.Top = Styleset.DefaultPaddingWidth;
        Paddings.Bottom = Styleset.DefaultPaddingWidth;
        KeepWithNextParagraph = true;
    }
}