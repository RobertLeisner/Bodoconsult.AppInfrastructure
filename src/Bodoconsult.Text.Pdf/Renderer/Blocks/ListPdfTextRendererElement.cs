// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System;
using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Blocks;

/// <summary>
/// HTML rendering element for <see cref="List"/> instances
/// </summary>
public class ListPdfTextRendererElement : PdfTextRendererElementBase
{
    private readonly List _list;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ListPdfTextRendererElement(List list) : base(list)
    {
        _list = list;
        ClassName = list.StyleName;

        switch (list.ListStyleType)
        {
            case ListStyleTypeEnum.Disc:
                LocalCss = "list-style-type: disc";
                break;
            case ListStyleTypeEnum.Circle:
                LocalCss = "list-style-type: circle";
                break;
            case ListStyleTypeEnum.Square:
                LocalCss = "list-style-type: square";
                break;
            case ListStyleTypeEnum.Customized:
                LocalCss = $"list-style-type: '{_list.ListStyleTypeChar}'";
                break;
            case ListStyleTypeEnum.Decimal:
                LocalCss = "list-style-type: decimal";
                break;
            case ListStyleTypeEnum.DecimalLeadingZero:
                LocalCss = "list-style-type: decimal-leading-zero";
                break;
            case ListStyleTypeEnum.UpperRoman:
                LocalCss = "list-style-type: upper-roman";
                break;
            case ListStyleTypeEnum.LowerRoman:
                LocalCss = "list-style-type: lower-roman";
                break;
            case ListStyleTypeEnum.UpperLatin:
                LocalCss = "list-style-type: upper-latin";
                break;
            case ListStyleTypeEnum.LowerLatin:
                LocalCss = "list-style-type: lower-latin";
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

    }
}