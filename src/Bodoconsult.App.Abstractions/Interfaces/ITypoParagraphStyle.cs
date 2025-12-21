// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.App.Abstractions.Interfaces;

/// <summary>
/// Interface for paragraph styles
/// </summary>
public interface ITypoParagraphStyle
{
    /// <summary>
    /// Font name
    /// </summary>
    public string FontName { get; }

    /// <summary>
    /// Font size in pt
    /// </summary>
    public int FontSize { get; }

    /// <summary>
    /// Font color
    /// </summary>
    public TypoColor TypoFontColor { get; }

    /// <summary>
    /// Bold
    /// </summary>
    public bool Bold { get; set; }

    /// <summary>
    /// Italic
    /// </summary>
    public bool Italic { get; set; }

    /// <summary>
    /// Text alignment legt, center, justify or right
    /// </summary>
    public TypoTextAlignment TextAlignment { get; }

    /// <summary>
    /// Margins
    /// </summary>
    public TypoThickness TypoMargins { get; }

    /// <summary>
    /// Border brush
    /// </summary>
    public TypoBrush TypoBorderBrush { get; }

    /// <summary>
    /// Current borderline width setting
    /// </summary>
    public TypoThickness TypoBorderThickness { get; }

    /// <summary>
    /// Paddings. Padding settings are applied only if a border is set
    /// </summary>
    public TypoThickness TypoPaddings { get; }

    /// <summary>
    /// Indent of the first line in pt. Negative number is indicating a hanging indent
    /// </summary>
    public double FirstLineIndent { get; }

    /// <summary>
    /// Add a page break before the heading. Default: false
    /// </summary>
    public bool PageBreakBefore { get; }

    /// <summary>
    /// Add a page break before the heading. Default: false
    /// </summary>
    public bool KeepWithNextParagraph { get; }

    /// <summary>
    /// Keep the paragraph together on one side. Default: false
    /// </summary>
    public bool KeepTogether { get; }
}