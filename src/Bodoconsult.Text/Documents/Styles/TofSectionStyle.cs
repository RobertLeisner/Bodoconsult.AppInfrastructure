// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for a TOF section element
/// </summary>
public class TofSectionStyle : PageStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public TofSectionStyle()
    {
        TagToUse = string.Intern("TofSectionStyle");
        Name = TagToUse;
    }
}