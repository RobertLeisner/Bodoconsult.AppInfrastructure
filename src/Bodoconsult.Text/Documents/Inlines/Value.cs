// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// A value element contains plain text
/// </summary>
public class Value : SpanBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public Value()
    {
        // Tag to use
        TagToUse = string.Intern("Value");
    }

    /// <summary>
    /// Ctor to load content
    /// </summary>
    /// <param name="content">Content to load</param>
    public Value(string content)
    {

        // Tag to use
        TagToUse = string.Intern("Value");

        // Content
        Content = content;
    }
}