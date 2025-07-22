// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Bodoconsult.App.Wpf.Converters;

/// <summary>
///  Convert a color to a solid brush
/// </summary>
public class ColorToBrushConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var brush = value is null ? null : new SolidColorBrush((Color)value);
        return brush;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (value as SolidColorBrush)?.Color;
    }
}