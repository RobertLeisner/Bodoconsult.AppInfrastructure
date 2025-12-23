// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Windows;
using System.Windows.Media;
using Bodoconsult.App.Abstractions.Interfaces;

namespace Bodoconsult.App.Wpf.Documents.Delegates;


/// <summary>
/// Delegate to draw content in a page section
/// </summary>
/// <param name="context">Current drawing context</param>
/// <param name="area">The available area for the section to draw</param>
/// <param name="page">The page number (starting with 0) to print in</param>
/// <param name="dpi">The dpi number to use</param>
/// <param name="pageNumberFormat">Page number format</param>
public delegate void DrawSectionDelegate(DrawingContext context, Rect area, int page, double dpi, PageNumberFormatEnum pageNumberFormat);