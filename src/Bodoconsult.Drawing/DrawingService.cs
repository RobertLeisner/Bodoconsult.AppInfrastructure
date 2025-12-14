// Copyright (c) Bodoconsult EDV-Dienstleistungen. All rights reserved.

using System.Drawing;
using System.Runtime.Versioning;

namespace Bodoconsult.Drawing;


/// <summary>
/// Service for simple System.Drawing based graphics services
/// </summary>
[SupportedOSPlatform("windows")]
public class DrawingService
{

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="graphics">Graphics instance to use</param>

    public DrawingService(Graphics graphics)
    {
        Graphics = graphics;
    }

    /// <summary>
    /// Current <see cref="Graphics"/> instance
    /// </summary>
    public Graphics Graphics { get; }

    /// <summary>
    /// Draw a text left adjusted
    /// </summary>
    /// <param name="text">test to left adjust</param>
    /// <param name="font">font to use</param>
    /// <param name="brush">brush to use</param>
    /// <param name="x1">left corner x-coordinate</param>
    /// <param name="y1">left corner y-coordinate</param>
    /// <param name="x2">right corner x-coordinate</param>
    /// <param name="height">right corner y-coordinate</param>
    /// <param name="xDistance">distance on the left end from left corner x-coordinate x1</param>
    public void LeftText(string text, Font font, Brush brush, float x1, float y1, float x2, float height, float xDistance = 1F)
    {
        var stringFormat = new StringFormat(StringFormat.GenericTypographic) { Alignment = StringAlignment.Near };
        Graphics.DrawString(text, font, brush, new RectangleF(x1, y1, x2 - x1 - xDistance, height), stringFormat);
    }

    /// <summary>
    /// Draw a text right adjusted
    /// </summary>
    /// <param name="text">test to right adjust</param>
    /// <param name="font">font to use</param>
    /// <param name="brush">brush to use</param>
    /// <param name="x1">left corner x-coordinate</param>
    /// <param name="y1">left corner y-coordinate</param>
    /// <param name="x2">right corner x-coordinate</param>
    /// <param name="height">right corner y-coordinate</param>
    /// <param name="xDistance">distance on the right end from right corner x-coordinate x2</param>
    public void RightText(string text, Font font, Brush brush, float x1, float y1, float x2, float height, float xDistance = 1F)
    {
        var stringFormat = new StringFormat(StringFormat.GenericTypographic) { Alignment = StringAlignment.Far };
        Graphics.DrawString(text, font, brush, new RectangleF(x1, y1, x2 - x1 - xDistance, height), stringFormat);
    }


    /// <summary>
    /// Draw a text right adjusted
    /// </summary>
    /// <param name="text">test to draw centered</param>
    /// <param name="font">font to use</param>
    /// <param name="brush">brush to use</param>
    /// <param name="x1">left corner x-coordinate</param>
    /// <param name="y1">left corner y-coordinate</param>
    /// <param name="x2">right corner x-coordinate</param>
    /// <param name="height">height of the rectangle to draw in</param>
    public void CenteredText(string text, Font font, Brush brush, float x1, float y1, float x2, float height)
    {
        var stringFormat = new StringFormat(StringFormat.GenericTypographic) { Alignment = StringAlignment.Center };
        Graphics.DrawString(text, font, brush, new RectangleF(x1, y1, x2 - x1, height), stringFormat);
    }

    /// <summary>
    /// Draw a rectangle
    /// </summary>
    /// <param name="pen">pen to use</param>
    /// <param name="x1">left corner x-coordinate</param>
    /// <param name="y1">left corner y-coordinate</param>
    /// <param name="x2">right corner x-coordinate</param>
    /// <param name="height">height of the rectangle to draw in</param>
    public void DrawRectangle(Pen pen, float x1, float y1, float x2, float height)
    {
        Graphics.DrawRectangle(pen, x1, y1, x2 - x1, height);
    }

    /// <summary>
    /// Draw an image with a frame around it
    /// </summary>
    /// <param name="img">Image to draw</param>
    /// <param name="framePen">Pen to use for the frame around the image</param>
    /// <param name="x">left corner x-coordinate</param>
    /// <param name="y">left corner y-coordinate</param>
    /// <param name="width">Width of the image to draw</param>
    /// <param name="height">Height of the image to draw</param>
    public void DrawImageWithFrame(Image img, Pen framePen, float x, float y, float width, float height)
    {
        Graphics.DrawImage(img, x, y, width, height);
        Graphics.DrawRectangle(framePen, x, y, width, height);
    }

}