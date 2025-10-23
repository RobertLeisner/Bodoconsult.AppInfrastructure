// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Base style for styles with page settings
/// </summary>
public abstract class PageStyleBase : StyleBase
{
    /// <summary>
    /// Name of the paper format, i.e. A4, Letter, Legal
    /// </summary>
    public string PaperFormatName { get; set; } = "A4";

    /// <summary>
    /// Page width in cm
    /// </summary>
    public double PageWidth { get; set; } = 21.0;

    /// <summary>
    /// Page height in cm
    /// </summary>
    public double PageHeight { get; set; } = 29.4;

    /// <summary>
    /// Left margin in cm
    /// </summary>
    public double MarginLeft { get; set; } = 3.0;

    /// <summary>
    /// Left margin in cm
    /// </summary>
    public double MarginTop { get; set; } = 2.0;

    /// <summary>
    /// Left margin in cm
    /// </summary>
    public double MarginRight { get; set; } = 2.0;

    /// <summary>
    /// Left margin in cm
    /// </summary>
    public double MarginBottom { get; set; } = 2.0;

    /// <summary>
    /// Type area width in cm
    /// </summary>
    [DoNotSerialize]
    public double TypeAreaWidth => PageWidth - MarginLeft - MarginRight;

    /// <summary>
    /// Type area height in cm
    /// </summary>
    [DoNotSerialize]
    public double TypeAreaHeight => PageHeight - MarginTop - MarginBottom;

    /// <summary>
    /// Max image width in cm
    /// </summary>
    [DoNotSerialize]
    public double MaxImageWidth => 0.95 * TypeAreaWidth;

    /// <summary>
    /// Max image height in cm
    /// </summary>
    [DoNotSerialize]
    public double MaxImageHeight => 0.33 * TypeAreaHeight;
}