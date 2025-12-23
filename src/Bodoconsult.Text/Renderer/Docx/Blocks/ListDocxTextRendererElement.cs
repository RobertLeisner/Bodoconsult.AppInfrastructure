// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using DocumentFormat.OpenXml;
using System.Collections.Generic;

namespace Bodoconsult.Text.Renderer.Docx.Blocks;

/// <summary>
/// Docx rendering element for <see cref="List"/> instances
/// </summary>
public class ListDocxTextRendererElement : DocxTextRendererElementBase
{
    private readonly List _list;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ListDocxTextRendererElement(List list) : base(list)
    {
        _list = list;
        ClassName = list.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(DocxTextDocumentRenderer renderer)
    {

        List<List<OpenXmlElement>> items = [];

        foreach (var listItem in _list.ChildBlocks)
        {

            var runs = new List<OpenXmlElement>();

            DocxDocumentRendererHelper.RenderBlockInlinesToRunsForDocx(renderer, listItem.ChildInlines, runs);

            items.Add(runs);
        }

        renderer.DocxDocument.AddList(items, "ListItem", _list.ListStyleType);
    }
}