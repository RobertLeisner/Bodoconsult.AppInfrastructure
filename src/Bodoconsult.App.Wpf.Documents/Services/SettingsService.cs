using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FontFamily = System.Windows.Media.FontFamily;

namespace Bodoconsult.Wpf.Documents.Services
{
    public class SettingsService
    {




        public static string FontName { get; set; }


        public static FontFamily FontFamily
        {
            get
            {
                FontFamily f=null;

                System.Windows.Application.Current.Dispatcher.Invoke(() => f = new FontFamily(FontName));

                return f;
            }
        }

    }
}
