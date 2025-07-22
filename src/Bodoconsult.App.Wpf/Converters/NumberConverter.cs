using System.Globalization;
using System.Windows.Data;

namespace Bodoconsult.App.Wpf.Converters
{
    /// <summary>
    /// Convert numbers for data binding: Format N2 (#,##0.00)
    /// </summary>
    public class NumberConverter : BaseConverter, IValueConverter
    {
        //E.g. DB 0.042367 --> UI "4.24 %"
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            var format = parameter == null ? "N2" : (string)parameter;

            //var fraction = double.Parse(value.ToString());
            //return fraction.ToString("N2");

            return string.Format(culture, $"{{0:{format}}}", value);
        }

        //E.g. UI "4.2367 %" --> DB 0.042367
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return double.Parse(value.ToString(), culture.NumberFormat);
        }
    }
}