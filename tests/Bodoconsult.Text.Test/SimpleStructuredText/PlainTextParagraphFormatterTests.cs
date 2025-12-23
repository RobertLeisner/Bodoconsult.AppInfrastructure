// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Diagnostics;
using Bodoconsult.App.Abstractions.Interfaces;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Renderer.PlainText;
using Bodoconsult.Text.Test.Helpers;
using NUnit.Framework;

namespace Bodoconsult.Text.Test.SimpleStructuredText;

[TestFixture]
internal class PlainTextParagraphFormatterTests
{
    [Test]
    public void Ctor_DefaultSetup_PropsSetCorrectly()
    {
        // Arrange 
        var paragraphStyle = new ParagraphStyle();
        var pageStyle = new DocumentStyle();

        const string content = "Blubb";

        // Act  
        var f = new PlainTextParagraphFormatter(content, paragraphStyle, pageStyle);

        // Assert
        Assert.That(f.WidthInChars, Is.EqualTo(0));

    }

    [Test]
    public void CalculateValues_DefaultSetup_PropsSetCorrectly()
    {
        // Arrange 
        var paragraphStyle = new ParagraphStyle();
        var pageStyle = new DocumentStyle();

        const string content = "Blubb";

        var f = new PlainTextParagraphFormatter(content, paragraphStyle, pageStyle);

        // Act  
        f.CalculateValues();

        // Assert
        Assert.That(f.WidthInChars, Is.Not.EqualTo(0));

    }

    [Test]
    public void FormatText_ShortString_OneLineLeftAlignment()
    {
        // Arrange 
        var paragraphStyle = new ParagraphStyle();
        var pageStyle = new DocumentStyle();

        const string content = "Blubb";

        var f = new PlainTextParagraphFormatter(content, paragraphStyle, pageStyle);

        // Act  
        f.FormatText();

        // Assert
        Assert.That(f.Lines.Count, Is.EqualTo(2));

        Debug.Print(f.GetFormattedText().ToString());

    }

    [Test]
    public void FormatText_LongString_MultipleLinesLeftAlignment()
    {
        // Arrange 
        var paragraphStyle = new ParagraphStyle();
        var pageStyle = new DocumentStyle();

        const string content = TestDataHelper.MassText;

        var f = new PlainTextParagraphFormatter(content, paragraphStyle, pageStyle);

        // Act  
        f.FormatText();

        // Assert
        Assert.That(f.Lines.Count, Is.GreaterThan(1));

        Debug.Print(f.GetFormattedText().ToString());
    }

    [Test]
    public void FormatText_ListItemLongString_MultipleLinesLeftAlignment()
    {
        // Arrange 
        var paragraphStyle = new ListItemStyle
        {
            Margins =
            {
                Left = Styleset.DefaultMarginLeft,
                Right = Styleset.DefaultMarginLeft
            }
        };
        var pageStyle = new DocumentStyle();

        const string content = TestDataHelper.MassText;

        var f = new PlainTextParagraphFormatter(content, paragraphStyle, pageStyle)
        {
            ListChars = "*",
        };

        // Act  
        f.FormatText();

        // Assert
        Assert.That(f.Lines.Count, Is.GreaterThan(1));

        Debug.Print(f.GetFormattedText().ToString());
    }

    [Test]
    public void FormatText_LongString_MultipleLinesRightAlignment()
    {
        // Arrange 
        var paragraphStyle = new ParagraphStyle
        {
            TextAlignment = TypoTextAlignment.Right
        };
        var pageStyle = new DocumentStyle();

        const string content = TestDataHelper.MassText;

        var f = new PlainTextParagraphFormatter(content, paragraphStyle, pageStyle);

        // Act  
        f.FormatText();

        // Assert
        Assert.That(f.Lines.Count, Is.GreaterThan(1));

        Debug.Print(f.GetFormattedText().ToString());
    }

    [Test]
    public void FormatText_LongString_MultipleLinesJustiyAlignment()
    {
        // Arrange 
        var paragraphStyle = new ParagraphStyle
        {
            TextAlignment = TypoTextAlignment.Justify
        };
        var pageStyle = new DocumentStyle();

        const string content = TestDataHelper.MassText;

        var f = new PlainTextParagraphFormatter(content, paragraphStyle, pageStyle);

        // Act  
        f.FormatText();

        // Assert
        Assert.That(f.Lines.Count, Is.GreaterThan(1));

        Debug.Print(f.GetFormattedText().ToString());
    }


    [Test]
    public void FillLine_ValidString1_StringJustified()
    {
        // Arrange 
        const string value = "Lorem ipsum dolor ≥ = &gt; &#61; sit amet, consetetur";

        // Act  
        var result = PlainTextParagraphFormatter.FillLine(value, 11, 64);

        // Assert
        Debug.Print(result);

        Assert.That(result.Length, Is.GreaterThan(value.Length));

    }

    [Test]
    public void FillLine_ValidString2_StringJustified()
    {
        // Arrange 
        const string value = "sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut";

        // Act  
        var result = PlainTextParagraphFormatter.FillLine(value, 5, 64);

        // Assert
        Debug.Print(result);

        Assert.That(result.Length, Is.EqualTo(value.Length + 5));
    }


    [Test]
    public void FormatText_LongString_MultipleLinesCenterAlignment()
    {
        // Arrange 
        var paragraphStyle = new ParagraphStyle
        {
            TextAlignment = TypoTextAlignment.Center
        };
        var pageStyle = new DocumentStyle();

        const string content = TestDataHelper.MassText;

        var f = new PlainTextParagraphFormatter(content, paragraphStyle, pageStyle);

        // Act  
        f.FormatText();

        // Assert
        Assert.That(f.Lines.Count, Is.GreaterThan(1));

        Debug.Print(f.GetFormattedText().ToString());
    }

    [Test]
    public void FormatText_LongStringMargin_MultipleLinesLeftAlignment()
    {
        // Arrange 
        var paragraphStyle = new ParagraphStyle
        {
            Margins =
            {
                Left = Styleset.DefaultMarginLeft,
                Right = Styleset.DefaultMarginLeft
            }
        };

        var pageStyle = new DocumentStyle();

        const string content = TestDataHelper.MassText;

        var f = new PlainTextParagraphFormatter(content, paragraphStyle, pageStyle);

        // Act  
        f.FormatText();

        // Assert
        Assert.That(f.Lines.Count, Is.GreaterThan(1));

        Debug.Print(f.GetFormattedText().ToString());
    }

    [Test]
    public void FormatText_LongStringMargin_MultipleLinesJustifyAlignment()
    {
        // Arrange 
        var paragraphStyle = new ParagraphStyle
        {
            Margins =
            {
                Left = Styleset.DefaultMarginLeft,
                Right = Styleset.DefaultMarginLeft
            },
            TextAlignment = TypoTextAlignment.Justify
        };

        var pageStyle = new DocumentStyle();

        const string content = TestDataHelper.MassText;

        var f = new PlainTextParagraphFormatter(content, paragraphStyle, pageStyle);

        // Act  
        f.FormatText();

        // Assert
        Assert.That(f.Lines.Count, Is.GreaterThan(1));

        Debug.Print(f.GetFormattedText().ToString());
    }

    [Test]
    public void FormatText_LongStringMargin_MultipleLinesRightAlignment()
    {
        // Arrange 
        var paragraphStyle = new ParagraphStyle
        {
            TextAlignment = TypoTextAlignment.Right,
            Margins =
            {
                Left = Styleset.DefaultMarginLeft,
                Right = Styleset.DefaultMarginLeft
            }
        };
        var pageStyle = new DocumentStyle();

        const string content = TestDataHelper.MassText;

        var f = new PlainTextParagraphFormatter(content, paragraphStyle, pageStyle);

        // Act  
        f.FormatText();

        // Assert
        Assert.That(f.Lines.Count, Is.GreaterThan(1));

        Debug.Print(f.GetFormattedText().ToString());
    }

    [Test]
    public void FormatText_LongStringMargin_MultipleLinesCenterAlignment()
    {
        // Arrange 
        var paragraphStyle = new ParagraphStyle
        {
            TextAlignment = TypoTextAlignment.Center,
            Margins =
            {
                Left = Styleset.DefaultMarginLeft,
                Right = Styleset.DefaultMarginLeft
            }
        };
        var pageStyle = new DocumentStyle();

        const string content = TestDataHelper.MassText;

        var f = new PlainTextParagraphFormatter(content, paragraphStyle, pageStyle);

        // Act  
        f.FormatText();

        // Assert
        Assert.That(f.Lines.Count, Is.GreaterThan(1));

        Debug.Print(f.GetFormattedText().ToString());
    }

    [Test]
    public void FormatText_LongStringMarginBorderPadding_MultipleLinesLeftAlignment()
    {
        // Arrange 
        var paragraphStyle = new ParagraphStyle
        {
            Margins =
            {
                Left = Styleset.DefaultMarginLeft,
                Right = Styleset.DefaultMarginLeft
            },
            BorderBrush = new SolidColorBrush(Styleset.DefaultColor),
            BorderThickness =
            {
                Left = 1,
                Top = 1,
                Right = 1,
                Bottom = 1
            },
            Paddings =
            {
                Left = 2,
                Right = 2
            },
        };

        var pageStyle = new DocumentStyle();

        const string content = TestDataHelper.MassText;

        var f = new PlainTextParagraphFormatter(content, paragraphStyle, pageStyle);

        // Act  
        f.FormatText();

        // Assert
        Assert.That(f.Lines.Count, Is.GreaterThan(1));

        Debug.Print(f.GetFormattedText().ToString());
    }

    [Test]
    public void FormatText_LongStringMarginBorderPadding_MultipleLinesRightAlignment()
    {
        // Arrange 
        var paragraphStyle = new ParagraphStyle
        {
            Margins =
            {
                Left = Styleset.DefaultMarginLeft,
                Right = Styleset.DefaultMarginLeft
            },
            BorderBrush = new SolidColorBrush(Styleset.DefaultColor),
            BorderThickness =
            {
                Left = 1,
                Top = 1,
                Right = 1,
                Bottom = 1
            },
            Paddings =
            {
                Left = Styleset.DefaultMarginLeft,
                Right = Styleset.DefaultMarginLeft
            },
            TextAlignment = TypoTextAlignment.Right
        };

        var pageStyle = new DocumentStyle();

        const string content = TestDataHelper.MassText;

        var f = new PlainTextParagraphFormatter(content, paragraphStyle, pageStyle);

        // Act  
        f.FormatText();

        // Assert
        Assert.That(f.Lines.Count, Is.GreaterThan(1));

        Debug.Print(f.GetFormattedText().ToString());
    }

    [Test]
    public void FormatText_LongStringMarginBorderPadding_MultipleLinesCenterAlignment()
    {
        // Arrange 
        var paragraphStyle = new ParagraphStyle
        {
            Margins =
            {
                Left = Styleset.DefaultMarginLeft,
                Right = Styleset.DefaultMarginLeft
            },
            BorderBrush = new SolidColorBrush(Styleset.DefaultColor),
            BorderThickness =
            {
                Left = 1,
                Top = 1,
                Right = 1,
                Bottom = 1
            },
            Paddings =
            {
                Left = Styleset.DefaultMarginLeft,
                Right = Styleset.DefaultMarginLeft
            },
            TextAlignment = TypoTextAlignment.Center
        };

        var pageStyle = new DocumentStyle();

        const string content = TestDataHelper.MassText;

        var f = new PlainTextParagraphFormatter(content, paragraphStyle, pageStyle);

        // Act  
        f.FormatText();

        // Assert
        Assert.That(f.Lines.Count, Is.GreaterThan(1));

        Debug.Print(f.GetFormattedText().ToString());
    }
}