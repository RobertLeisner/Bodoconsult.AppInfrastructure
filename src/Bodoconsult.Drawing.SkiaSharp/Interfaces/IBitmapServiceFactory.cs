// Copyright (c) Bodoconsult EDV-Dienstleistungen. All rights reserved.

namespace Bodoconsult.Drawing.SkiaSharp.Interfaces;

/// <summary>
/// Interface for factories creating SkiaSharp based bitmap services based on <see cref="IBitmapService"/>
/// </summary>
public interface IBitmapServiceFactory
{
    /// <summary>
    /// Create a SkiaSharp based bitmap service instance based on <see cref="IBitmapService"/>
    /// </summary>
    /// <returns>SkiaSharp based bitmap service instance based on <see cref="IBitmapService"/></returns>
    public IBitmapService CreateInstance();
}