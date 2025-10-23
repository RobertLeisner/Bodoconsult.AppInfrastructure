// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System;
using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html;

/// <summary>
/// HTML rendering element for <see cref="List"/> instances
/// </summary>
public class ListHtmlTextRendererElement : HtmlTextRendererElementBase
{
    private readonly List _list;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ListHtmlTextRendererElement(List list) : base(list)
    {
        _list = list;
        ClassName = list.StyleName;

        switch (list.ListStyleType)
        {
            case ListStyleTypeEnum.Disc:
                LocalCss = "list-style-type: disc";
                TagToUse = "ul";
                break;
            case ListStyleTypeEnum.Circle:
                LocalCss = "list-style-type: circle";
                TagToUse = "ul";
                break;
            case ListStyleTypeEnum.Square:
                LocalCss = "list-style-type: square";
                TagToUse = "ul";
                break;
            case ListStyleTypeEnum.Customized:
                LocalCss = $"list-style-type: '{_list.ListStyleTypeChar}'";
                TagToUse = "ul";
                break;
            case ListStyleTypeEnum.Decimal:
                LocalCss = "list-style-type: decimal";
                TagToUse = "ol";
                break;
            case ListStyleTypeEnum.DecimalLeadingZero:
                LocalCss = "list-style-type: decimal-leading-zero";
                TagToUse = "ol";
                break;
            case ListStyleTypeEnum.UpperRoman:
                LocalCss = "list-style-type: upper-roman";
                TagToUse = "ol";
                break;
            case ListStyleTypeEnum.LowerRoman:
                LocalCss = "list-style-type: lower-roman";
                TagToUse = "ol";
                break;
            case ListStyleTypeEnum.UpperLatin:
                LocalCss = "list-style-type: upper-latin";
                TagToUse = "ol";
                break;
            case ListStyleTypeEnum.LowerLatin:
                LocalCss = "list-style-type: lower-latin";
                TagToUse = "ol";
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

    }
}