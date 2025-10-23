// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


namespace Bodoconsult.Text.Interfaces;

/// <summary>
/// Formatting <see cref="IStructuredText"/> to certain target like HTML or plain text
/// </summary>
public interface ITextFormatter
{

    /// <summary>
    /// Structured text to format
    /// </summary>
    IStructuredText StructuredText { get; set; }

    /// <summary>
    /// Template to place the structered text. Must contain placeholder {0} for the structured text
    /// </summary>
    string Template { get; set; }



    /// <summary>
    /// Title for documentation
    /// </summary>
    string Title { get; set; }



    /// <summary>
    /// Show the date the text was created. I.e.: "date created: 7.7.2018"
    /// </summary>
    string DateString { get; set; }


    /// <summary>
    /// Get the formatted text
    /// </summary>
    /// <returns>formatted text</returns>
    string GetFormattedText();

}