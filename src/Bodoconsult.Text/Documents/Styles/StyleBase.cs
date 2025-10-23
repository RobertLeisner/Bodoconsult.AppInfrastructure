// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System;
using System.Diagnostics;
using System.Text;
using Bodoconsult.Text.Helpers;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Base type for styles for a document
/// </summary>
public abstract class StyleBase : Block
{

    /// <summary>
    /// Default ctor
    /// </summary>
    protected StyleBase()
    {
        IsSingleton = true;
    }

    /// <summary>
    /// Add the current element to a document defined in LDML (Logical document markup language)
    /// </summary>
    /// <param name="document">StringBuilder instance to create the LDML in</param>
    /// <param name="indent">Current indent</param>
    public override void ToLdmlString(StringBuilder document, string indent)
    {
        Debug.Print(TagToUse);
        document.Append($"{indent}<{TagToUse}{GetPropertiesAsAttributes()}");

        var pis = DocumentReflectionHelper.GetPropertiesForBlocks(GetType());
        if (pis.Length == 0)
        {
            document.Append($"/>{Environment.NewLine}");
        }
        else
        {
            var valueAdded = false;
            foreach (var pi in pis)
            {
                var value = (PropertyAsBlockElement)pi.GetValue(this);
                if (value is null)
                {
                    continue;
                }

                if (!valueAdded)
                {
                    document.AppendLine(">");
                    valueAdded = true;
                }

                var newIndent = indent + Indentation;

                document.AppendLine( $"{newIndent}<{pi.Name}>");
                value.ToLdmlString(document, $"{newIndent}{Indentation}");
                document.AppendLine($"{newIndent}</{pi.Name}>");
            }

            if (valueAdded)
            {
                document.AppendLine($"{indent}</{TagToUse}>");
            }
            else
            {
                document.Append($"/>{Environment.NewLine}");
            }
            
        }
    }
}