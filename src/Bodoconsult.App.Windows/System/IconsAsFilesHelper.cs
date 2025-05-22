﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Versioning;

namespace Bodoconsult.App.Windows.System;

/// <summary>
/// Get app icons for files from system
/// </summary>
[SupportedOSPlatform("windows")]
public class IconsAsFilesHelper
{
    private readonly Dictionary<string, string> _ext = new();

    /// <summary>
    /// Path to store the icons in
    /// </summary>
    public string IconPath { private get; set; }

    /// <summary>
    /// Add the extension for a certai file
    /// </summary>
    /// <param name="fi">Current file</param>
    public void AddExtension(FileInfo fi)
    {
        if (_ext.ContainsKey(fi.Extension) == false)
        {
            _ext.Add(fi.Extension, fi.FullName);
        }
    }



    /// <summary>
    /// Save the icons for all registred extensions as GIF file
    /// </summary>
    public void SaveIcons()
    {

        foreach (var x in _ext)
        {
            var fileName = Path.Combine(IconPath , $"{x.Key.Replace(".", null).ToLower()}.gif");

            if (File.Exists(fileName)) continue;

            using (var i = FileIcon.GetIcon(x.Key))
            {
                i.Save(fileName, ImageFormat.Gif);

            }
        }
    }
}