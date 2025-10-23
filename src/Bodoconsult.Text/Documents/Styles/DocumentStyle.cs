// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for document element
/// </summary>
public class DocumentStyle: PageStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public DocumentStyle()
    {
        TagToUse = string.Intern("DocumentStyle");
        Name = TagToUse;
    }
}
