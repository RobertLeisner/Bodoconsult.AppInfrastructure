// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Blocks;

/// <summary>
/// Docx rendering element for <see cref="DefinitionList"/> instances
/// </summary>
public class DefinitionListDocxTextRendererElement : DocxTextRendererElementBase
{
    private readonly DefinitionList _item;

    /// <summary>
    /// Default ctor
    /// </summary>
    public DefinitionListDocxTextRendererElement(DefinitionList item) : base(item)
    {
        _item = item;
        ClassName = item.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(DocxTextDocumentRenderer renderer)
    {
        
        //var dt = new List<DocxDefinitionListTerm>();

        //foreach (var childBlock in _item.ChildBlocks)
        //{
        //    var term = (DefinitionListTerm)childBlock;

        //    var termItem = new DocxDefinitionListTerm();

        //    var sb = new StringBuilder();

        //    DocxDocumentRendererHelper.RenderBlockInlinesToStringForDocx(renderer, term.ChildInlines, sb);
        //    termItem.Term = sb.ToString();

        //    foreach(var listItems in term.ChildBlocks)
        //    {
        //        sb.Clear();
        //        DocxDocumentRendererHelper.RenderBlockInlinesToStringForDocx(renderer, listItems.ChildInlines, sb);
        //        termItem.Items.Add(sb.ToString());
        //    }

        //    dt.Add(termItem);
        //}

        //renderer.DocxDocument.AddDefinitionList(dt);
    }
}