// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace Bodoconsult.App.Windows.System;

[SupportedOSPlatform("windows")]
public class Shell32
{
    public const int MaxPath = 256;
    public const uint BifReturnonlyfsdirs = 1;
    public const uint BifDontgobelowdomain = 2;
    public const uint BifStatustext = 4;
    public const uint BifReturnfsancestors = 8;
    public const uint BifEditbox = 16;
    public const uint BifValidate = 32;
    public const uint BifNewdialogstyle = 64;
    public const uint BifUsenewui = 80;
    public const uint BifBrowseincludeurls = 128;
    public const uint BifBrowseforcomputer = 4096;
    public const uint BifBrowseforprinter = 8192;
    public const uint BifBrowseincludefiles = 16384;
    public const uint BifShareable = 32768;
    public const uint ShgfiIcon = 256;
    public const uint ShgfiDisplayname = 512;
    public const uint ShgfiTypename = 1024;
    public const uint ShgfiAttributes = 2048;
    public const uint ShgfiIconlocation = 4096;
    public const uint ShgfiExetype = 8192;
    public const uint ShgfiSysiconindex = 16384;
    public const uint ShgfiLinkoverlay = 32768;
    public const uint ShgfiSelected = 65536;
    public const uint ShgfiAttrSpecified = 131072;
    public const uint ShgfiLargeicon = 0;
    public const uint ShgfiSmallicon = 1;
    public const uint ShgfiOpenicon = 2;
    public const uint ShgfiShelliconsize = 4;
    public const uint ShgfiPidl = 8;
    public const uint ShgfiUsefileattributes = 16;
    public const uint ShgfiAddoverlays = 32;
    public const uint ShgfiOverlayindex = 64;
    public const uint FileAttributeDirectory = 16;
    public const uint FileAttributeNormal = 128;

    [DllImport("Shell32.dll")]
    public static extern IntPtr SHGetFileInfo(
        string pszPath,
        uint dwFileAttributes,
        ref Shfileinfo psfi,
        uint cbFileInfo,
        uint uFlags);

    public struct Shitemid
    {
        public ushort Cb;
        [MarshalAs(UnmanagedType.LPArray)]
        public byte[] AbId;
    }

    public struct Itemidlist
    {
        public Shitemid Mkid;
    }

    public struct Browseinfo
    {
        public IntPtr HwndOwner;
        public IntPtr PidlRoot;
        public IntPtr PszDisplayName;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string LpszTitle;
        public uint UlFlags;
        public IntPtr Lpfn;
        public int LParam;
        public IntPtr IImage;
    }

    public struct Shfileinfo
    {
        public const int Namesize = 80;
        public IntPtr HIcon;
        public int IIcon;
        public uint DwAttributes;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string SzDisplayName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string SzTypeName;
    }
}