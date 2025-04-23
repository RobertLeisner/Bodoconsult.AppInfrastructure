// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System.Drawing.Printing;

namespace Bodoconsult.App.WinForms.Reporting
{
    /// <summary>
    /// Helper tools for printing a <see cref="PrintDocument"/> instance
    /// </summary>
    internal class PrintReportHelper
    {
        //public static void PrintDocToXpsFile(PrintDocument document, string fileName)
        //{
        //    if (File.Exists(fileName))
        //    {
        //        File.Delete(fileName);
        //    }

        //    var settings = document.DefaultPageSettings.PrinterSettings;
        //    settings.PrinterName = "Microsoft XPS Document Writer";
        //    settings.PrintToFile = true;
        //    settings.PrintFileName = fileName;
        //    document.Print();
        //}


        public static void PrintDocToPdfFile(PrintDocument document, string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            var settings = document.DefaultPageSettings.PrinterSettings;
            settings.PrinterName = "Microsoft Print To PDF";
            settings.PrintToFile = true;
            settings.PrintFileName = fileName;
            document.Print();
        }
    }
}
