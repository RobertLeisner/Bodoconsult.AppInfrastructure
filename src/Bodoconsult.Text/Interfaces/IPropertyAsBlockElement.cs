// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Interfaces;

/// <summary>
/// Interface for properties as block elements
/// </summary>
public interface IPropertyAsBlockElement: IDocumentElement
{
    /// <summary>
    /// Get the element data as formatted property value as a LDML block
    /// </summary>
    string ToPropertyValue();
}