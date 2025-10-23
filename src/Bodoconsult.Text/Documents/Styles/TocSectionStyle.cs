// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for a TOC section element
/// </summary>
public class TocSectionStyle : PageStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public TocSectionStyle()
    {
        TagToUse = string.Intern("TocSectionStyle");
        Name = TagToUse;
    }
}