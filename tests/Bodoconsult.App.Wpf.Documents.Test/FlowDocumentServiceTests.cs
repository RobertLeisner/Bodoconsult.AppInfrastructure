// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Bodoconsult.App.Helpers;
using Bodoconsult.App.Wpf.Documents.General;
using Bodoconsult.App.Wpf.Documents.Services;
using Bodoconsult.App.Wpf.Documents.Test.Helpers;
using Bodoconsult.App.Wpf.Helpers;
using Bodoconsult.Typography;
using Microsoft.Diagnostics.Tracing.Parsers.MicrosoftAntimalwareAMFilter;
using NUnit.Framework;

namespace Bodoconsult.App.Wpf.Documents.Test
{
    [TestFixture]
    [RequiresThread(ApartmentState.STA)]
    public class FlowDocumentServiceTests
    {
        private readonly string _tempPath = Path.GetTempPath();

        private readonly string _testDataPath = TestHelper.TestDataPath;

        private static string _chartXamlPath;

        private readonly string _logoPath = TestHelper.TestLogoImage;

        public FlowDocumentServiceTests()
        {
            var fi = new FileInfo(Assembly.GetExecutingAssembly().Location);


            _chartXamlPath = Path.Combine(_testDataPath, "3DChart.xaml");

        }




        [Test]
        public void SaveAsXps_NormalDocument_FileIsCreated()
        {

            // Arrange
            var fileName = Path.Combine(_tempPath, "FlowDocService1.xps");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            // Act
            var fds = GetFlowDocumentService();

            //var stream = File.OpenRead(@"c:\temp\charts3d.jpg");
            //fds.AddImage(stream);
            //stream.Close();

            fds.SaveAsXps(fileName);

            // Assert
            Assert.That(File.Exists(fileName));

            FileSystemHelper.RunInDebugMode(fileName);
        }


        [Test]
        public void SaveAsXps_DocumentFromTypography_FileIsCreated()
        {

            // Arrange
            var fileName = Path.Combine(_tempPath, "FlowDocService2.xps");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }


            // Act
            var fds = GetFlowDocumentServiceWithTypography();

            //var stream = File.OpenRead(@"c:\temp\charts3d.jpg");
            //fds.AddImage(stream);
            //stream.Close();

            fds.SaveAsXps(fileName);

            // Assert
            Assert.That(File.Exists(fileName));

            FileSystemHelper.RunInDebugMode(fileName);
        }


        [Test]
        public void SaveAsXps_DocumentFromTypographyCompact_FileIsCreated()
        {

            // Arrange
            var fileName = Path.Combine(_tempPath, "FlowDocService2.xps");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            var typoService = new TypographySettingsService();
            typoService.LoadCompactDefaults();
            typoService.PrimaryFontName = "Times New Roman";
            typoService.SecondaryFontName = "Times New Roman";
            typoService.SecondaryFontName = "Arial Black";

            // Act
            var fds = GetFlowDocumentServiceWithCompactTypography(typoService);

            //var stream = File.OpenRead(@"c:\temp\charts3d.jpg");
            //fds.AddImage(stream);
            //stream.Close();

            fds.SaveAsXps(fileName);



            // Assert
            Assert.That(File.Exists(fileName));

            FileSystemHelper.RunInDebugMode(fileName);
        }


        private FlowDocumentService GetFlowDocumentService()
        {

            var typoService = new TypographySettingsService
            {
                MaxImageHeight = 300,
                LogoPath = _logoPath,
                FooterText = "Bodoconsult GmbH",
                FigureCounterPrefix = "Abb.",
                ShowFigureCounter = true,
                
            };


            var fds = new FlowDocumentService(typoService);
            GetReport(fds);

            return fds;
        }

        private static void GetReport(FlowDocumentService fds)
        {
            fds.AddSection();
            fds.AddTitle("Title for this test document");
            fds.AddTitle2("Subtitle for this test document");

            fds.AddHeader1("Add XAML Textblock");
            fds.AddHeader2("From paragraph");
            fds.AddXamlTextblock(
                $"<Paragraph>{FlowDocHelper.MassTextTags}</Paragraph><Paragraph>Test test test</Paragraph>");
            fds.AddHeader1("Add XAML Textblock");
            fds.AddHeader2("From paragraph");
            fds.AddXamlTextblock(
                $"<Paragraph>{FlowDocHelper.MassTextTags}</Paragraph><Paragraph>Test test test</Paragraph>");

            fds.AddTextBlock(
                $"<H2>Überschrift 2 A</H2><P>{FlowDocHelper.MassTextTags}</P><H2>Überschrift 2 B</H2><P>Test test test</P>");


            fds.AddHeader2("From flowdocument");
            fds.AddXamlTextblock(
                string.Format("<FlowDocument><Paragraph>{0}</Paragraph><Paragraph>{0}</Paragraph></FlowDocument>",
                    FlowDocHelper.MassTextTags));

            fds.AddTable(FlowDocHelper.GetTableData(24, 3));

            fds.AddHeader1("Canvas blubb Co; gjgj");
            //fds.AddRuler();

            fds.AddHeader2("Canvas from live object as figure");

            var canvas = (Canvas)WpfHelper.LoadElementFromXamlFile(_chartXamlPath);
            fds.AddFigure(canvas, 200, 200, "Canvas as figure from live object");

            fds.AddHeader2("Canvas from file");

            fds.AddCanvas(_chartXamlPath, 300,
                200);

            fds.AddHeader2("Canvas from live object");

            fds.Dispatcher.Invoke(() =>
            {
                canvas = (Canvas)WpfHelper.LoadElementFromXamlFile(_chartXamlPath);
            });



            fds.AddCanvas(canvas, 200, 200);

            fds.AddHeader2("Canvas from file as figure");

            fds.AddFigure(_chartXamlPath, 300,
                200, "Canvas as figure from file");


            //fds.AddHeader2("Image from stream");
            //var stream = File.OpenRead(@"c:\temp\charts3d.jpg");
            //fds.AddImage(stream);
            //stream.Close();

            fds.AddHeader2(FlowDocHelper.Header2);
            fds.AddParagraph(FlowDocHelper.MassText);

            fds.AddParagraph(FlowDocHelper.MassTextTags);

            // paragraph with images
            fds.AddParagraph(FlowDocHelper.MassTextWithImages);

            // Add a longer text block with paragraphs

            var textblock =
                $"<P>{FlowDocHelper.MassText}</P>{FlowDocHelper.ImageTag}<P>{FlowDocHelper.MassTextTags}</P>{FlowDocHelper.ImageTagWithTitle}<P>{FlowDocHelper.MassText}</P>";

            fds.AddParagraph("Test Textblock Start");
            fds.AddTextBlock(textblock);
            fds.AddParagraph("Test Textblock Ende");

            fds.AddNumberedList(FlowDocHelper.GetListData(), TextMarkerStyle.Disc);
            fds.AddParagraph(FlowDocHelper.MassTextTags);
            fds.AddTable(FlowDocHelper.GetTableData(4, 2));

            fds.AddPageBreak();
            fds.AddParagraph(FlowDocHelper.MassText);

            fds.AddImage(@"Resources\testimage.png");
            fds.AddHeader2(FlowDocHelper.Header2);
            fds.AddParagraph(FlowDocHelper.MassText);
            fds.AddTable(FlowDocHelper.GetTableData(10, 6), TableTypes.Small);
            fds.AddParagraph(FlowDocHelper.MassText);

            fds.AddPageBreak();
            fds.AddParagraph(FlowDocHelper.GetInlineSamples());
            fds.AddParagraph(FlowDocHelper.MassText);

            fds.AddHeader2(FlowDocHelper.Header2);
            fds.AddParagraph(FlowDocHelper.MassText);
            fds.AddTable(FlowDocHelper.GetTableData(10, 6), TableTypes.SmallUnbordered);
            fds.AddParagraph(FlowDocHelper.MassText);

            fds.AddHeader1(FlowDocHelper.Header1);
            //fds.AddRuler();
            fds.AddParagraph(FlowDocHelper.MassText);
            fds.AddFigure(@"Resources\testimage.png", "Quantum ipsum lorem delete");
            fds.AddParagraph(FlowDocHelper.MassText);
            fds.AddParagraph(FlowDocHelper.MassText);

            fds.AddParagraph("FigureCount: ??FigureCount??");
            fds.AddParagraph("FigureCountP1 (following figure): ??FigureCountP1??");
            fds.AddParagraph("FigureCountM1 (previous figure): ??FigureCountM1??");


            fds.AddTextBlock("FigureCount: ??FigureCount??");

            fds.AddDefaultFooterAndHeader();
        }


        private FlowDocumentService GetFlowDocumentServiceWithTypography()
        {

            var typo = new ElegantTypographyPageHeader("Times New Roman", "Times New Roman", "Arial Black");

            var typoService = new TypographySettingsService(typo)
            {
                MaxImageHeight = 300,
                LogoPath = _logoPath,
                FooterText = "Bodoconsult GmbH",
                FigureCounterPrefix = "Abb.",
                ShowFigureCounter = true
            };

            var fds = new FlowDocumentService(typoService);
            GetReport(fds);
            return fds;
        }


        private FlowDocumentService GetFlowDocumentServiceWithCompactTypography(
            TypographySettingsService typoService)
        {

            var typo = new CompactTypographyPageHeader("Times New Roman", "Times New Roman", "Arial Black");

            typoService.LoadTypography(typo);
            typoService.MaxImageHeight = 300;
            typoService.LogoPath = _logoPath;
            typoService.FooterText = "Bodoconsult GmbH";
            typoService.FigureCounterPrefix = "Abb.";
            typoService.ShowFigureCounter = true;

            var fds = new FlowDocumentService(typoService);
            GetReport(fds);
            return fds;
        }


        [CancelAfter(5000000)]
        [Test]
        public void SaveAsPdf_DocumentCompact_FileIsCreated()
        {

            // Arrange
            var fileName = Path.Combine(_tempPath, "FlowDocService2.pdf");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            // Act
            var fds = GetFlowDocumentService();

            fds.SaveAsPdf(fileName);


            // Assert
            Assert.That(File.Exists(fileName));

            FileSystemHelper.RunInDebugMode(fileName);
        }



        [Test]
        public void SaveAsPdfDocumentCompact_FileIsCreated()
        {

            // Arrange
            var fileName = Path.Combine(_tempPath, "FlowDocService2.pdf");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            // Act
            var fds = GetFlowDocumentService();
            fds.SaveAsPdf(fileName);

            // Assert
            Assert.That(File.Exists(fileName));

            FileSystemHelper.RunInDebugMode(fileName);
        }

        [CancelAfter(5000000)]
        [Test]
        public void SaveAsPdf_Demo_FileIsCreated()
        {

            // Arrange
            var fileName = Path.Combine(_tempPath, "Documentation.pdf");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            // Act
            var fds = GetFlowDocumentService();

            fds.SaveAsPdf(fileName);


            // Assert
            Assert.That(File.Exists(fileName));

            FileSystemHelper.RunInDebugMode(fileName);
        }
    }
}
