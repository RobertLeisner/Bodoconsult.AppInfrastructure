// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// A style for a normal left aligned paragraph
/// </summary>
public class ParagraphStyle : ParagraphStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public ParagraphStyle()
    {
        TagToUse = "ParagraphStyle";
        Name = TagToUse;
    }

}