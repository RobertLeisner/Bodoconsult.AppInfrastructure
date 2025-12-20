// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Collections.Generic;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Test.Helpers;

namespace Bodoconsult.Text.Test.TestData;

/// <summary>
/// Test class for a report factory
/// </summary>
internal class TestReportFactory : DocumentFactoryBase
{
    /// <summary>
    /// Create the full report. Implement all logic needed to create the full report you want to get
    /// </summary>
    public override void CreateDocument()
    {
        // Add a Title
        AddParagraph(ParagraphType.Title,"Securities portfolio management");

        // Add a Subtitle
        AddParagraph(ParagraphType.SubTitle,"The art of managing risk for securities portfolios");

        // Add a heading level 1
        AddHeading(HeadingLevel.Level1, "Introduction");

        // Add a simple paragraph
        AddParagraph(ParagraphType.Paragraph, TestDataHelper.MassText);

        AddParagraph(ParagraphType.Paragraph, TestDataHelper.MassText);

        AddParagraph(ParagraphType.Paragraph, TestDataHelper.MassText);

        AddHeading(HeadingLevel.Level1, "Securities portfolios");

        // Add a heading level 2
        AddHeading(HeadingLevel.Level2, "Asset Allocation");

        AddParagraph(ParagraphType.Citation, TestDataHelper.CitationText, "Fjodor Dostojewski");

        AddParagraph(ParagraphType.Paragraph, TestDataHelper.MassText);

        // Add an image
        AddImage("Test image", TestHelper.TestChartImage, 1725, 1075);

        AddParagraph(ParagraphType.Paragraph, TestDataHelper.MassText);

        AddParagraph(ParagraphType.Paragraph, TestDataHelper.MassText);

        AddTable(DataHelper.GetDataTable(), "Sample portfolio");

        // Add a figure 1
        AddFigure("A chart", TestHelper.TestChartImage, 1725, 1075);

        AddParagraph(ParagraphType.Paragraph, TestDataHelper.MassText);

        // Add a figure 2
        AddFigure("A distribution", TestHelper.TestDistributionImage, 1725, 1075);

        AddParagraph(ParagraphType.Paragraph, TestDataHelper.MassText);

        // Add a heading level 2
        AddHeading(HeadingLevel.Level2, "Asset classes");

        // Add a simple paragraph
        AddParagraph(ParagraphType.Paragraph, TestDataHelper.MassText);

        var list = new List<string>
        {
            "Shares",
            "Fixed income",
            "Real estate",
            "Liquidity"
        };

        AddList(list, ListStyleTypeEnum.Disc);

        // Add a simple Central paragraph
        AddParagraph(ParagraphType.ParagraphCenter, TestDataHelper.MassText);

        // Add a heading level 1
        AddHeading(HeadingLevel.Level1, "Asset classes en detail");

        // Add a heading level 2
        AddHeading(HeadingLevel.Level2, "Shares");

        // Add a heading level 3
        AddHeading(HeadingLevel.Level3, "Domestic shares");

        // Add a simple Right paragraph
        AddParagraph(ParagraphType.ParagraphRight, TestDataHelper.MassText);

        // Add a simple Justify paragraph
        AddParagraph(ParagraphType.ParagraphJustify, TestDataHelper.MassText);

        // Add an equation image
        AddEquation("Sample equation", TestHelper.TestEquationImage, 200, 50);

        // Add a code
        AddParagraph(ParagraphType.Code, TestDataHelper.MassText);

        // Add an info
        AddParagraph(ParagraphType.Paragraph, TestDataHelper.MassText);
        AddParagraph(ParagraphType.Info, TestDataHelper.MassText);

        // Add a heading level 3
        AddHeading(HeadingLevel.Level3, "International shares");


        // Add a Warning
        AddParagraph(ParagraphType.Paragraph, TestDataHelper.MassText);
        AddParagraph(ParagraphType.Warning, TestDataHelper.MassText);

        // Add an error
        AddParagraph(ParagraphType.Paragraph, TestDataHelper.MassText);
        AddParagraph(ParagraphType.Error, TestDataHelper.MassText);
        AddParagraph(ParagraphType.Paragraph, TestDataHelper.MassText);



        /*
        // Add a heading level 1
        heading1 = new Heading1("2. Heading level 1");
        section.AddBlock(heading1);

        // Add a heading level 2
        heading2 = new Heading2("2.1. Heading level 2");
        section.AddBlock(heading2);

        // Add a heading level 3
        heading3 = new Heading3("2.1.1. Heading level 3");
        section.AddBlock(heading3);

        // Add a heading level 4
        heading4 = new Heading4("2.1.1.1. Heading level 4");
        section.AddBlock(heading4);

        // Add a heading level 4
        heading5 = new Heading5("2.1.1.1.1. Heading level 5");
        section.AddBlock(heading5);

        // Add a paragraph with multiple inlines
        paragraph = new Paragraph("Paragraph with LineBreak and Bold and BoldItalic: ");

        //   Add a simple span
        var span = new Span(TestDataHelper.MassText);
        paragraph.AddInline(span);

        //   Add a line break
        paragraph.AddInline(new LineBreak());

        //   Add bold text
        var bold = new Bold(TestDataHelper.MassText);
        paragraph.AddInline(bold);

        section.AddBlock(paragraph);

        // Add a bold and italic text paragraph
        var bold2 = new Bold(TestDataHelper.MassText);

        var italic = new Italic();
        italic.AddInline(bold2);

        paragraph = new Paragraph();
        paragraph.AddInline(italic);
        section.AddBlock(paragraph);

        // Add a Citation



        // Add a hyperlink
        paragraph = new Paragraph("ParagraphWithHyperlink: this is a link: ");
        var link = new Hyperlink("Link to blubb")
        {
            Uri = "http://www.bodoconsult.de"
        };
        paragraph.AddInline(link);
        section.AddBlock(paragraph);

        // Add an image
        var image = new Image("Test image", TestHelper.TestChartImage)
        {
            OriginalHeight = 1075,
            OriginalWidth = 1725
        };
        section.AddBlock(image);

        // Add a figure 1
        var figure1 = new Figure("Figure 1", TestHelper.TestChartImage)
        {
            OriginalHeight = 1075,
            OriginalWidth = 1725
        }; ;
        section.AddBlock(figure1);

        // Add a figure 2
        var figure2 = new Figure("Figure 2", TestHelper.TestDistributionImage)
        {
            OriginalHeight = 1075,
            OriginalWidth = 1725
        }; ;
        section.AddBlock(figure2);

        // Add an equation 1
        var equiation1 = new Equation("Equation 1", TestHelper.TestEquationImage)
        {
            OriginalHeight = 159,
            OriginalWidth = 588
        }; ;
        section.AddBlock(equiation1);

        // Add an equation 2
        var equiation2 = new Equation("Equation 2", TestHelper.TestEquationImage)
        {
            OriginalHeight = 159,
            OriginalWidth = 588
        }; ;
        section.AddBlock(equiation2);

        // Add a list
        var list = new List();

        var listItem1 = new ListItem("First list item");
        list.AddBlock(listItem1);

        var listItem2 = new ListItem("Second list item");
        list.AddBlock(listItem2);

        section.AddBlock(list);
        */
    }


}