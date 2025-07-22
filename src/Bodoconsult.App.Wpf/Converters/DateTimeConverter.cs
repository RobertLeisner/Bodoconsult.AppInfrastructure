// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System.Globalization;
using System.Windows.Data;

namespace Bodoconsult.App.Wpf.Converters
{
    /// <summary>
    /// Converter for DateTime values to UI string
    /// Uses CurrentCulture (settings from system control) instead of CurrentUICulture
    /// </summary>
    [ValueConversion(typeof(DateTime), typeof(string))]
    public class DateTimeConverter : BaseConverter, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var date = (DateTime)value;
            return date.ToString("d", Thread.CurrentThread.CurrentCulture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var strValue = value.ToString();
            DateTime resultDateTime;
            return DateTime.TryParse(strValue, Thread.CurrentThread.CurrentCulture, DateTimeStyles.None, out resultDateTime) ? resultDateTime : value;
        }
    }
}