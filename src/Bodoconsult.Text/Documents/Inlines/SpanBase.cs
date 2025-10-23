// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System;
using System.Text;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// A span base element contains plain text
/// </summary>
public abstract class SpanBase : Inline
{
    private string _content;

    /// <summary>
    /// The content of the span element. May only be set if there is no inline child element loaded
    /// </summary>
    [DoNotSerialize]
    public string Content
    {
        get => _content;
        set
        {
            if (Inlines.Count > 0)
            {
                return;
            }

            _content = value;
        }
    }

    /// <summary>
    /// Add the current element to a document defined in LDML (Logical document markup language)
    /// </summary>
    /// <param name="document">StringBuilder instance to create the LDML in</param>
    /// <param name="indent">Current indent</param>
    public override void ToLdmlString(StringBuilder document, string indent)
    {
        if (Inlines.Count > 0)
        {
            AddTagWithAttributes(indent, TagToUse, document);

            // Add the inlines now
            foreach (var inline in Inlines)
            {
                inline.ToLdmlString(document, $"{indent}{Indentation}");
            }

            document.AppendLine($"{indent}</{TagToUse}>");
        }
        else
        {
            AddTagWithAttributes(indent, TagToUse, document, false);

            // Add content now
            document.AppendLine($"{Content}</{TagToUse}>");
        }
    }

    /// <summary>
    /// Add a block element
    /// </summary>
    /// <param name="inline">Inline element to add</param>
    public override void AddInline(Inline inline)
    {
        var type = inline.GetType();

        if (!AllowedInlines.Contains(type))
        {
            throw new ArgumentException($"Type {type.Name} not allowed to add for the current element");
        }

        Inlines.Add(inline);
        inline.Parent = this;
    }
}