// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for section element
/// </summary>
public class SectionStyle : PageStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public SectionStyle()
    {
        TagToUse = string.Intern("SectionStyle");
        Name = TagToUse;
    }
}

