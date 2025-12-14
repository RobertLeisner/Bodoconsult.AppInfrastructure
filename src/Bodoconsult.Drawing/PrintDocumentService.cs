//// Copyright (c) Bodoconsult EDV-Dienstleistungen. All rights reserved.

//using System.Drawing.Printing;
//using System.Runtime.Versioning;
//using Bodoconsult.Typography;

//namespace Bodoconsult.Drawing;

///// <summary>
///// 
///// </summary>
//[SupportedOSPlatform("windows")]
//public class PrintDocumentService
//{

//    //public PrintDocumentService()
//    //{
        
//    //}

//    /// <summary>
//    /// Current print document
//    /// </summary>
//    public PrintDocument CurrentDocument { get; set; }


//    #region typograhic grid

//    private float _vLine0;
//    private float _vLine1;
//    private float _vLine2;
//    private float _vLine3;
//    private float _vLine4;
//    private float _vLine5;
//    private float _vLine6;
//    private float _vLine7;
//    private float _vLine8;
//    private float _vLine9;
//    private float _vLine10;
//    private float _vLine11;
//    private float _vLine12;
//    private float _vLine13;

//    private float _colWidth1;
//    private float _colWidth2;

//    #endregion

//    private ITypography _typography;

//    /// <summary>
//    /// Contains typographical information like papersize, typo grid coordinates 
//    /// </summary>
//    public ITypography Typography
//    {
//        get => _typography;
//        set
//        {
//            _typography = value;
//            _vLine0 = (float)_typography.VerticalLines[0] * 10;
//            _vLine1 = (float)_typography.VerticalLines[1] * 10;
//            _vLine2 = (float)_typography.VerticalLines[2] * 10;
//            _vLine3 = (float)_typography.VerticalLines[3] * 10;
//            _vLine4 = (float)_typography.VerticalLines[4] * 10;
//            _vLine5 = (float)_typography.VerticalLines[5] * 10;
//            _vLine6 = (float)_typography.VerticalLines[6] * 10;
//            _vLine7 = (float)_typography.VerticalLines[7] * 10;
//            _vLine8 = (float)_typography.VerticalLines[8] * 10;
//            _vLine9 = (float)_typography.VerticalLines[9] * 10;
//            _vLine10 = (float)_typography.VerticalLines[10] * 10;
//            _vLine11 = (float)_typography.VerticalLines[11] * 10;
//            _vLine12 = (float)_typography.VerticalLines[12] * 10;
//            _vLine13 = (float)_typography.VerticalLines[13] * 10;
//            _colWidth1 = (float)_typography.ColumnWidth * 10;
//            _colWidth2 = (float)(2 * _typography.ColumnWidth + _typography.ColumnDividerWidth) * 10;

//            // set paper size
//            CurrentDocument.PrinterSettings.DefaultPageSettings.PaperSize = GetPaperSize();

//        }
//    }

//    /// <summary>
//    /// Get the paper size of the document
//    /// </summary>
//    /// <returns>Gets the current papersize of the document</returns>
//    public PaperSize GetPaperSize()
//    {
//        PaperSize size1 = null;
//        var paperName =_typography.PaperFormatName.ToUpper();
//        var settings = CurrentDocument.PrinterSettings;
//        foreach (PaperSize size in settings.PaperSizes)
//        {
//            if (size.Kind.ToString().ToUpper() == paperName)
//            {
//                size1 = size;
//                break;
//            }
//        }
//        return size1;
//    }
//}