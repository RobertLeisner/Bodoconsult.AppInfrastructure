// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System;
using System.Runtime.InteropServices;

namespace Bodoconsult.App.Windows.Network.Dhcp.Native;

[StructLayout(LayoutKind.Sequential)]
internal readonly struct DhcpClientUid : IDisposable
{
    /// <summary>
    /// Specifies the size of Data, in bytes.
    /// </summary>
    public readonly int DataLength;

    /// <summary>
    /// Pointer to an opaque blob of byte (binary) data.
    /// </summary>
    private readonly IntPtr DataPointer;

    /// <summary>
    /// Blob of byte (binary) data.
    /// </summary>
    public byte[] Data
    {
        get
        {
            var blob = new byte[DataLength];

            if (DataLength != 0)
                Marshal.Copy(DataPointer, blob, 0, DataLength);

            return blob;
        }
    }

    public DhcpIpAddress ClientIpAddress
    {
        get
        {
            if (DataLength < 4)
                throw new ArgumentOutOfRangeException(nameof(DataLength));

            return (DhcpIpAddress)Marshal.ReadInt32(DataPointer);
        }
    }

    public DhcpServerHardwareAddress ClientHardwareAddress
    {
        get
        {
            if (DataLength < 5)
                throw new ArgumentOutOfRangeException(nameof(DataLength));

            return DhcpServerHardwareAddress.FromNative(DhcpServerHardwareType.Ethernet, DataPointer + 5, DataLength - 5);
        }
    }

    public void Dispose()
    {
        Api.FreePointer(DataPointer);
    }
}

[StructLayout(LayoutKind.Sequential)]
internal readonly struct DhcpClientUidManaged : IDisposable
{
    /// <summary>
    /// Specifies the size of Data, in bytes.
    /// </summary>
    public readonly int DataLength;

    /// <summary>
    /// Pointer to an opaque blob of byte (binary) data.
    /// </summary>
    private readonly IntPtr DataPointer;

    public DhcpClientUidManaged(byte[] data)
    {
        if (data == null || data.Length == 0)
        {
            DataLength = 0;
            DataPointer = IntPtr.Zero;
        }
        else
        {
            DataLength = data.Length;
            DataPointer = Marshal.AllocHGlobal(data.Length);
            Marshal.Copy(data, 0, DataPointer, data.Length);
        }
    }

    public DhcpClientUidManaged(DhcpIpAddress data)
    {
        DataLength = Marshal.SizeOf(data);
        DataPointer = Marshal.AllocHGlobal(DataLength);
        Marshal.StructureToPtr(data, DataPointer, false);
    }

    public DhcpClientUidManaged(ulong bytes1, ulong bytes2, int dataLength)
    {
        if (dataLength == 0)
        {
            DataLength = 0;
            DataPointer = IntPtr.Zero;
        }
        else
        {
            DataLength = dataLength;
            DataPointer = Marshal.AllocHGlobal(dataLength > 8 ? 16 : 8);

            bytes1 = BitHelper.HostToNetworkOrder(bytes1);
            Marshal.WriteInt64(DataPointer, (long)bytes1);

            if (dataLength > 8)
            {
                bytes2 = BitHelper.HostToNetworkOrder(bytes2);
                Marshal.WriteInt64(DataPointer + 8, (long)bytes2);
            }

        }
    }

    public void Dispose()
    {
        if (DataPointer != IntPtr.Zero)
            Marshal.FreeHGlobal(DataPointer);
    }
}