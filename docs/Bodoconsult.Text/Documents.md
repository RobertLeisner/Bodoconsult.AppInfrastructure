Generating, viewing, exporting and printing structured documents with LDML
===============================

LDML is a markup language to define the content of structured text documents with paragraphs, headings, images, figures etc.. With the help of renderers the LDML markup can be translated into file formats like HTML, TXT and PDF.


``` csharp

```

``` csharp

```

# Fast access to LDML: DocumentBuilder class

Normally you should not have to deal to much with LGML directly. For eyery different document your need you should create a derived class based on DocumentFactoryBase and create an override for CreateDocument() method to build your document as required.

![DocumentBuilder class](../../images/DocumentBuilder.png)

Document factories based on DocumentFactoryBase can be loaded via DI container using a factory of factories as it implements IDocumentFactory interface.

``` csharp

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
    }
}
```


Then setup a DocumentBuilder instance with this factory and choose a IDocumentRendererFactory as requested. Currently available are PlainTextDocumentRendererFactory, RtfDocumentRendererFactory and HtmlDocumentRendererFactory in Bodoconsult.Text Nuget package and PdfDocumentRendererFactory in Bodoconsult.Text.Pdf Nuget package.

``` csharp
    [Test]
    public void SaveAsFile_ValidSetupRealWorldRtf_FileCreated()
    {
        // Arrange 
        var filePath = Path.Combine(Path.GetTempPath(), "test.rtf");

        // Factory for the document content
        IDocumentFactory factory = new TestReportFactory();

        // Renderer factory
        IDocumentRendererFactory rendererFactory = new RtfDocumentRendererFactory();

        // Set up the document builder
        var report = new DocumentBuilder(factory, rendererFactory)
        {
            DocumentMetaData =
            {
                Title = "Securities portfolio management",
                Description = "Basics of sercurity portfolio management",
                Keywords = "Securities, portfolio, management, risk, asset, allocation",
                Company = "Bodoconsult GmbH",
                CompanyWebsite = "http://www.bodoconsult.de",
                Authors = "Robert Leisner",
                IsTocRequired = true,
                IsFiguresTableRequired = true,
                IsEquationsTableRequired = true
            }
        };

        // Load your customized styleset if needed (StylesetHelper.CreateDefaultStyleset() is the default styleset loaded automatically)
        var styleSet = StylesetHelper.CreateDefaultStyleset();
        report.Styleset = styleSet;

        // Now create the document
        report.CreateDocument();

        // Now let TOC, TOF and TOE be calculated if necessary
        report.CalculateDocument();

        // Now render the document
        report.RenderDocument();

        // Act  
        Assert.DoesNotThrow(() =>
        {
            // Save the rendered file
            report.SaveAsFile(filePath);
        });

        // Assert
        Assert.That(File.Exists(filePath), Is.Not.Null);

        FileSystemHelper.RunInDebugMode(filePath);
    }
```

# Logical document markup landuage (LDML)

LDML is a XML based markup language to define and store structured text documents.

## Overview

``` xml
<Document Name="MyReport">
    <Styleset DefaultMarginLeft="28,3" DefaultMarginRight="28,3" Name="Default">
        <DocumentStyle PaperFormatName="A4" PageWidth="21" PageHeight="29,4" MarginLeft="3" MarginTop="2" MarginRight="2" MarginBottom="2" Name="DocumentStyle" />
        <SectionStyle PaperFormatName="A4" PageWidth="21" PageHeight="29,4" MarginLeft="3" MarginTop="2" MarginRight="2" MarginBottom="2" Name="SectionStyle" />
        <TocSectionStyle PaperFormatName="A4" PageWidth="21" PageHeight="29,4" MarginLeft="3" MarginTop="2" MarginRight="2" MarginBottom="2" Name="TocSectionStyle" />
        <TofSectionStyle PaperFormatName="A4" PageWidth="21" PageHeight="29,4" MarginLeft="3" MarginTop="2" MarginRight="2" MarginBottom="2" Name="TofSectionStyle" />
        <ToeSectionStyle PaperFormatName="A4" PageWidth="21" PageHeight="29,4" MarginLeft="3" MarginTop="2" MarginRight="2" MarginBottom="2" Name="ToeSectionStyle" />
        <TotSectionStyle PaperFormatName="A4" PageWidth="21" PageHeight="29,4" MarginLeft="3" MarginTop="2" MarginRight="2" MarginBottom="2" Name="TotSectionStyle" />
        <CitationStyle FontName="Calibri" FontSize="12" FontColor="#000000" Bold="False" Italic="True" TextAlignment="Center" Margins="28,3,18,28,3,0" FirstLineIndent="0" PageBreakBefore="False" KeepWithNextParagraph="True" KeepTogether="True" Name="CitationStyle" />
        <CitationSourceStyle FontName="Calibri" FontSize="8" FontColor="#000000" Bold="False" Italic="False" TextAlignment="Center" Margins="28,3,0,28,3,6" FirstLineIndent="0" PageBreakBefore="False" KeepWithNextParagraph="False" KeepTogether="False" Name="CitationSourceStyle" />
        <CodeStyle FontName="Courier New" FontSize="12" FontColor="#000000" Bold="False" Italic="False" TextAlignment="Left" Margins="0,6,0,0" FirstLineIndent="0" PageBreakBefore="False" KeepWithNextParagraph="False" KeepTogether="False" Name="CodeStyle" />
        <ColumnStyle Name="ColumnStyle" />
        <CellLeftStyle FontName="Calibri" FontSize="12" FontColor="#000000" Bold="False" Italic="False" TextAlignment="Left" Margins="0,6,0,0" BorderThickness="1,1,1,1" Paddings="2,2,2,2" FirstLineIndent="0" PageBreakBefore="False" KeepWithNextParagraph="False" KeepTogether="False" Name="CellLeftStyle" >
            <BorderBrush>
                <SolidColorBrush Color="#000000"/>
            </BorderBrush>
        </CellLeftStyle>
        <CellRightStyle FontName="Calibri" FontSize="12" FontColor="#000000" Bold="False" Italic="False" TextAlignment="Right" Margins="0,6,0,0" BorderThickness="1,1,1,1" Paddings="2,2,2,2" FirstLineIndent="0" PageBreakBefore="False" KeepWithNextParagraph="False" KeepTogether="False" Name="CellRightStyle" >
            <BorderBrush>
                <SolidColorBrush Color="#000000"/>
            </BorderBrush>
        </CellRightStyle>
        <CellCenterStyle FontName="Calibri" FontSize="12" FontColor="#000000" Bold="False" Italic="False" TextAlignment="Center" Margins="0,6,0,0" BorderThickness="1,1,1,1" Paddings="2,2,2,2" FirstLineIndent="0" PageBreakBefore="False" KeepWithNextParagraph="False" KeepTogether="False" Name="CellCenterStyle" >
            <BorderBrush>
                <SolidColorBrush Color="#000000"/>
            </BorderBrush>
        </CellCenterStyle>
        <DefinitionListStyle Margins="0,12,0,0" Name="DefinitionListStyle" />
        <DefinitionListTermStyle FontName="Calibri" FontSize="12" FontColor="#000000" Bold="False" Italic="True" TextAlignment="Left" Margins="0,6,0,0" FirstLineIndent="0" PageBreakBefore="False" KeepWithNextParagraph="False" KeepTogether="False" Name="DefinitionListTermStyle" />
        <DefinitionListItemStyle FontName="Calibri" FontSize="12" FontColor="#000000" Bold="False" Italic="False" TextAlignment="Left" Margins="0,6,0,0" FirstLineIndent="0" PageBreakBefore="False" KeepWithNextParagraph="False" KeepTogether="False" Name="DefinitionListItemStyle" />
        <EquationStyle Width="NaN" Height="NaN" FontName="Calibri" FontSize="12" FontColor="#000000" Bold="False" Italic="True" TextAlignment="Center" Margins="0,6,0,6" FirstLineIndent="0" PageBreakBefore="False" KeepWithNextParagraph="False" KeepTogether="False" Name="EquationStyle" />
        <ErrorStyle FontName="Calibri" FontSize="12" FontColor="#000000" Bold="False" Italic="False" TextAlignment="Left" Margins="0,18,0,18" BorderThickness="1,1,1,1" Paddings="6,6,6,6" FirstLineIndent="0" PageBreakBefore="False" KeepWithNextParagraph="False" KeepTogether="True" Name="ErrorStyle" >
            <BorderBrush>
                <SolidColorBrush Color="#FF0000"/>
            </BorderBrush>
        </ErrorStyle>
        <FigureStyle Width="NaN" Height="NaN" FontName="Calibri" FontSize="12" FontColor="#000000" Bold="False" Italic="True" TextAlignment="Center" Margins="0,6,0,6" FirstLineIndent="0" PageBreakBefore="False" KeepWithNextParagraph="False" KeepTogether="False" Name="FigureStyle" />
        <FooterStyle FontName="Calibri" FontSize="8" FontColor="#000000" Bold="False" Italic="False" TextAlignment="Left" Margins="0,6,0,0" FirstLineIndent="0" PageBreakBefore="False" KeepWithNextParagraph="False" KeepTogether="False" Name="FooterStyle" />
        <HeaderStyle FontName="Calibri" FontSize="8" FontColor="#000000" Bold="False" Italic="False" TextAlignment="Left" Margins="0,6,0,0" FirstLineIndent="0" PageBreakBefore="False" KeepWithNextParagraph="False" KeepTogether="False" Name="HeaderStyle" />
        <Heading1Style FontName="Calibri" FontSize="18" FontColor="#000000" Bold="True" Italic="False" TextAlignment="Left" Margins="0,48,0,12" BorderThickness="0,2,0,2" Paddings="0,6,0,6" FirstLineIndent="0" PageBreakBefore="True" KeepWithNextParagraph="True" KeepTogether="False" Name="Heading1Style" >
            <BorderBrush>
                <SolidColorBrush Color="#00FFFF"/>
            </BorderBrush>
        </Heading1Style>
        <Heading2Style FontName="Calibri" FontSize="16" FontColor="#000000" Bold="True" Italic="False" TextAlignment="Left" Margins="0,12,0,0" BorderThickness="0,0,0,1" Paddings="0,6,0,6" FirstLineIndent="0" PageBreakBefore="False" KeepWithNextParagraph="True" KeepTogether="False" Name="Heading2Style" >
            <BorderBrush>
                <SolidColorBrush Color="#000000"/>
            </BorderBrush>
        </Heading2Style>
        <Heading3Style FontName="Calibri" FontSize="14" FontColor="#000000" Bold="True" Italic="False" TextAlignment="Left" Margins="0,24,0,0" Paddings="0,6,0,6" FirstLineIndent="0" PageBreakBefore="False" KeepWithNextParagraph="True" KeepTogether="False" Name="Heading3Style" />
        <Heading4Style FontName="Calibri" FontSize="12" FontColor="#000000" Bold="True" Italic="False" TextAlignment="Left" Margins="0,12,0,0" Paddings="0,6,0,6" FirstLineIndent="0" PageBreakBefore="False" KeepWithNextParagraph="True" KeepTogether="False" Name="Heading4Style" />
        <Heading5Style FontName="Calibri" FontSize="12" FontColor="#000000" Bold="False" Italic="True" TextAlignment="Left" Margins="0,6,0,0" FirstLineIndent="0" PageBreakBefore="False" KeepWithNextParagraph="True" KeepTogether="False" Name="Heading5Style" />
        <ImageStyle Width="NaN" Height="NaN" FontName="Calibri" FontSize="12" FontColor="#000000" Bold="False" Italic="True" TextAlignment="Center" Margins="0,6,0,6" FirstLineIndent="0" PageBreakBefore="False" KeepWithNextParagraph="False" KeepTogether="False" Name="ImageStyle" />
        <InfoStyle FontName="Calibri" FontSize="12" FontColor="#000000" Bold="False" Italic="False" TextAlignment="Left" Margins="0,18,0,18" BorderThickness="1,1,1,1" Paddings="6,6,6,6" FirstLineIndent="0" PageBreakBefore="False" KeepWithNextParagraph="False" KeepTogether="True" Name="InfoStyle" >
            <BorderBrush>
                <SolidColorBrush Color="#000000"/>
            </BorderBrush>
        </InfoStyle>
        <ListStyle FontName="Calibri" FontSize="12" FontColor="#000000" Bold="False" Italic="False" TextAlignment="Left" Margins="0,6,0,0" FirstLineIndent="0" PageBreakBefore="False" KeepWithNextParagraph="False" KeepTogether="False" Name="ListStyle" />
        <ListItemStyle FontName="Calibri" FontSize="12" FontColor="#000000" Bold="False" Italic="False" TextAlignment="Left" Margins="28,3,6,0,0" FirstLineIndent="0" PageBreakBefore="False" KeepWithNextParagraph="False" KeepTogether="False" Name="ListItemStyle" />
        <ParagraphStyle FontName="Calibri" FontSize="12" FontColor="#000000" Bold="False" Italic="False" TextAlignment="Left" Margins="0,6,0,0" FirstLineIndent="0" PageBreakBefore="False" KeepWithNextParagraph="False" KeepTogether="False" Name="ParagraphStyle" />
        <ParagraphCenterStyle FontName="Calibri" FontSize="12" FontColor="#000000" Bold="False" Italic="False" TextAlignment="Center" Margins="0,6,0,0" FirstLineIndent="0" PageBreakBefore="False" KeepWithNextParagraph="False" KeepTogether="False" Name="ParagraphCenterStyle" />
        <ParagraphJustifyStyle FontName="Calibri" FontSize="12" FontColor="#000000" Bold="False" Italic="False" TextAlignment="Justify" Margins="0,6,0,0" FirstLineIndent="0" PageBreakBefore="False" KeepWithNextParagraph="False" KeepTogether="False" Name="ParagraphJustifyStyle" />
        <ParagraphRightStyle FontName="Calibri" FontSize="12" FontColor="#000000" Bold="False" Italic="False" TextAlignment="Right" Margins="0,6,0,0" FirstLineIndent="0" PageBreakBefore="False" KeepWithNextParagraph="False" KeepTogether="False" Name="ParagraphRightStyle" />
        <RowStyle Name="RowStyle" />
        <SectionSubtitleStyle FontName="Calibri" FontSize="14" FontColor="#000000" Bold="True" Italic="False" TextAlignment="Center" Margins="0,24,0,0" FirstLineIndent="0" PageBreakBefore="False" KeepWithNextParagraph="False" KeepTogether="False" Name="SectionSubtitleStyle" />
        <SectionTitleStyle FontName="Calibri" FontSize="16" FontColor="#000000" Bold="True" Italic="False" TextAlignment="Center" Margins="0,48,0,0" FirstLineIndent="0" PageBreakBefore="False" KeepWithNextParagraph="False" KeepTogether="False" Name="SectionTitleStyle" />
        <SubtitleStyle FontName="Calibri" FontSize="16" FontColor="#000000" Bold="True" Italic="False" TextAlignment="Center" Margins="0,24,0,0" FirstLineIndent="0" PageBreakBefore="False" KeepWithNextParagraph="False" KeepTogether="False" Name="SubtitleStyle" />
        <TableStyle Margins="0,12,0,0" BorderSpacing="2" Name="TableStyle" />
        <TableHeaderLeftStyle FontName="Calibri" FontSize="12" FontColor="#000000" Bold="True" Italic="False" TextAlignment="Left" Margins="0,6,0,0" BorderThickness="1,1,1,1" Paddings="2,2,2,2" FirstLineIndent="0" PageBreakBefore="False" KeepWithNextParagraph="False" KeepTogether="False" Name="TableHeaderLeftStyle" >
            <BorderBrush>
                <SolidColorBrush Color="#000000"/>
            </BorderBrush>
        </TableHeaderLeftStyle>
        <TableHeaderCenterStyle FontName="Calibri" FontSize="12" FontColor="#000000" Bold="True" Italic="False" TextAlignment="Center" Margins="0,6,0,0" BorderThickness="1,1,1,1" Paddings="2,2,2,2" FirstLineIndent="0" PageBreakBefore="False" KeepWithNextParagraph="False" KeepTogether="False" Name="TableHeaderCenterStyle" >
            <BorderBrush>
                <SolidColorBrush Color="#000000"/>
            </BorderBrush>
        </TableHeaderCenterStyle>
        <TableHeaderRightStyle FontName="Calibri" FontSize="12" FontColor="#000000" Bold="True" Italic="False" TextAlignment="Right" Margins="0,6,0,0" BorderThickness="1,1,1,1" Paddings="2,2,2,2" FirstLineIndent="0" PageBreakBefore="False" KeepWithNextParagraph="False" KeepTogether="False" Name="TableHeaderRightStyle" >
            <BorderBrush>
                <SolidColorBrush Color="#000000"/>
            </BorderBrush>
        </TableHeaderRightStyle>
        <TableLegendStyle FontName="Calibri" FontSize="12" FontColor="#000000" Bold="False" Italic="True" TextAlignment="Center" Margins="0,3,0,12" FirstLineIndent="0" PageBreakBefore="False" KeepWithNextParagraph="False" KeepTogether="False" Name="TableLegendStyle" />
        <TitleStyle FontName="Calibri" FontSize="20" FontColor="#000000" Bold="True" Italic="False" TextAlignment="Center" Margins="0,48,0,24" FirstLineIndent="0" PageBreakBefore="False" KeepWithNextParagraph="False" KeepTogether="False" Name="TitleStyle" />
        <Toc1Style FontName="Calibri" FontSize="12" FontColor="#000000" Bold="True" Italic="False" TextAlignment="Left" Margins="0,6,0,0" FirstLineIndent="0" PageBreakBefore="False" KeepWithNextParagraph="False" KeepTogether="False" Name="Toc1Style" />
        <Toc2Style FontName="Calibri" FontSize="12" FontColor="#000000" Bold="False" Italic="False" TextAlignment="Left" Margins="12,6,0,0" FirstLineIndent="0" PageBreakBefore="False" KeepWithNextParagraph="False" KeepTogether="False" Name="Toc2Style" />
        <Toc3Style FontName="Calibri" FontSize="12" FontColor="#000000" Bold="False" Italic="False" TextAlignment="Left" Margins="24,6,0,0" FirstLineIndent="0" PageBreakBefore="False" KeepWithNextParagraph="False" KeepTogether="False" Name="Toc3Style" />
        <Toc4Style FontName="Calibri" FontSize="12" FontColor="#000000" Bold="False" Italic="False" TextAlignment="Left" Margins="36,6,0,0" FirstLineIndent="0" PageBreakBefore="False" KeepWithNextParagraph="False" KeepTogether="False" Name="Toc4Style" />
        <Toc5Style FontName="Calibri" FontSize="12" FontColor="#000000" Bold="False" Italic="False" TextAlignment="Left" Margins="48,6,0,0" FirstLineIndent="0" PageBreakBefore="False" KeepWithNextParagraph="False" KeepTogether="False" Name="Toc5Style" />
        <ToeStyle FontName="Calibri" FontSize="10" FontColor="#000000" Bold="False" Italic="False" TextAlignment="Left" Margins="0,6,0,0" FirstLineIndent="0" PageBreakBefore="False" KeepWithNextParagraph="False" KeepTogether="False" Name="ToeStyle" />
        <TofStyle FontName="Calibri" FontSize="10" FontColor="#000000" Bold="False" Italic="False" TextAlignment="Left" Margins="0,6,0,0" FirstLineIndent="0" PageBreakBefore="False" KeepWithNextParagraph="False" KeepTogether="False" Name="TofStyle" />
        <TotStyle FontName="Calibri" FontSize="10" FontColor="#000000" Bold="False" Italic="False" TextAlignment="Left" Margins="0,6,0,0" FirstLineIndent="0" PageBreakBefore="False" KeepWithNextParagraph="False" KeepTogether="False" Name="TotStyle" />
        <TocHeadingStyle FontName="Calibri" FontSize="14" FontColor="#000000" Bold="True" Italic="False" TextAlignment="Left" Margins="0,48,0,12" BorderThickness="0,2,0,2" Paddings="0,6,0,6" FirstLineIndent="0" PageBreakBefore="False" KeepWithNextParagraph="False" KeepTogether="False" Name="TocHeadingStyle" >
            <BorderBrush>
                <SolidColorBrush Color="#000000"/>
            </BorderBrush>
        </TocHeadingStyle>
        <TofHeadingStyle FontName="Calibri" FontSize="14" FontColor="#000000" Bold="True" Italic="False" TextAlignment="Left" Margins="0,48,0,12" BorderThickness="0,2,0,2" Paddings="0,6,0,6" FirstLineIndent="0" PageBreakBefore="False" KeepWithNextParagraph="False" KeepTogether="False" Name="TofHeadingStyle" >
            <BorderBrush>
                <SolidColorBrush Color="#000000"/>
            </BorderBrush>
        </TofHeadingStyle>
        <ToeHeadingStyle FontName="Calibri" FontSize="14" FontColor="#000000" Bold="True" Italic="False" TextAlignment="Left" Margins="0,48,0,12" BorderThickness="0,2,0,2" Paddings="0,6,0,6" FirstLineIndent="0" PageBreakBefore="False" KeepWithNextParagraph="False" KeepTogether="False" Name="ToeHeadingStyle" >
            <BorderBrush>
                <SolidColorBrush Color="#000000"/>
            </BorderBrush>
        </ToeHeadingStyle>
        <TotHeadingStyle FontName="Calibri" FontSize="14" FontColor="#000000" Bold="True" Italic="False" TextAlignment="Left" Margins="0,48,0,12" BorderThickness="0,2,0,2" Paddings="0,6,0,6" FirstLineIndent="0" PageBreakBefore="False" KeepWithNextParagraph="False" KeepTogether="False" Name="TotHeadingStyle" >
            <BorderBrush>
                <SolidColorBrush Color="#000000"/>
            </BorderBrush>
        </TotHeadingStyle>
        <WarningStyle FontName="Calibri" FontSize="12" FontColor="#000000" Bold="False" Italic="False" TextAlignment="Left" Margins="0,18,0,18" BorderThickness="1,1,1,1" Paddings="6,6,6,6" FirstLineIndent="0" PageBreakBefore="False" KeepWithNextParagraph="False" KeepTogether="True" Name="WarningStyle" >
            <BorderBrush>
                <SolidColorBrush Color="#FFFF00"/>
            </BorderBrush>
        </WarningStyle>
    </Styleset>
    <DocumentMetaData Authors="Robert Leisner" Company="Bodoconsult GmbH" CompanyWebsite="http://www.bodoconsult.de" Title="Title of the document" Description="Blubb blabb bleeb" Keywords="Blubb, blabb, bleeb" TocHeading="Table of content" TofHeading="Table of figures" ToeHeading="Table of equations" TotHeading="Table of tables" PageNumberPrefix="Page" EquationPrefix="Equation" CitationSourcePrefix="Source: " TablePrefix="Table" FigurePrefix="Figure" IsTocRequired="True" IsFiguresTableRequired="True" IsEquationsTableRequired="True" IsTablesTableRequired="True" FooterText="Bodoconsult GmbH	<<page>>" HeaderText="HeaderText" AlternateBackColor="#FFFFFF" BackColor="#B0C4DE" TableBorderColor="#A9A9A9" />
    <TocSection InheritFromParent="True" IncludeInToc="False" PageBreakBefore="True" DoNotIncludeInNumbering="True" IsHeaderRequired="True" IsFooterRequired="True" IsRestartPageNumberingRequired="False" PageNumberFormat="UpperRoman">
    </TocSection>
    <TofSection InheritFromParent="True" IncludeInToc="False" PageBreakBefore="True" DoNotIncludeInNumbering="True" IsHeaderRequired="True" IsFooterRequired="True" IsRestartPageNumberingRequired="False" PageNumberFormat="UpperRoman">
    </TofSection>
    <TotSection InheritFromParent="True" IncludeInToc="False" PageBreakBefore="True" DoNotIncludeInNumbering="True" IsHeaderRequired="True" IsFooterRequired="True" IsRestartPageNumberingRequired="False" PageNumberFormat="UpperRoman">
    </TotSection>
    <ToeSection InheritFromParent="True" IncludeInToc="False" PageBreakBefore="True" DoNotIncludeInNumbering="True" IsHeaderRequired="True" IsFooterRequired="True" IsRestartPageNumberingRequired="False" PageNumberFormat="UpperRoman">
    </ToeSection>
    <Section InheritFromParent="True" IncludeInToc="True" PageBreakBefore="True" DoNotIncludeInNumbering="False" IsHeaderRequired="True" IsFooterRequired="True" IsRestartPageNumberingRequired="True" PageNumberFormat="Decimal" Name="Body">
        <Title>
            <Span>Title</Span>
        </Title>
        <Subtitle>
            <Span>Subtitle</Span>
        </Subtitle>
        <SectionTitle>
            <Span>SectionTitle</Span>
        </SectionTitle>
        <SectionSubtitle>
            <Span>SectionSubtitle</Span>
        </SectionSubtitle>
        <Heading1>
            <Span>1. Heading level 1</Span>
        </Heading1>
        <Heading2>
            <Span>1.1. Heading level 2</Span>
        </Heading2>
        <Heading3>
            <Span>1.1.1. Heading level 3</Span>
        </Heading3>
        <Heading4>
            <Span>1.1.1.1. Heading level 4</Span>
        </Heading4>
        <Heading5>
            <Span>1.1.1.1.1. Heading level 5</Span>
        </Heading5>
        <Paragraph>
            <Span>Paragraph: Lorem ipsum dolor ≥ = &gt; &#61; sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.</Span>
        </Paragraph>
        <ParagraphCenter>
            <Span>ParagraphCentral: Lorem ipsum dolor ≥ = &gt; &#61; sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.</Span>
        </ParagraphCenter>
        <ParagraphRight>
            <Span>ParagraphRight: Lorem ipsum dolor ≥ = &gt; &#61; sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.</Span>
        </ParagraphRight>
        <ParagraphJustify>
            <Span>ParagraphJustify: Lorem ipsum dolor ≥ = &gt; &#61; sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.</Span>
        </ParagraphJustify>
        <Heading1>
            <Span>2. Heading level 1</Span>
        </Heading1>
        <Heading2>
            <Span>2.1. Heading level 2</Span>
        </Heading2>
        <Heading3>
            <Span>2.1.1. Heading level 3</Span>
        </Heading3>
        <Heading4>
            <Span>2.1.1.1. Heading level 4</Span>
        </Heading4>
        <Heading5>
            <Span>2.1.1.1.1. Heading level 5</Span>
        </Heading5>
        <Paragraph>
            <Span>Paragraph with LineBreak and Bold and BoldItalic:</Span>
            <Span>Lorem ipsum dolor ≥ = &gt; &#61; sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.</Span>
            <LineBreak/>
            <Bold>Lorem ipsum dolor ≥ = &gt; &#61; sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.</Bold>
        </Paragraph>
        <Paragraph>
            <Italic>
                <Bold>Lorem ipsum dolor ≥ = &gt; &#61; sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.</Bold>
            </Italic>
        </Paragraph>
        <Citation Source="Fjodor Dostojewski">
            <Span>Citation: Geld ist geprägte Freiheit</Span>
        </Citation>
        <Code>
            <Span>Code: Lorem ipsum dolor ≥ = &gt; &#61; sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.</Span>
        </Code>
        <Info>
            <Span>Info: Lorem ipsum dolor ≥ = &gt; &#61; sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.</Span>
        </Info>
        <Paragraph>
            <Span>Lorem ipsum dolor ≥ = &gt; &#61; sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.</Span>
        </Paragraph>
        <Warning>
            <Span>Warning: Lorem ipsum dolor ≥ = &gt; &#61; sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.</Span>
        </Warning>
        <Paragraph>
            <Span>Lorem ipsum dolor ≥ = &gt; &#61; sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.</Span>
        </Paragraph>
        <Error>
            <Span>Error: Lorem ipsum dolor ≥ = &gt; &#61; sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.</Span>
        </Error>
        <Paragraph>
            <Span>ParagraphWithHyperlink: this is a link:</Span>
            <Hyperlink Uri="http://www.bodoconsult.de">Link to blubb</Hyperlink>
        </Paragraph>
        <Image Uri="C:\Daten\Projekte\Tools\Bodoconsult.AppInfrastructure\tests\Bodoconsult.Text.Test\TestData\chart3d.png" OriginalWidth="1725" OriginalHeight="1075">
            <Span>Test image</Span>
        </Image>
        <Figure Uri="C:\Daten\Projekte\Tools\Bodoconsult.AppInfrastructure\tests\Bodoconsult.Text.Test\TestData\chart3d.png" OriginalWidth="1725" OriginalHeight="1075">
            <Span>Figure 1</Span>
        </Figure>
        <Figure Uri="C:\Daten\Projekte\Tools\Bodoconsult.AppInfrastructure\tests\Bodoconsult.Text.Test\TestData\NormalDistribution.de.png" OriginalWidth="1725" OriginalHeight="1075">
            <Span>Figure 2</Span>
        </Figure>
        <Equation Uri="C:\Daten\Projekte\Tools\Bodoconsult.AppInfrastructure\tests\Bodoconsult.Text.Test\TestData\equation.png" OriginalWidth="300" OriginalHeight="100">
            <Span>Equation 1</Span>
        </Equation>
        <Equation Uri="C:\Daten\Projekte\Tools\Bodoconsult.AppInfrastructure\tests\Bodoconsult.Text.Test\TestData\equation.png" OriginalWidth="300" OriginalHeight="100">
            <Span>Equation 2</Span>
        </Equation>
        <List ListStyleType="Disc" ListStyleTypeChar=" " Counter="0">
            <ListItem>
                <Span>First list item: Lorem ipsum dolor ≥ = &gt; &#61; sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.</Span>
            </ListItem>
            <ListItem>
                <Span>Second list item: Lorem ipsum dolor ≥ = &gt; &#61; sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.</Span>
            </ListItem>
        </List>
        <Paragraph>
            <Span>Lorem ipsum dolor ≥ = &gt; &#61; sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.</Span>
        </Paragraph>
        <Table>
            <Column Name="ShareId" DataType="System.Int32" Format="#,##0"/>
            <Column Name="ShareName" DataType="System.String"/>
            <Column Name="WKN" DataType="System.String"/>
            <Column Name="ISIN" DataType="System.String"/>
            <Column Name="Domestic" DataType="System.Boolean"/>
            <Row>
                <Cell>
                    <Value>1</Value>
                </Cell>
                <Cell>
                    <Value>Testfirma AG</Value>
                </Cell>
                <Cell>
                    <Value>900900</Value>
                </Cell>
                <Cell>
                    <Value>DE123456789</Value>
                </Cell>
                <Cell>
                    <Value>True</Value>
                </Cell>
            </Row>
            <Row>
                <Cell>
                    <Value>2</Value>
                </Cell>
                <Cell>
                    <Value>Blubb AG</Value>
                </Cell>
                <Cell>
                    <Value>123456</Value>
                </Cell>
                <Cell>
                    <Value>AT123456789</Value>
                </Cell>
                <Cell>
                    <Value>False</Value>
                </Cell>
            </Row>
            <Row>
                <Cell>
                    <Value>3</Value>
                </Cell>
                <Cell>
                    <Value>Blabb AG</Value>
                </Cell>
                <Cell>
                    <Value>234567</Value>
                </Cell>
                <Cell>
                    <Value>GB123456789</Value>
                </Cell>
                <Cell>
                    <Value>False</Value>
                </Cell>
            </Row>
            <Row>
                <Cell>
                    <Value>4</Value>
                </Cell>
                <Cell>
                    <Value>Lustig AG</Value>
                </Cell>
                <Cell>
                    <Value>345678</Value>
                </Cell>
                <Cell>
                    <Value>DE234567891</Value>
                </Cell>
                <Cell>
                    <Value>True</Value>
                </Cell>
            </Row>
            <Row>
                <Cell>
                    <Value>5</Value>
                </Cell>
                <Cell>
                    <Value>Unsinn AG</Value>
                </Cell>
                <Cell>
                    <Value>456789</Value>
                </Cell>
                <Cell>
                    <Value>DE345678912</Value>
                </Cell>
                <Cell>
                    <Value>True</Value>
                </Cell>
            </Row>
            <Span>Portfolio</Span>
        </Table>
        <Paragraph>
            <Span>Lorem ipsum dolor ≥ = &gt; &#61; sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.</Span>
        </Paragraph>
        <DefinitionList>
            <DefinitionListTerm>
                <DefinitionListItem>
                    <Span>Blubb</Span>
                </DefinitionListItem>
                <DefinitionListItem>
                    <Span>Blabb</Span>
                </DefinitionListItem>
                <Span>Share</Span>
            </DefinitionListTerm>
            <DefinitionListTerm>
                <DefinitionListItem>
                    <Span>Lorem ipsum dolor ≥ = &gt; &#61; sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.</Span>
                </DefinitionListItem>
                <Span>Fixed income</Span>
            </DefinitionListTerm>
            <DefinitionListTerm>
                <DefinitionListItem>
                    <Span>Lorem ipsum dolor ≥ = &gt; &#61; sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.</Span>
                </DefinitionListItem>
                <DefinitionListItem>
                    <Span>Lorem ipsum dolor ≥ = &gt; &#61; sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.</Span>
                </DefinitionListItem>
                <Span>Real estate</Span>
            </DefinitionListTerm>
        </DefinitionList>
        <Paragraph>
            <Span>Lorem ipsum dolor ≥ = &gt; &#61; sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.</Span>
        </Paragraph>
    </Section>
</Document>
```

``` xml

```


## Block elements

Block elements can be serialized with its ToLdmlString() method. For deserialization use LdmlReader class.

### General document structure

-   **Document**: The root tag of a document

-   **DocumentMetaData**: Tag for general document meta data

-   **Styleset**: The styleset of a document

-   **Section**: A section of a document. A document must have at least one section

-   **TocSection**: A section to be used to calculate a table of content (TOC)

-   **TofSection**: A section to be used to calculate a table of figures (TOF)

-   **ToeSection**: A section to be used to calculate a table of equations (TOE)

-   **TotSection**: A section to be used to calculate a table of tables (TOT)

### Content of the sections

-   **Paragraph**: A paragraph with left aligned text

-   **ParagraphRight**: A paragraph with right aligned text

-   **ParagraphCenter**: A paragraph with centered text

-   **ParagraphJustify**: A paragraph with justified text

-   **Heading1**: A heading on level 1 (to be counted and added to a table of content (TOC))

-   **Heading2**: A heading on level 2 (to be counted and added to a table of content (TOC))

-   **Heading3**: A heading on level 3 (to be counted and added to a table of content (TOC))

-   **Heading4**: A heading on level 4 (to be counted and added to a table of content (TOC))

-   **Heading5**: A heading on level 5 (to be counted and added to a table of content (TOC))

-   **Paragraph**: A paragraph with text

-   **Paragraph**: A paragraph with text

-   **Paragraph**: A paragraph with text

-   **Image**: A simple image without counting

-   **Figure**: A simple image with counting (to be counted and added to a table of figures (TOF))

-   **Equation**: A simple image with counting (to be counted and added to a table of equations (TOE))

-   **Citation**: A paragraph with a citation

-   **Info**: A paragraph with an info

-   **Warning**: A paragraph with a warning

-   **Error**: A paragraph with an error message

-   **Table**: Add a table to the document (to be counted and added to a table of tables (TOT))

## Inline elements

-   **Span**: Simple text

-   **Bold**: Bold text

-   **Italic**: Simple text

-   **Hyperlink**: Hyperlink

-

# Document object model (DOM) for LDML



# Future enhancements

## More renderers

Additional renderers for RTF, OpenXml DOCX, LaTex var planned.
