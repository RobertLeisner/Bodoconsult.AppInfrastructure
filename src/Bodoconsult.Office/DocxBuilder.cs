// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Abstractions.Helpers;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using A = DocumentFormat.OpenXml.Drawing;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;
using Paragraph = DocumentFormat.OpenXml.Wordprocessing.Paragraph;
using ParagraphProperties = DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties;
using Run = DocumentFormat.OpenXml.Wordprocessing.Run;
using Text = DocumentFormat.OpenXml.Wordprocessing.Text;
using Style = DocumentFormat.OpenXml.Wordprocessing.Style;


namespace Bodoconsult.Office;

/// <summary>
/// Create OpenXML DOCX files
/// </summary>
public class DocxBuilder: IDisposable
{
    private int _imageCounter = -1;

    /// <summary>
    /// DOCX document
    /// </summary>
    public WordprocessingDocument docx { get; private set; }

    /// <summary>
    /// Main part of the document
    /// </summary>
    public MainDocumentPart mainDocumentPart { get; private set; }

    /// <summary>
    /// Style definition part
    /// </summary>
    public StyleDefinitionsPart StyleDefinitionsPart { get; private set; }

    /// <summary>
    /// Current styles in the document
    /// </summary>
    public Styles Styles { get; private set; }

    /// <summary>
    /// Body of the document
    /// </summary>
    public Body body { get; private set; }




    /// <summary>
    /// Create document in memory
    /// </summary>
    /// <param name="filePath">Full file path to save the document in</param>
    public void CreateDocument(string filePath)
    {
        docx = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document);
        LoadBaseData();
    }


    private void LoadBaseData()
    {
        // Assign a reference to the existing document body.
        mainDocumentPart = docx.MainDocumentPart ?? docx.AddMainDocumentPart();
        mainDocumentPart.Document ??= new Document();
        mainDocumentPart.Document.Body ??= mainDocumentPart.Document.AppendChild(new Body());
        body = docx.MainDocumentPart!.Document!.Body!;

        StyleDefinitionsPart = docx.MainDocumentPart.StyleDefinitionsPart ?? AddStylesPartToPackage();
        Styles = StyleDefinitionsPart?.Styles;
    }

    // Add a StylesDefinitionsPart to the document.  Returns a reference to it.
    private StyleDefinitionsPart AddStylesPartToPackage()
    {
        if (mainDocumentPart is null)
        {
            throw new ArgumentNullException(nameof(MainDocumentPart));
        }

        var part = mainDocumentPart.AddNewPart<StyleDefinitionsPart>();

        part.Styles = new Styles();

        Styles = part.Styles;

        //Styles.DocDefaults = new DocDefaults()
        //{
        //    ParagraphPropertiesDefault = 
        //};

        return part;
    }

    // .
    
    
    /// <summary>
    /// Create a new style with the specified styleid and stylename
    /// </summary>
    /// <param name="styleid"></param>
    /// <param name="stylename"></param>
    /// <param name="styleRunProperties"></param>
    /// <param name="uiPriority"></param>
    /// <returns></returns>
    public Style AddNewStyle(string styleid, string stylename, StyleRunProperties styleRunProperties, int uiPriority)
    {
        // Create a new paragraph style and specify some of the properties.
        var style = new Style
        {
            Type = StyleValues.Paragraph,
            StyleId = styleid,
            CustomStyle = true
        };
        style.Append(new StyleName { Val = stylename });
        style.Append(new BasedOn { Val = "Normal" });
        style.Append(new NextParagraphStyle { Val = "Normal" });
        style.Append(new UIPriority { Val = uiPriority });
        style.Append(styleRunProperties);

        Styles.Append(style);
        return style;
    }

    /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
    public void Dispose()
    {
        docx?.Dispose();
    }

    /// <summary>
    /// Add a paragraph
    /// </summary>
    /// <param name="text">Text for the paragraph</param>
    /// <param name="styleName">Name of the style for the paragraph</param>
    public Paragraph AddParagraph(string text, string styleName)
    {
        var para = CreateBaseParagraph(styleName);

        var run = para.AppendChild(new Run());
        run.AppendChild(new Text(text));
        return para;
    }

    /// <summary>
    /// Add a paragraph
    /// </summary>
    /// <param name="path">Text for the paragraph</param>
    /// <param name="styleName">Name of the style for the paragraph</param>
    /// <param name="width">Width in pixels</param>
    /// <param name="height">Height in pixels</param>
    public Paragraph AddImage(string path, string styleName, int width, int height)
    {
        _imageCounter++;

        var para = CreateBaseParagraph(styleName);

        var xTwips = MeasurementHelper.GetEmuFromPx(width);
        var yTwips = MeasurementHelper.GetEmuFromPx(height);

        var fi = new FileInfo(path);

        var ip = AddImagePart(path);
        var relationshipId = mainDocumentPart.GetIdOfPart(ip);

        var element =
         new Drawing(
             new DW.Inline(
                 new DW.Extent() { Cx = xTwips, Cy = yTwips },
                 new DW.EffectExtent()
                 {
                     LeftEdge = 0L,
                     TopEdge = 0L,
                     RightEdge = 0L,
                     BottomEdge = 0L
                 },
                 new DW.DocProperties()
                 {
                     Id = (uint)_imageCounter,
                     Name = $"Image {_imageCounter}"
                 },
                 new DW.NonVisualGraphicFrameDrawingProperties(
                     new A.GraphicFrameLocks() { NoChangeAspect = true }),
                 new A.Graphic(
                     new A.GraphicData(
                         new PIC.Picture(
                             new PIC.NonVisualPictureProperties(
                                 new PIC.NonVisualDrawingProperties()
                                 {
                                     Id = (UInt32Value)0U,
                                     Name = fi.Name
                                 },
                                 new PIC.NonVisualPictureDrawingProperties()),
                             new PIC.BlipFill(
                                 new A.Blip(
                                     new A.BlipExtensionList(
                                         new A.BlipExtension()
                                         {
                                             Uri =
                                                "{28A0092B-C50C-407E-A947-70E740481C1C}"
                                         })
                                 )
                                 {
                                     Embed = relationshipId,
                                     CompressionState =
                                     A.BlipCompressionValues.Print
                                 },
                                 new A.Stretch(
                                     new A.FillRectangle())),
                             new PIC.ShapeProperties(
                                 new A.Transform2D(
                                     new A.Offset() { X = 0L, Y = 0L },
                                     new A.Extents() { Cx = xTwips, Cy = yTwips }),
                                 new A.PresetGeometry(
                                     new A.AdjustValueList()
                                 )
                                 { Preset = A.ShapeTypeValues.Rectangle }))
                     )
                     { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" })
             )
             {
                 DistanceFromTop = (UInt32Value)0U,
                 DistanceFromBottom = (UInt32Value)0U,
                 DistanceFromLeft = (UInt32Value)0U,
                 DistanceFromRight = (UInt32Value)0U,
                 //EditId = "50D07946"
             });

        var rImg = new Run(element);
        para.Append(rImg);

        return para;
    }

    private Paragraph CreateBaseParagraph(string styleName)
    {
        var para = body.AppendChild(new Paragraph());

        // If the paragraph has no ParagraphProperties object, create one.
        if (!para.Elements<ParagraphProperties>().Any())
        {
            para.PrependChild(new ParagraphProperties());
        }

        // Get a reference to the ParagraphProperties object.
        para.ParagraphProperties ??= new ParagraphProperties();
        var pPr = para.ParagraphProperties;

        // If a ParagraphStyleId object doesn't exist, create one.
        pPr.ParagraphStyleId ??= new ParagraphStyleId();

        // Set the style of the paragraph.
        pPr.ParagraphStyleId.Val = styleName;
        return para;
    }

    private ImagePart AddImagePart(string path)
    {
        var fi = new FileInfo(path);

        var ext = fi.Extension.ToLowerInvariant();

        PartTypeInfo imageType;

        switch (ext)
        {
            case ".png":
                imageType = ImagePartType.Png;
                break;
            case ".gif":
                imageType = ImagePartType.Gif;
                break;
            case ".jp2":
                imageType = ImagePartType.Jp2;
                break;
            case ".svg":
                imageType = ImagePartType.Svg;
                break;
            default:
                imageType = ImagePartType.Jpeg;
                break;
        }
        
        var imagePart = mainDocumentPart.AddImagePart(imageType);
        using var fis = new FileStream(path, FileMode.Open, FileAccess.Read);
        imagePart.FeedData(fis);
        return imagePart;
    }

    // To insert the picture
    //private static Drawing DrawingManager(string relationshipId, string name, Int64Value cxVal, Int64Value cyVal, string impPosition)
    //{
    //    var haPosition = impPosition;
    //    if (string.IsNullOrEmpty(haPosition))
    //    {
    //        haPosition = "left";
    //    }
    //    // Define the reference of the image.
    //    var anchor = new Anchor();
    //    anchor.Append(new SimplePosition { X = 0L, Y = 0L });
    //    anchor.Append(
    //        new HorizontalPosition(
    //            new HorizontalAlignment(haPosition)
    //        )
    //        {
    //            RelativeFrom = HorizontalRelativePositionValues.Margin
    //        }
    //    );
    //    anchor.Append(
    //        new VerticalPosition(
    //            new PositionOffset("0")
    //        )
    //        {
    //            RelativeFrom =
    //            VerticalRelativePositionValues.Paragraph
    //        }
    //    );
    //    anchor.Append(
    //        new Extent
    //        {
    //            Cx = cxVal,
    //            Cy = cyVal
    //        }
    //    );
    //    anchor.Append(
    //        new EffectExtent
    //        {
    //            LeftEdge = 0L,
    //            TopEdge = 0L,
    //            RightEdge = 0L,
    //            BottomEdge = 0L
    //        }
    //    );
    //    if (!string.IsNullOrEmpty(impPosition))
    //    {
    //        anchor.Append(new WrapSquare { WrapText = WrapTextValues.BothSides });
    //    }
    //    else
    //    {
    //        anchor.Append(new WrapTopBottom());
    //    }
    //    anchor.Append(
    //        new DocProperties
    //        {
    //            Id = (UInt32Value)1U,
    //            Name = name
    //        }
    //    );
    //    anchor.Append(
    //        new NonVisualGraphicFrameDrawingProperties(
    //              new GraphicFrameLocks { NoChangeAspect = true })
    //    );
    //    anchor.Append(
    //        new Graphic(
    //              new GraphicData(
    //                new Picture(
    //                  new NonVisualPictureProperties(
    //                    new NonVisualDrawingProperties
    //                    {
    //                        Id = (UInt32Value)0U,
    //                        Name = name + ".jpg"
    //                    },
    //                    new NonVisualPictureDrawingProperties()),
    //                    new BlipFill(
    //                        new Blip(
    //                            new BlipExtensionList(
    //                                new BlipExtension
    //                                {
    //                                    Uri =
    //                                    "{28A0092B-C50C-407E-A947-70E740481C1C}"
    //                                })
    //                        )
    //                        {
    //                            Embed = relationshipId,
    //                            CompressionState =
    //                            BlipCompressionValues.Print
    //                        },
    //                        new Stretch(
    //                            new FillRectangle())),
    //                  new ShapeProperties(
    //                    new Transform2D(
    //                      new Offset { X = 0L, Y = 0L },
    //                      new Extents
    //                      {
    //                          Cx = cxVal,
    //                          Cy = cyVal
    //                      }),
    //                    new PresetGeometry(
    //                      new AdjustValueList()
    //                    )
    //                    { Preset = ShapeTypeValues.Rectangle }
    //                  )
    //                )
    //          )
    //              { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" })
    //    );
    //    anchor.DistanceFromTop = 0U;
    //    anchor.DistanceFromBottom = 0U;
    //    anchor.DistanceFromLeft = 114300U;
    //    anchor.DistanceFromRight = 114300U;
    //    anchor.SimplePos = false;
    //    anchor.RelativeHeight = 251658240U;
    //    anchor.BehindDoc = true;
    //    anchor.Locked = false;
    //    anchor.LayoutInCell = true;
    //    anchor.AllowOverlap = true;
    //    var element = new Drawing();
    //    element.Append(anchor);
    //    return element;
    //}
}