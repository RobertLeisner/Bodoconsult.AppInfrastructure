// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// A style for a normal left aligned paragraph
/// </summary>
public class ParagraphStyleBase : StyleBase
{
    /// <summary>
    /// Font name
    /// </summary>
    public string FontName { get; set; } = Styleset.DefaultFontName;

    /// <summary>
    /// Font size in pt
    /// </summary>
    public int FontSize { get; set; } = Styleset.DefaultFontSize;

    /// <summary>
    /// Font color
    /// </summary>
    public Color FontColor { get; set; } = Styleset.DefaultColor;

    /// <summary>
    /// Bold
    /// </summary>
    public bool Bold { get; set; }

    /// <summary>
    /// Italic
    /// </summary>
    public bool Italic { get; set; }

    /// <summary>
    /// Text alignment legt, center, justify or right. Default: left
    /// </summary>
    public TextAlignment TextAlignment { get; set; } = TextAlignment.Left;

    /// <summary>
    /// Margins
    /// </summary>
    public Thickness Margins { get; set; } = new(0, Styleset.DefaultFontSize * 0.5, 0, 0);

    /// <summary>
    /// Border brush
    /// </summary>
    public Brush BorderBrush { get; set; }

    /// <summary>
    /// Current borderline width setting
    /// </summary>
    public Thickness BorderThickness { get; set; } = new(0, 0, 0, 0);

    /// <summary>
    /// Paddings. Padding settings are applied only if a border is set
    /// </summary>
    public Thickness Paddings { get; set; } = new(0, 0, 0, 0);

    /// <summary>
    /// Indent of the first line in pt. Negative number is indicating a hanging indent
    /// </summary>
    public double FirstLineIndent { get; set; }

    /// <summary>
    /// Add a page break before the heading. Default: false
    /// </summary>
    public bool PageBreakBefore { get; set; } = false;

    /// <summary>
    /// Add a page break before the heading. Default: false
    /// </summary>
    public bool KeepWithNextParagraph { get; set; } = false;

    /// <summary>
    /// Keep the paragraph together on one side. Default: false
    /// </summary>
    public bool KeepTogether { get; set; } = false;
}