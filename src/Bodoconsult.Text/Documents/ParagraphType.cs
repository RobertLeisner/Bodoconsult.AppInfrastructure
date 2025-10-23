// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Paragraph style
/// </summary>
public enum ParagraphType
{
    /// <summary>
    /// Left aligned paragraph
    /// </summary>
    Paragraph,
    /// <summary>
    /// Centered paragraph
    /// </summary>
    ParagraphCenter,
    /// <summary>
    /// Justified paragraph
    /// </summary>
    ParagraphJustify,
    /// <summary>
    /// Right aligned paragraph
    /// </summary>
    ParagraphRight,
    /// <summary>
    /// Paragraph containing a citation
    /// </summary>
    Citation,
    /// <summary>
    /// Paragraph containing a code piece
    /// </summary>
    Code,
    /// <summary>
    /// Paragraph containing an info message
    /// </summary>
    Info,
    /// <summary>
    /// Paragraph containing a warning message
    /// </summary>
    Warning,
    /// <summary>
    /// Paragraph containing an error message
    /// </summary>
    Error,
    /// <summary>
    /// Title
    /// </summary>
    Title,
    /// <summary>
    /// Subtitle
    /// </summary>
    SubTitle,
    /// <summary>
    /// Section title
    /// </summary>
    SectionTitle,
    /// <summary>
    /// Section subtitle
    /// </summary>
    SectionSubtitle

}