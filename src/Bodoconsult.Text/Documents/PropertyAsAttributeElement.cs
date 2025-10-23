using System;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// A property element produces as an attribute in LDML
/// </summary>
public abstract class PropertyAsAttributeElement: DocumentElement
{
    /// <summary>
    /// Get the element data as formatted property value for an LDML attribute
    /// </summary>
    public virtual string ToPropertyValue()
    {
        throw new NotSupportedException("Create an override for method ToPropertyValue()");
    }
}