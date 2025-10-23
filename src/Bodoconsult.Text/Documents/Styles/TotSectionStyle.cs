// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for a TOT section element
/// </summary>
public class TotSectionStyle : PageStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public TotSectionStyle()
    {
        TagToUse = string.Intern("TotSectionStyle");
        Name = TagToUse;
    }
}