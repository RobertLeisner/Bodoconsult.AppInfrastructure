using System.Text;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Definition list
/// </summary>
public class DefinitionList : Block
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public DefinitionList()
    {

        // Add all allowed blocks
        AllowedBlocks.Add(typeof(DefinitionListTerm));

        // No inlines allowed

        // Tag to use
        TagToUse = string.Intern("DefinitionList");

    }

    /// <summary>
    /// Add the current element to a document defined in LDML (Logical document markup language)
    /// </summary>
    /// <param name="document">StringBuilder instance to create the LDML in</param>
    /// <param name="indent">Current indent</param>
    public override void ToLdmlString(StringBuilder document, string indent)
    {
        AddTagWithAttributes(indent, TagToUse, document);

        // Add the blocks now
        foreach (var block in ChildBlocks)
        {
            block.ToLdmlString(document, $"{indent}{Indentation}");
        }

        //// Add the inlines now
        //foreach (var inline in Inlines)
        //{
        //    inline.ToLdmlString(document, $"{indent}{Indentation}");
        //}

        document.AppendLine($"{indent}</{TagToUse}>");
    }
}