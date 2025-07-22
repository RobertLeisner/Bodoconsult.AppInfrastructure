using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Bodoconsult.App.Wpf.Converters
{
    /// <summary>
    /// Helps to "convert" images with source set to null, otherwise there will be errors
    /// </summary>
    /// <code>
    /// </code>
    public class NullImageConverter : BaseConverter, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value ?? DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
