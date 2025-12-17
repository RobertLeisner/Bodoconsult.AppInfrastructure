// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System.IO.Compression;

namespace Bodoconsult.App.Zip;

/// <summary>
/// Class to generate ZIP files as file or as stream
/// </summary>
public class ZipHandler
{
    private readonly string[] _files;

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="files">Files to pack in ZIP file</param>
    public ZipHandler(string[] files)
    {
        _files = files;
    }

    /// <summary>
    /// Generate ZIP file and save it as file to disk
    /// </summary>
    /// <param name="fileName">File name</param>
    public void GenerateZip(string fileName)
    {
        if (string.IsNullOrEmpty(fileName))
        {
            throw new ArgumentNullException(nameof(fileName));
        }

        if (File.Exists(fileName))
        {
            File.Delete(fileName);
        }

        using var zipToOpen = new FileStream(fileName, FileMode.OpenOrCreate);
        using var archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update);
        GenerateZipBase(archive);
    }

    /// <summary>
    /// Generate ZIP file and save it into a stream
    /// </summary>
    /// <param name="stream">File name</param>
    public void GenerateZip(MemoryStream stream)
    {
        var ms = new MemoryStream();
        using (var archive = new ZipArchive(ms, ZipArchiveMode.Create))
        {
            GenerateZipBase(archive);

            ms.Position = 0;
            stream.Position = 0;
            ms.CopyTo(stream);
        }
        stream.Position = 0;
    }

    private void GenerateZipBase(ZipArchive zip)
    {
        foreach (var file in _files)
        {
            var fi = new FileInfo(file);

            if (!fi.Exists)
            {
                throw new Exception($"Not found: {file}");
            }

            zip.CreateEntryFromFile(file, fi.Name);
        }
    }
}