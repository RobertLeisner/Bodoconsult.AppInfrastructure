// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Abstract class for report elements, which must have a RenderIt() method at least
/// </summary>
public abstract class ReportElement
{
    /// <summary>
    /// Renders the current element into the document flow
    /// </summary>
    /// <param name="document"></param>
    public void RenderIt(Document document)
    {
        throw new NotSupportedException("Implement an override");
    }
}