// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using Bodoconsult.Text.Interfaces;
using System;
using System.Text;

namespace Bodoconsult.Text.Renderer.Rtf.Blocks;

/// <summary>
/// Base renderer implementation for Rtf elements
/// </summary>
public class RtfTextRendererElementBase : ITextRendererElement
{
    /// <summary>
    /// Current block to renderer
    /// </summary>
    public Block Block { get; private set; }

    /// <summary>
    /// CSS class name
    /// </summary>
    public string ClassName { get; protected set; }

    /// <summary>
    /// CSS to be added to the local tag
    /// </summary>
    public string LocalCss { get; set; }

    /// <summary>
    /// Rtf tag to use for rendering
    /// </summary>
    protected string TagToUse = "p";

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="block">Current block</param>
    public RtfTextRendererElementBase(Block block)
    {
        Block = block;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public virtual void RenderIt(ITextDocumentRenderer renderer)
    {
        // Get the content of all inlines as string


        if (Block is ParagraphBase paragraph)
        {
            var style = (ParagraphStyleBase)renderer.Styleset.FindStyle(paragraph.StyleName);
            renderer.Content.Append($@"\pard\plain\q{renderer.Styleset.GetIndexOfStyle(Block.StyleName)}{RtfHelper.GetFormatSettings(style, renderer.Styleset)}{{");
        }
        else
        {
            renderer.Content.Append($@"\pard\plain\q{renderer.Styleset.GetIndexOfStyle(Block.StyleName)}{{");
        }


        DocumentRendererHelper.RenderBlockChildsToRtf(renderer, Block.ChildBlocks);

        var sb = new StringBuilder();
        DocumentRendererHelper.RenderInlineChildsToRtf(renderer, sb, Block.ChildInlines);
        CleanRtfString(sb);
        renderer.Content.Append(sb);
        renderer.Content.Append($"}}\\par{Environment.NewLine}");
    }

    /// <summary>
    /// Cleans an RTF string
    /// </summary>
    /// <param name="sb">RTF string as StringBuilder</param>
    public static void CleanRtfString(StringBuilder sb)
    {
        sb.Replace("€", "\\'80")
            .Replace("‚", "\\'82")
            .Replace("ƒ", "\\'83")
            .Replace("„", "\\'84")
            .Replace("…", "\\'85")
            .Replace("†", "\\'86")
            .Replace("‡", "\\'87")
            .Replace("ˆ", "\\'88")
            .Replace("\n", "\\line ")
            .Replace("\t", "\\tab ")
            .Replace("‰", "\\'89")
            .Replace("Š", "\\'8A")
            .Replace("‹", "\\'8B")
            .Replace("Œ", "\\'8C")
            .Replace("Ž", "\\'8E")
            .Replace("‘", "\\'91")
            .Replace("’", "\\'92")
            .Replace("“", "\\'93")
            .Replace("”", "\\'94")
            .Replace("•", "\\'95")
            .Replace("–", "\\'96")
            .Replace("—", "\\'97")
            .Replace("˜", "\\'98")
            .Replace("™", "\\'99")
            .Replace("š", "\\'9A")
            .Replace("›", "\\'9B")
            .Replace("œ", "\\'9C")
            .Replace("ž", "\\'9E")
            .Replace("Ÿ", "\\'9F")
            .Replace("¡", "\\'A1")
            .Replace("¢", "\\'A2")
            .Replace("£", "\\'A3")
            .Replace("¤", "\\'A4")
            .Replace("¥", "\\'A5")
            .Replace("¦", "\\'A6")
            .Replace("§", "\\'A7")
            .Replace("¨", "\\'A8")
            .Replace("©", "\\'A9")
            .Replace("ª", "\\'AA")
            .Replace("«", "\\'AB")
            .Replace("¬", "\\'AC")
            .Replace("®", "\\'AE")
            .Replace("¯", "\\'AF")
            .Replace("°", "\\'B0")
            .Replace("±", "\\'B1")
            .Replace("²", "\\'B2")
            .Replace("³", "\\'B3")
            .Replace("´", "\\'B4")
            .Replace("µ", "\\'B5")
            .Replace("¶", "\\'B6")
            .Replace("·", "\\'B7")
            .Replace("¸", "\\'B8")
            .Replace("¹", "\\'B9")
            .Replace("º", "\\'BA")
            .Replace("»", "\\'BB")
            .Replace("¼", "\\'BC")
            .Replace("½", "\\'BD")
            .Replace("¾", "\\'BE")
            .Replace("¿", "\\'BF")
            .Replace("À", "\\'C0")
            .Replace("Á", "\\'C1")
            .Replace("Â", "\\'C2")
            .Replace("Ã", "\\'C3")
            .Replace("Ä", "\\'C4")
            .Replace("Å", "\\'C5")
            .Replace("Æ", "\\'C6")
            .Replace("Ç", "\\'C7")
            .Replace("È", "\\'C8")
            .Replace("É", "\\'C9")
            .Replace("Ê", "\\'CA")
            .Replace("Ë", "\\'CB")
            .Replace("Ì", "\\'CC")
            .Replace("Í", "\\'CD")
            .Replace("Î", "\\'CE")
            .Replace("Ï", "\\'CF")
            .Replace("Ð", "\\'D0")
            .Replace("Ñ", "\\'D1")
            .Replace("Ò", "\\'D2")
            .Replace("Ó", "\\'D3")
            .Replace("Ô", "\\'D4")
            .Replace("Õ", "\\'D5")
            .Replace("Ö", "\\'D6")
            .Replace("×", "\\'D7")
            .Replace("Ø", "\\'D8")
            .Replace("Ù", "\\'D9")
            .Replace("Ú", "\\'DA")
            .Replace("Û", "\\'DB")
            .Replace("Ü", "\\'DC")
            .Replace("Ý", "\\'DD")
            .Replace("Þ", "\\'DE")
            .Replace("ß", "\\'DF")
            .Replace("à", "\\'E0")
            .Replace("á", "\\'E1")
            .Replace("â", "\\'E2")
            .Replace("ã", "\\'E3")
            .Replace("ä", "\\'E4")
            .Replace("å", "\\'E5")
            .Replace("æ", "\\'E6")
            .Replace("ç", "\\'E7")
            .Replace("è", "\\'E8")
            .Replace("é", "\\'E9")
            .Replace("ê", "\\'EA")
            .Replace("ë", "\\'EB")
            .Replace("ì", "\\'EC")
            .Replace("í", "\\'ED")
            .Replace("î", "\\'EE")
            .Replace("ï", "\\'EF")
            .Replace("ð", "\\'F0")
            .Replace("ñ", "\\'F1")
            .Replace("ò", "\\'F2")
            .Replace("ó", "\\'F3")
            .Replace("ô", "\\'F4")
            .Replace("õ", "\\'F5")
            .Replace("ö", "\\'F6")
            .Replace("÷", "\\'F7")
            .Replace("ø", "\\'F8")
            .Replace("ù", "\\'F9")
            .Replace("ú", "\\'FA")
            .Replace("û", "\\'FB")
            .Replace("ü", "\\'FC")
            .Replace("ý", "\\'FD")
            .Replace("þ", "\\'FE")
            .Replace("ÿ", "\\'FF");
    }
}