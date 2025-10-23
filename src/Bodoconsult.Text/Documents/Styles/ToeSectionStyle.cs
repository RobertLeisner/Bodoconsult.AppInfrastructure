// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for a TOE section element
/// </summary>
public class ToeSectionStyle : PageStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public ToeSectionStyle()
    {
        TagToUse = string.Intern("ToeSectionStyle");
        Name = TagToUse;
    }
}