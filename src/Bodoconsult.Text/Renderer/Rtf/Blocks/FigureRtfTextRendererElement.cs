// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.Rtf.Blocks;

/// <summary>
/// Rtf rendering element for <see cref="Figure"/> instances
/// </summary>
public class FigureRtfTextRendererElement : RtfTextRendererElementBase
{
    private readonly Figure _figure;

    /// <summary>
    /// Default ctor
    /// </summary>
    public FigureRtfTextRendererElement(Figure figure) : base(figure)
    {
        _figure = figure;
        ClassName = figure.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(ITextDocumentRenderer renderer)
    {
        DocumentRendererHelper.CreateImageRtf(renderer, _figure);

        //// Get the content of all inlines as string
        //var sb = new StringBuilder();

        //if (Block is ParagraphBase paragraph)
        //{
        //    var style = (ParagraphStyleBase)renderer.Styleset.FindStyle(paragraph.StyleName);
        //    renderer.Content.Append($"\\pard\\plain\\q{renderer.Styleset.GetIndexOfStyle(Block.StyleName)} {RtfHelper.GetFormatSettings(style, renderer.Styleset)}{{");
        //}
        //else
        //{
        //    renderer.Content.Append($"\\pard\\plain\\q{renderer.Styleset.GetIndexOfStyle(Block.StyleName)}{{");
        //}

        //// Get max height and with for images in twips
        //StylesetHelper.GetMaxWidthAndHeight(renderer.Styleset, out var maxWidth, out var maxHeight);

        //StylesetHelper.GetWidthAndHeight(MeasurementHelper.GetTwipsFromPx(_figure.OriginalWidth), MeasurementHelper.GetTwipsFromPx(_figure.OriginalHeight), maxWidth, maxHeight, out var width, out var height);

        //// Add the image
        //var bytes = ImageHelper.GetBytes(_figure.Uri);

        //var path = _figure.Uri.ToLowerInvariant();

        //if (path.EndsWith(".jpg") || path.EndsWith(".jpeg"))
        //{
        //    sb.Append($"{{\\*\\shppict{{\\pict\\jpgblip\\picw{width}\\pich{height}\\picwgoal{width}\\pichgoal{height}\\bin{{");
        //}
        //else if (path.EndsWith(".png"))
        //{
        //    sb.Append($"{{\\*\\shppict {{\\pict\\pngblip\\picw{width}\\pich{height}\\picwgoal{width}\\pichgoal{height}\\bin{{");
        //}
        //else
        //{
        //    throw new NotSupportedException("Unsupported image format. Use JPEG or PNG images!");
        //}

        //var str = BitConverter.ToString(bytes, 0).Replace("-", string.Empty);
        //sb.Append(str);
        //sb.Append("}\\line");

        //DocumentRendererHelper.RenderInlineChildsToRtf(renderer, sb, Block.ChildInlines);

        //renderer.Content.Append(sb);
        //renderer.Content.Append($"\\par}}{Environment.NewLine}");
    }
}
