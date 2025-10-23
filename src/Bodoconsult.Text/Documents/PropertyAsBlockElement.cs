using System;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// A property element produces as a block in LDML
/// </summary>
public abstract class PropertyAsBlockElement : DocumentElement
{
    /// <summary>
    /// Get the element data as formatted property value as a LDML block
    /// </summary>
    public virtual string ToPropertyValue()
    {
        throw new NotSupportedException("Create an override for method ToPropertyValue()");
    }
}