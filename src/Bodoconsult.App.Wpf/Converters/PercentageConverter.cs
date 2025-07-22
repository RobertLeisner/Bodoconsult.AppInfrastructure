using System.Globalization;
using System.Windows.Data;

namespace Bodoconsult.App.Wpf.Converters
{
    /// <summary>
    /// Convert percentages (format P2) for data binding 
    /// </summary>
    public class PercentageConverter : BaseConverter, IValueConverter
    {
        //E.g. DB 0.042367 --> UI "4.24 %"
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var fraction = double.Parse(value.ToString());
            return fraction.ToString("P2");
        }

        //E.g. UI "4.2367 %" --> DB 0.042367
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Trim any trailing percentage symbol that the user MAY have included
            var valueWithoutPercentage = value.ToString().TrimEnd(' ', '%');
            return double.Parse(valueWithoutPercentage) / 100;
        }
    }
}
