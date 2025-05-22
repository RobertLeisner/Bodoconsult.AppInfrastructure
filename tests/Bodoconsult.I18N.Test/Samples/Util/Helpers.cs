using System.Globalization;
using System.Threading;

namespace Bodoconsult.I18N.Test.Samples.Util;

public static class CulturHelper
{
    public static void SetCulture(string cultureName)
    {
        CultureInfo.DefaultThreadCurrentCulture =
            CultureInfo.DefaultThreadCurrentUICulture =
                Thread.CurrentThread.CurrentCulture =
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureName);
    }
}