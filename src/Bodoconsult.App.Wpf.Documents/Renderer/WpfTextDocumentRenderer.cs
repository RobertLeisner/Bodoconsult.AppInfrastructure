// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Wpf.Documents.Interfaces;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;
using Bodoconsult.Text.Renderer;
using System.IO;
using System.IO.Packaging;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Threading;
using System.Windows.Xps.Packaging;
using System.Windows.Xps.Serialization;

namespace Bodoconsult.App.Wpf.Documents.Renderer;

/// <summary>
/// Render a <see cref="Document"/> to a PDF file
/// </summary>
public class WpfTextDocumentRenderer : BaseDocumentRenderer
{
    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="document">Document to render</param>
    /// <param name="textRendererElementFactory">Current factory for text renderer elements</param>
    public WpfTextDocumentRenderer(Document document, ITextRendererElementFactory textRendererElementFactory) : base(document)
    {
        var metaData = document.DocumentMetaData;

        WpfTextRendererElementFactory = (IWpfTextRendererElementFactory)textRendererElementFactory;

        Dispatcher = Application.Current.Dispatcher;
        Dispatcher.Invoke(() =>
        {
            WpfDocument = new FlowDocument();
        });
    }

    /// <summary>
    /// Current dispatcher
    /// </summary>
    public Dispatcher Dispatcher { get; private set; }

    /// <summary>
    /// The current PDF document
    /// </summary>
    public FlowDocument WpfDocument { get; private set; }

    /// <summary>
    /// Current document section for adding content
    /// </summary>
    public System.Windows.Documents.Section CurrentSection { get; set; }

    /// <summary>
    /// Current styleset
    /// </summary>
    public ResourceDictionary StyleSet { get; } = new();

    /// <summary>
    /// Current text renderer element factory
    /// </summary>
    public IWpfTextRendererElementFactory WpfTextRendererElementFactory { get; protected set; }

    /// <summary>
    /// Render the document
    /// </summary>
    public override void RenderIt()
    {
        var rendererElement = WpfTextRendererElementFactory.CreateInstanceWpf(Document);
        rendererElement.RenderIt(this);
    }

    /// <summary>
    /// Save the rendered document as file
    /// </summary>
    /// <param name="fileName">Full file path. Existing file will be overwritten</param>
    public override void SaveAsFile(string fileName)
    {
        Dispatcher.Invoke(() =>
        {
            var lMemoryStream = new MemoryStream();
            using (var container = Package.Open(lMemoryStream, FileMode.Create))
            {
                using (var xpsDoc = new XpsDocument(container, CompressionOption.Maximum))
                {
                    var rsm = new XpsSerializationManager(new XpsPackagingPolicy(xpsDoc), false);

                    //var definition = new PrintDefinition();

                    //if (PageFooter != null)
                    //{
                    //    definition.FooterHeight = FooterHeight;
                    //    definition.Footer += PageFooter;
                    //}
                    //if (PageHeader != null)
                    //{
                    //    definition.HeaderHeight = HeaderHeight;
                    //    definition.Header += PageHeader;
                    //}

                    //if (PageFooter != null) definition.Header += PageHeader;


                    //rsm.SaveAsXaml(new HeaderFooterPaginator(WpfDocument, TypographySettingsService, Dispatcher));

                    rsm.SaveAsXaml(((IDocumentPaginatorSource) WpfDocument).DocumentPaginator);
                    rsm.Commit();
                }
            }

            var pdfXpsDoc = PdfSharp.Xps.XpsModel.XpsDocument.Open(lMemoryStream);
            PdfSharp.Xps.XpsConverter.Convert(pdfXpsDoc, fileName, 0);
        });
    }
}