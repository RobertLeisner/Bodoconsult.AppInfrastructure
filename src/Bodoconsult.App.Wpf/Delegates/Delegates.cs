using System.Windows;
using System.Windows.Media;

namespace Bodoconsult.App.Wpf.Delegates;

/// <summary>
/// Send a status message to the UI
/// </summary>
/// <param name="message"></param>
public delegate void SendStatusMessageDelegate(string message);

/// <summary>
/// Delegate to draw content in a page section
/// </summary>
/// <param name="context">Current drawing context</param>
/// <param name="area">The available area for the section to draw</param>
/// <param name="page">The page number (starting with 0) to print in</param>
/// <param name="dpi">The dpi number to use</param>
public delegate void DrawSectionDelegate(DrawingContext context, Rect area, int page, double dpi);