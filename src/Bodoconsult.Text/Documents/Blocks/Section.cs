// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.Text.Documents;


/// <summary>
/// Represents a document section. Every document has ho have at least one section
/// </summary>
public class Section : SectionBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public Section()
    {
        TagToUse = "Section";
        PageBreakBefore = true;
    }
}