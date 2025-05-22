﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System.IO.Compression;

namespace Bodoconsult.App.Zip;

/// <summary>
/// Handles unzipping a ZIP file
/// </summary>
public class UnZipHandler : IDisposable
{
    private readonly ZipArchive _archive;

    private readonly Stream _stream;


    public IList<FileEntry> Files { get; } = new List<FileEntry>();

    public UnZipHandler(string fileName)
    {
        _stream = new FileStream(fileName, FileMode.Open);
        _archive = new ZipArchive(_stream);

        LoadFiles();
    }


    public UnZipHandler(byte[] data)
    {

        Files = new List<FileEntry>();
        _stream = new MemoryStream(data);
        _archive = new ZipArchive(_stream);

        LoadFiles();
    }

    public void LoadFiles()
    {
        foreach (var entry in _archive.Entries)
        {

            var fe = new FileEntry
            {
                FileName = new FileInfo(entry.Name.Replace("/", "\\")).Name,
                Path = entry.FullName
            };

            Files.Add(fe);
        }
    }

    /// <summary>
    /// Save a file from <see cref="Files"/> in ZIP file to a target folder
    /// </summary>
    /// <param name="filePath">File path in ZIP file</param>
    /// <param name="targetPath">Target file. Existing files will be overwritten!</param>
    public void SaveFile(string filePath, string targetPath)
    {

        if (string.IsNullOrEmpty(targetPath))
        {
            throw new ArgumentNullException(nameof(targetPath));
        }

        var entry = _archive.Entries.FirstOrDefault(x => x.FullName == filePath);

        if (entry == null)
        {
            throw new Exception($"File {filePath} not found in ZIP file!");
        }

        try
        {
            if (File.Exists(targetPath))
            {
                File.Delete(targetPath);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        entry.ExtractToFile(targetPath);
    }

    /// <summary>
    /// Get a file from <see cref="Files"/> a byte arry
    /// </summary>
    /// <param name="filePath">File name in ZIP file</param>
    public byte[] GetFileData(string filePath)
    {
        var entry = _archive.Entries.FirstOrDefault(x => x.FullName == filePath);

        if (entry == null)
        {
            throw new Exception($"File {filePath} not found in ZIP file!");
        }

        using (var s = entry.Open())
        {
            using (var fs = new MemoryStream())
            {
                s.CopyTo(fs);

                var bytes = new byte[fs.Length];

                fs.Position = 0;
                fs.Read(bytes, 0, bytes.Length);

                return bytes;
            }
        }
    }

    public void Dispose()
    {
        _archive?.Dispose();
        _stream.Dispose();
    }
}