// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System;
using System.Collections;
using System.Linq;
using System.Text;
using Bodoconsult.Text.Helpers;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Root element for documents
/// </summary>
public abstract class TextElement : DocumentElement
{
    /// <summary>
    /// The XML tag to ue for the current instance
    /// </summary>
    [DoNotSerialize]
    public string TagToUse { get; protected set; } = string.Intern("TextElement");

    /// <summary>
    /// Describing name of the element. This property is not used in the document itself
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Is the element is a singleton element to be added only once to another element. Default false
    /// </summary>
    [DoNotSerialize]
    public bool IsSingleton { get; set; }

    /// <summary>
    /// Add the opening tag with properties if available
    /// </summary>
    /// <param name="indent">Current indent</param>
    /// <param name="tag">Tag to use</param>
    /// <param name="stringBuilder">Content to add the opening tag</param>
    /// <param name="newLine">Add a new line at the end: Default: true</param>
    public void AddTagWithAttributes(string indent, string tag, StringBuilder stringBuilder, bool newLine = true)
    {
        var sb = GetPropertiesAsAttributes();

        if (sb.Length > 0)
        {
            stringBuilder.Append($"{indent}<{tag}{sb.ToString().TrimEnd()}>");
        }
        else
        {
            stringBuilder.Append($"{indent}<{tag}>");
        }

        if (newLine)
        {
            stringBuilder.Append($"{Environment.NewLine}");
        }

        stringBuilder.Append(GetLdmlListPropertiesAsAttributes($"{indent}{Indentation}"));
    }

    /// <summary>
    /// Get all properties of an TextElement as XML attributes
    /// </summary>
    /// <returns>XML string with attributes only or empty string</returns>
    public StringBuilder GetPropertiesAsAttributes()
    {
        var pis = DocumentReflectionHelper.GetPropertiesForAttributes(GetType());

        var sb = new StringBuilder();

        if (pis.Length == 0)
        {
            return sb;
        }

        sb.Append(' ');
        foreach (var p in pis.Where(p => !(p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(LdmlList<>))))
        {
            var value = p.GetValue(this);

            if (value == null)
            {
                continue;
            }

            if (value is PropertyAsAttributeElement pe)
            {

                var propValue = pe.ToPropertyValue();

                if (!string.IsNullOrEmpty(propValue))
                {
                    sb.Append($"{p.Name}=\"{propValue}\" ");
                }
                continue;
            }

            if (!string.IsNullOrEmpty(value.ToString()))
            {
                sb.Append($"{p.Name}=\"{value}\" ");
            }
        }
        return sb;
    }

    /// <summary>
    /// Get all properties of an TextElement as XML attributes
    /// </summary>
    /// <returns>XML string with attributes only or empty string</returns>
    public StringBuilder GetLdmlListPropertiesAsAttributes(string indent)
    {
        var pis = DocumentReflectionHelper.GetPropertiesForAttributes(GetType());

        var sb = new StringBuilder();

        if (pis.Length == 0)
        {
            return sb;
        }

        foreach (var p in pis.Where(p =>
                     p.PropertyType.IsGenericType &&
                     p.PropertyType.GetGenericTypeDefinition() == typeof(LdmlList<>)))
        {
            var value = (IEnumerable)p.GetValue(this);

            if (value == null)
            {
                continue;
            }

            sb.AppendLine($"{indent}<{p.Name}>");

            foreach (var item in value)
            {
                if (item is DocumentElement de)
                {
                    de.ToLdmlString(sb, $"{indent}{Indentation}");
                }
            }


            sb.AppendLine($"{indent}</{p.Name}>");
        }

        return sb;
    }
}