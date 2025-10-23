﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Blocks;

/// <summary>
/// PDF rendering element for <see cref="HeadingBase"/> instances
/// </summary>
public abstract class HeadingBasePdfTextRendererElement : ParagraphPdfTextRendererElementBase
{
    private readonly HeadingBase _headingBase;

    /// <summary>
    /// Default ctor
    /// </summary>
    protected HeadingBasePdfTextRendererElement(HeadingBase headingBase) : base(headingBase)
    {
        _headingBase = headingBase;
        ClassName = headingBase.StyleName;
    }
}