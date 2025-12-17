// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Abstractions.Interfaces;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for <see cref="ParagraphCenter"/> instances
/// </summary>
public class ParagraphCenterStyle : ParagraphStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public ParagraphCenterStyle()
    {
        TagToUse = "ParagraphCenterStyle";
        Name = TagToUse;
        TextAlignment = TypoTextAlignment.Center;
    }
}