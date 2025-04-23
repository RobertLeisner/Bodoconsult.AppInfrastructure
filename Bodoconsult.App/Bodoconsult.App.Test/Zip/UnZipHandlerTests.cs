// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System.Diagnostics;
using Bodoconsult.App.Test.Helpers;
using Bodoconsult.App.Zip;

namespace Bodoconsult.App.Test.Zip;

[TestFixture]
[NonParallelizable]
[SingleThreaded]
public class UnZipHandlerTests
{
    [Test]
    public void Ctor_ExistingZip_ContentRead()
    {

        var zipFile = Path.Combine(TestHelper.TestDataPath, @"Rechnung_10.04.2019.zip");

        var uh = new UnZipHandler(zipFile);

        Assert.That(uh.Files.Count>0);

        foreach (var f in uh.Files)
        {
            Debug.Print(f.FileName);
        }

        uh.Dispose();
    }


    [Test]
    public void SaveFile_NotExistingZip_FileWritten()
    {

        var zipFile = Path.Combine(TestHelper.TestDataPath, @"Rechnung_10.04.2019.zip");
        var  targetPath = TestHelper.TempPath;

        var uh = new UnZipHandler(zipFile);

        Assert.That(uh.Files.Count > 0);

        foreach (var f in uh.Files)
        {
            Debug.Print(f.FileName);

            var fileName = Path.Combine(targetPath, f.FileName);

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            uh.SaveFile(f.Path, fileName);

            Assert.That(File.Exists(fileName));
        }

        uh.Dispose();
    }

    [Test]
    public void GetFileData_ExistingZipFile_ReturnsByteArray()
    {

        var zipFile = Path.Combine(TestHelper.TestDataPath, @"Rechnung_10.04.2019.zip");
        var targetPath = TestHelper.TempPath;

        var uh = new UnZipHandler(zipFile);

        Assert.That(uh.Files.Count > 0);

        foreach (var f in uh.Files)
        {
            Debug.Print(f.FileName);

            var fileName = Path.Combine(targetPath, f.FileName);

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            var data = uh.GetFileData(f.Path);

            File.WriteAllBytes(fileName, data);

            Assert.That(data.Length>0);

            Assert.That(File.Exists(fileName));

            TestHelper.StartFile(fileName);
        }

        uh.Dispose();
    }
}