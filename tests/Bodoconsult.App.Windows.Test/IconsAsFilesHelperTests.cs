// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System.IO;
using System.Runtime.Versioning;
using Bodoconsult.App.Windows.System;
using Bodoconsult.App.Windows.Test.Helpers;
using NUnit.Framework;

namespace Bodoconsult.App.Windows.Test;

[TestFixture]
[SupportedOSPlatform("windows")]
public class IconsAsFilesHelperTests
{
    //[SetUp]
    //public void Setup()
    //{
    //}

    [Test]
    public void SaveIcons_OfficeDocuments_IconExtracted()
    {

        var iconDocx = Path.Combine(TestHelper.OutputPath, "docx.gif");
        if (File.Exists(iconDocx))
        {
            File.Delete(iconDocx);
        }

        var iconXlsx = Path.Combine(TestHelper.OutputPath, "xlsx.gif");
        if (File.Exists(iconXlsx))
        {
            File.Delete(iconXlsx);
        }


        var icons = new IconsAsFilesHelper {IconPath = TestHelper.OutputPath};

        var path = Path.Combine(TestHelper.TestDataPath, "Test.docx");

        var fri = new FileInfo(path);
        icons.AddExtension(fri);


        path = Path.Combine(TestHelper.TestDataPath, "Test.xlsx");

        fri = new FileInfo(path);
        icons.AddExtension(fri);

        icons.SaveIcons();

        Assert.That(File.Exists(iconDocx));
        Assert.That(File.Exists(iconXlsx));
    }
}