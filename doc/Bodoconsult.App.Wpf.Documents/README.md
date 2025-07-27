Bodoconsult.App.Wpf.Documents
================

## What does the library

Bodoconsult.App.Wpf.Documents is a library with basic functionality for creating repots based on WPF FlowDocument targeting XPS or PDF export. 


## WPF app start infrastructure basics

See page [WPF app start infrastructure](../Bodoconsult.App.Wpf/README.md) for details.

## Using FlowDocumentService class to create and export WPF FlowDocuments to PDF (or XPS)

With FlowDoumentService it is easy to create WPF FlowDocuments and show them on the screen or export them to PDF or XPS.
The layout of the output should follow to a minimum of typographic rules at least.

``` csharp
public void SaveAsPdf_Demo_FileIsCreated()
{
    // Arrange
    var fileName = Path.Combine(_tempPath, "Demo.pdf");

    if (File.Exists(fileName))
    {
        File.Delete(fileName);
    }

    // Act

    // Define a typography
    var typo = new ElegantTypographyPageHeader("Times New Roman", "Times New Roman", "Arial Black");
    
    // Get the typo service needed
    var typoService = new TypographySettingsService(typo)
    {
        MaxImageHeight = 300,
        LogoPath = _logoPath,
        FooterText = "Bodoconsult GmbH",
        FigureCounterPrefix = "Abb.",
        ShowFigureCounter = true
    };

    // Now get the flow document service with the document contained
    var fds = new FlowDocumentService(typoService);

    // Fill the document now
    fds.AddSection();
    fds.AddTitle("Title for this test document");
    fds.AddTitle2("Subtitle for this test document");

    // Simple paragraphs
    fds.AddParagraph(FlowDocHelper.MassText);
    fds.AddParagraphCentered(FlowDocHelper.MassText);
    fds.AddParagraphRight(FlowDocHelper.MassText);

    // Paragraphs with tags in the content
    fds.AddParagraph(FlowDocHelper.MassTextTags);

    // Add XAML markup
    fds.AddHeader1("Add Textblock");
    fds.AddHeader2("From XAML markup");
    fds.AddXamlTextblock($"<Paragraph>{FlowDocHelper.MassTextTags}</Paragraph><Paragraph>Test test test</Paragraph>");

    // Add HTML markup
    fds.AddHeader2("From HTML markup");
    fds.AddTextBlock($"<H2>Heading 2 A</H2><P>{FlowDocHelper.MassTextTags}</P><H2>Heading 2 B</H2><P>Test test test</P>");

    // Add a table
    fds.AddHeader1("Add table");
    fds.AddTable(FlowDocHelper.GetTableData(24, 3));

    // Add a figure
    fds.AddHeader1("Add a figure");

    fds.AddHeader2("Add a figure from file");
    fds.AddFigure(TestHelper.TestChartImage, "Image title", 300, 200);

    fds.AddHeader2("Add a figure from XAML file");
    fds.AddFigure(_chartXamlPath, 300, 200, "Canvas as figure from file");

    // Add an image
    fds.AddHeader1("Add an image");
    fds.AddHeader2("Add an image from a file");
    fds.AddImage(TestHelper.TestChartImage);

    fds.AddHeader2("Add an image from resources");
    fds.AddImage(@"Resources\testimage.png");

    // Add a default header and footer to the document
    fds.AddDefaultFooterAndHeader();

    // Save as PDF
    fds.SaveAsPdf(fileName);

    // Assert
    Assert.That(File.Exists(fileName));

    FileSystemHelper.RunInDebugMode(fileName);
}
```

## Using ReportBase class to create and export reports to PDF (or XPS)

With ReportBase class you can create simply reports with text, tables, lists and charts to be exported to PDF and XPS. It is based on FlowDocumentService class.

The ReportBase class is intended to be a base class for customized reports.

``` csharp
[Test]
public void TestReportBase_Demo_FileCreated()
{
    //Arrange
    const string contentFile = @"pack://siteOfOrigin:,,,/Resources/Content/SimulationMethodDescription.txt";
    
    var fileName = Path.Combine(_tempPath, "TestReportBase_Demo.pdf");

    // Define a typography
    var typo = new ElegantTypographyPageHeader("Times New Roman", "Times New Roman", "Arial Black");

    // Get the typo service needed
    var typoService = new TypographySettingsService(typo)
    {
        MaxImageHeight = 300,
        LogoPath = TestHelper.TestLogoImage,
        FooterText = "Bodoconsult GmbH",
        FigureCounterPrefix = "Abb.",
        ShowFigureCounter = true,
        CurrentLanguage = "de"
    };

    // Act

    // Create the base report
    var r = new ReportBase(typoService, _i18N);

    // Add a translated title and subtitle
    r.AddTitle("Resx:Simulation.Wpf.ReportTitle");
    r.AddTitle2("I18N:Simulation.Wpf.ReportTitle");

    // Add paragraphs
    r.AddHeader("Add a paragraph", 1);
    r.AddHeader("", 2);
    r.AddParagraph(FlowDocHelper.MassText);
    r.AddHeader("Add a paragraph", 2);
    r.AddParagraph(FlowDocHelper.MassTextTags);

    // Add a numbered List
    r.AddHeader("Add a numbered list", 1);
    r.AddNumberedList(FlowDocHelper.GetListData(), TextMarkerStyle.Disc);

    // Add a  table
    r.AddHeader("Add a table", 1);
    r.AddTable(FlowDocHelper.GetTableDataNumeric(5, 5));

    // Add a text block
    r.AddHeader("Add XAML textblock", 1);
    r.AddHeader("From paragraph", 2);
    r.AddXamlTextblock($"<Paragraph>{FlowDocHelper.MassTextTags}</Paragraph><Paragraph>Test test test</Paragraph>", "StandardWithIndent");

    r.AddHeader("From FlowDocument", 2);
    r.AddXamlTextblock(string.Format("<FlowDocument><Paragraph>{0}</Paragraph><Paragraph>{0}</Paragraph></FlowDocument>", FlowDocHelper.MassTextTags), "StandardWithIndent");

    // Add an image
    r.AddHeader("Add an image", 2);
    r.AddParagraph(FlowDocHelper.MassText);
    r.AddImage(@"Resources\testimage.png");
    r.AddParagraph(FlowDocHelper.MassText);

    // Add a pagebreak
    r.AddPageBreak();

    // Add a figure
    r.AddHeader("Add a figure", 2);
    r.AddParagraph(FlowDocHelper.MassText);
    r.AddFigure(@"Resources\testimage.png", "Image title1212");
    r.AddParagraph(FlowDocHelper.MassText);

    // Now build the report
    r.BuildReport();

    // Now save the report as PDF
    r.SaveAsPdf(fileName);

    //Assert
    Assert.That(File.Exists(fileName));
    FileSystemHelper.RunInDebugMode(fileName);
}
```

# About us

Bodoconsult <http://www.bodoconsult.de> is a Munich based software company from Germany.

Robert Leisner is senior software developer at Bodoconsult. See his profile on <http://www.bodoconsult.de/Curriculum_vitae_Robert_Leisner.pdf>.

