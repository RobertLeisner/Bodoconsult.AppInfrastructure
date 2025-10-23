// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// A span element contains plain text
/// </summary>
public class Span: SpanBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public Span()
    {
        // Tag to use
        TagToUse = string.Intern("Span");
    }

    /// <summary>
    /// Ctor to load content
    /// </summary>
    /// <param name="content">Content to load</param>
    public Span(string content)
    {

        // Tag to use
        TagToUse = string.Intern("Span");

        // Content
        Content = content;
    }
}