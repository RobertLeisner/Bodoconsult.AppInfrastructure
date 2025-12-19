// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Interfaces;

/// <summary>
/// Interface for properties as attribute elements
/// </summary>
public interface IPropertyAsAttributeElement: IDocumentElement
{
    /// <summary>
    /// Get the element data as formatted property value for an LDML attribute
    /// </summary>
    string ToPropertyValue();
}