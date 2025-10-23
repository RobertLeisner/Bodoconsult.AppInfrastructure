// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System.Collections.Generic;
using System.Data;
using Bodoconsult.Text.Enums;

namespace Bodoconsult.Text.Interfaces;

/// <summary>
/// Represents a complete structured text
/// </summary>
public interface IStructuredText
{
    /// <summary>
    /// Keep items and formatted it as empty paragraphs
    /// </summary>
    bool KeepEmptyItems { get; set; }

    /// <summary>
    /// Contains the text items
    /// </summary>
    IList<ITextItem> TextItems { get; }

    /// <summary>
    /// Clear the structured text
    /// </summary>
    void Clear();

    /// <summary>
    /// Add a header level 1
    /// </summary>
    /// <param name="message">text to append</param>
    /// <param name="className">Class name for formatting</param>
    void AddHeader1(string message, string className = null);

    /// <summary>
    /// Add a header level 1
    /// </summary>
    /// <param name="message">text to append</param>
    /// <param name="className">Class name for formatting</param>
    /// <param name="data">An object array to format</param>
    void AddHeader1(string message, string className = null, params object[] data);

    /// <summary>
    /// Add a header level 2
    /// </summary>
    /// <param name="message">text to append</param>
    /// <param name="className">Class name for formatting</param>
    void AddHeader2(string message, string className = null);

    /// <summary>
    /// Add a header level 2
    /// </summary>
    /// <param name="message">text to append</param>
    /// <param name="className">Class name for formatting</param>
    /// <param name="data">An object array to format</param>
    void AddHeader2(string message, string className = null, params object[] data);

    /// <summary>
    /// Add a header level 3
    /// </summary>
    /// <param name="message">text to append</param>
    /// <param name="className">Class name for formatting</param>
    void AddHeader3(string message, string className = null);

    /// <summary>
    /// Add a header level 3
    /// </summary>
    /// <param name="message">text to append</param>
    /// <param name="className">Class name for formatting</param>
    /// <param name="data">An object array to format</param>
    void AddHeader3(string message, string className = null, params object[] data);

    /// <summary>
    /// Add a header level 4
    /// </summary>
    /// <param name="message">text to append</param>
    /// <param name="className">Class name for formatting</param>
    void AddHeader4(string message, string className = null);

    /// <summary>
    /// Add a header level 4
    /// </summary>
    /// <param name="message">text to append</param>
    /// <param name="className">Class name for formatting</param>
    /// <param name="data">An object array to format</param>
    void AddHeader4(string message, string className = null, params object[] data);

    /// <summary>
    /// Add a paragraph
    /// </summary>
    /// <param name="message">text to append</param>
    /// <param name="className">Class name for formatting</param>
    void AddParagraph(string message, string className = null);

    /// <summary>
    /// Add a paragraph
    /// </summary>
    /// <param name="message">text to append</param>
    /// <param name="className">Class name for formatting</param>
    /// <param name="data">An object array to format</param>
    void AddParagraph(string message, string className = null, params object[] data);

    /// <summary>
    /// Add a info paragraph
    /// </summary>
    /// <param name="message">text to append</param>
    /// <param name="className">Class name for formatting</param>
    void AddInfo(string message, string className = null);

    /// <summary>
    /// Add a info paragraph
    /// </summary>
    /// <param name="message">text to append</param>
    /// <param name="className">Class name for formatting</param>
    /// <param name="data">An object array to format</param>
    void AddInfo(string message, string className = null, params object[] data);


    /// <summary>
    /// Add a warning paragraph
    /// </summary>
    /// <param name="message">text to append</param>
    /// <param name="className">Class name for formatting</param>
    void AddWarning(string message, string className = null);

    /// <summary>
    /// Add a warning paragraph
    /// </summary>
    /// <param name="message">text to append</param>
    /// <param name="className">Class name for formatting</param>
    /// <param name="data">An object array to format</param>
    void AddWarning(string message, string className = null, params object[] data);


    /// <summary>
    /// Add a error paragraph
    /// </summary>
    /// <param name="message">text to append</param>
    /// <param name="className">Class name for formatting</param>
    void AddError(string message, string className = null);

    /// <summary>
    /// Add a error paragraph
    /// </summary>
    /// <param name="message">text to append</param>
    /// <param name="className">Class name for formatting</param>
    /// <param name="data">An object array to format</param>
    void AddError(string message, string className = null, params object[] data);

    /// <summary>
    /// Add a text with a certain text type
    /// </summary>
    /// <param name="message"></param>
    /// <param name="className">Class name for formatting</param>
    /// <param name="textItemType"></param>
    void AddText(string message, TextItemType textItemType, string className = null);

    /// <summary>
    /// Add a text with a certain text type
    /// </summary>
    /// <param name="message">text to append</param>
    /// <param name="textItemType">Type of text</param>
    /// <param name="className">Class name for formatting</param>
    /// <param name="data">An object array to format</param>
    void AddText(string message, TextItemType textItemType, string className = null, params object[] data);


    /// <summary>
    /// Add a XML string as paragraph with indented formatting
    /// </summary>
    /// <param name="message">XML string to append</param>
    /// <param name="className">Class name for formatting</param>
    void AddXml(string message, string className = null);

    /// <summary>
    /// Add a code segment as paragraph with indented formatting
    /// </summary>
    /// <param name="message">XML string to append</param>
    /// <param name="className">Class name for formatting</param>
    void AddCode(string message, string className = null);


    /// <summary>
    /// Add a definition list line as paragraph
    /// </summary>
    /// <param name="leftColumn">Content of the left column</param>
    /// <param name="rightColumn">Content of the right column</param>
    void AddDefinitionListLine(string leftColumn, string rightColumn);


    /// <summary>
    /// Add a list item to the text. Results in HTML in a ul-Tag with li-Tag items
    /// </summary>
    /// <param name="message">text to append</param>
    /// <param name="className">Class name for formatting</param>
    void AddListItem(string message, string className = null);


    /// <summary>
    /// Add a list item to the text. Results in HTML in a ul-Tag with li-Tag items
    /// </summary>
    /// <param name="message">text to append</param>
    /// <param name="className">Class name for formatting</param>
    /// <param name="data">An object array to format</param>
    void AddListItem(string message, string className = null, params object[] data);


    /// <summary>
    /// Add a table to the text
    /// </summary>
    /// <param name="title">title for the table</param>
    /// <param name="data">data for the table content</param>
    void AddTable(string title, DataTable data);
}