// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System;
using System.Text;

namespace Bodoconsult.Text.Documents;

/// <summary>
///  base class for all <see cref="Document"/> related LDML objects
/// </summary>
public abstract class DocumentElement
{
    /// <summary>
    /// Current indenttation for LDML creation
    /// </summary>
    [DoNotSerialize]
    public string Indentation { get; set; } = "    ";

    /// <summary>
    /// Parent element
    /// </summary>
    [DoNotSerialize]
    public DocumentElement Parent { get; set; }

    /// <summary>
    /// Add the current element to a document defined in LDML (Logical document markup language)
    /// </summary>
    /// <param name="document">StringBuilder instance to create the LDML in</param>
    /// <param name="indent">Current indent</param>
    public virtual void ToLdmlString(StringBuilder document, string indent)
    {
        throw new NotSupportedException("Create an override for method ToLdmlString()");
    }
}