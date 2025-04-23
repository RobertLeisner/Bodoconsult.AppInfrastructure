// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System;
using System.Runtime.InteropServices;

namespace Bodoconsult.App.Windows.Network.Dhcp.Native;

/// <summary>
/// The DHCP_OPTION_DATA_ELEMENT structure defines a data element present (either singly or as a member of an array) within a DHCP_OPTION_DATA structure. 
/// </summary>
[StructLayout(LayoutKind.Sequential)]
internal readonly struct DhcpOptionDataElement : IDisposable
{
    /// <summary>
    /// A DHCP_OPTION_DATA_TYPE enumeration value that indicates the type of data that is present in the subsequent field, Element.
    /// </summary>
    public readonly DhcpOptionDataType OptionType;

    /// <summary>
    /// Pointer to the element data
    /// </summary>
    public readonly IntPtr DataOffset;

    public DhcpOptionDataElement(DhcpOptionDataType optionType, IntPtr dataOffset)
    {
        OptionType = optionType;
        DataOffset = dataOffset;
    }

    /// <summary>
    /// Specifies the data as a BYTE value. This field will be present if the OptionType is DhcpByteOption.
    /// </summary>
    public byte ByteOption => Marshal.ReadByte(DataOffset);

    /// <summary>
    /// Specifies the data as a WORD value. This field will be present if the OptionType is DhcpWordOption.
    /// </summary>
    public short WordOption => Marshal.ReadInt16(DataOffset);

    /// <summary>
    /// Specifies the data as a DWORD value. This field will be present if the OptionType is DhcpDWordOption.
    /// </summary>
    public int DWordOption => Marshal.ReadInt32(DataOffset);

    /// <summary>
    /// Specifies the data as a DWORD_DWORD value. This field will be present if the OptionType is DhcpDWordDWordOption.
    /// </summary>
    public long DWordDWordOption => Marshal.ReadInt64(DataOffset);

    /// <summary>
    /// Specifies the data as a DHCP_IP_ADDRESS (DWORD) value. This field will be present if the OptionType is IpAddressOption.
    /// </summary>
    public DhcpIpAddress IpAddressOption => DataOffset.MarshalToStructure<DhcpIpAddress>();

    /// <summary>
    /// Specifies the data as a Unicode string value. This field will be present if the OptionType is DhcpStringDataOption.
    /// </summary>
    public IntPtr StringDataOption => Marshal.ReadIntPtr(DataOffset);

    /// <summary>
    /// Specifies the data as a DHCP_BINARY_DATA structure. This field will be present if the OptionType is DhcpBinaryDataOption.
    /// </summary>
    public DhcpBinaryData BinaryDataOption => DataOffset.MarshalToStructure<DhcpBinaryData>();

    /// <summary>
    /// Specifies the data as encapsulated within a DHCP_BINARY_DATA structure. The application must know the format of the opaque data capsule in order to read it from the Data field of DHCP_BINARY_DATA. This field will be present if the OptionType is DhcpEncapsulatedDataOption.
    /// </summary>
    public DhcpBinaryData EncapsulatedDataOption => DataOffset.MarshalToStructure<DhcpBinaryData>();

    /// <summary>
    /// Specifies the data as a Unicode string value. This field will be present if the OptionType is DhcpIpv6AddressOption.
    /// </summary>
    public IntPtr Ipv6AddressDataOption => Marshal.ReadIntPtr(DataOffset);

    public void Dispose()
    {
        if (DataOffset != IntPtr.Zero)
        {
            if (OptionType == DhcpOptionDataType.DhcpStringDataOption ||
                OptionType == DhcpOptionDataType.DhcpIpv6AddressOption)
            {
                // Pointer at Offset
                var ptr = Marshal.ReadIntPtr(DataOffset);
                Api.FreePointer(ptr);
            }
            else if (OptionType == DhcpOptionDataType.DhcpBinaryDataOption ||
                     OptionType == DhcpOptionDataType.DhcpBinaryDataOption)
            {
                // Pointer in Binary Data structure
                var data = DataOffset.MarshalToStructure<DhcpBinaryData>();
                data.Dispose();
            }
        }
    }
}

/// <summary>
/// The DHCP_OPTION_DATA_ELEMENT structure defines a data element present (either singly or as a member of an array) within a DHCP_OPTION_DATA structure. 
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 4)]
internal readonly struct DhcpOptionDataElementManaged : IDisposable
{
    /// <summary>
    /// A DHCP_OPTION_DATA_TYPE enumeration value that indicates the type of data that is present in the subsequent field, Element.
    /// </summary>
    public readonly IntPtr OptionType;

    private readonly DhcpOptionDataElementManagedValue Data;

    public DhcpOptionDataElementManaged(byte dataByte)
    {
        OptionType = (IntPtr)DhcpOptionDataType.DhcpByteOption;
        Data = new DhcpOptionDataElementManagedValue() { DataByte = dataByte };
    }

    public DhcpOptionDataElementManaged(short dataWord)
    {
        OptionType = (IntPtr)DhcpOptionDataType.DhcpWordOption;
        Data = new DhcpOptionDataElementManagedValue() { DataWord = dataWord };
    }

    public DhcpOptionDataElementManaged(int dataDWord)
    {
        OptionType = (IntPtr)DhcpOptionDataType.DhcpDWordOption;
        Data = new DhcpOptionDataElementManagedValue() { DataDWord = dataDWord };
    }

    public DhcpOptionDataElementManaged(long dataDWordDWord)
    {
        OptionType = (IntPtr)DhcpOptionDataType.DhcpDWordDWordOption;
        Data = new DhcpOptionDataElementManagedValue() { DataDWordDWord = dataDWordDWord };
    }

    public DhcpOptionDataElementManaged(DhcpIpAddress dataIpAddress)
    {
        OptionType = (IntPtr)DhcpOptionDataType.DhcpIpAddressOption;
        Data = new DhcpOptionDataElementManagedValue() { DataIpAddress = dataIpAddress };
    }

    public DhcpOptionDataElementManaged(DhcpOptionDataType type, string dataString)
    {
        switch (type)
        {
            case DhcpOptionDataType.DhcpStringDataOption:
                OptionType = (IntPtr)DhcpOptionDataType.DhcpStringDataOption;
                Data = new DhcpOptionDataElementManagedValue() { DataString = Marshal.StringToHGlobalUni(dataString) };
                break;
            case DhcpOptionDataType.DhcpIpv6AddressOption:
                OptionType = (IntPtr)DhcpOptionDataType.DhcpIpv6AddressOption;
                Data = new DhcpOptionDataElementManagedValue() { DataIpv6Address = Marshal.StringToHGlobalUni(dataString) };
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type));
        }
    }

    public DhcpOptionDataElementManaged(DhcpOptionDataType type, DhcpBinaryDataManaged dataBinary)
    {
        switch (type)
        {
            case DhcpOptionDataType.DhcpBinaryDataOption:
                OptionType = (IntPtr)DhcpOptionDataType.DhcpBinaryDataOption;
                Data = new DhcpOptionDataElementManagedValue() { DataBinary = dataBinary };
                break;
            case DhcpOptionDataType.DhcpEncapsulatedDataOption:
                OptionType = (IntPtr)DhcpOptionDataType.DhcpEncapsulatedDataOption;
                Data = new DhcpOptionDataElementManagedValue() { DataBinary = dataBinary };
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type));
        }
    }

    public void Dispose()
    {
        switch ((DhcpOptionDataType)OptionType)
        {
            case DhcpOptionDataType.DhcpStringDataOption:
                Marshal.FreeHGlobal(Data.DataString);
                break;
            case DhcpOptionDataType.DhcpIpv6AddressOption:
                Marshal.FreeHGlobal(Data.DataIpv6Address);
                break;
            case DhcpOptionDataType.DhcpBinaryDataOption:
                Data.DataBinary.Dispose();
                break;
            case DhcpOptionDataType.DhcpEncapsulatedDataOption:
                Data.DataEncapsulated.Dispose();
                break;
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    internal struct DhcpOptionDataElementManagedValue
    {
        [FieldOffset(0)]
        public byte DataByte;
        [FieldOffset(0)]
        public short DataWord;
        [FieldOffset(0)]
        public int DataDWord;
        [FieldOffset(0)]
        public long DataDWordDWord;
        [FieldOffset(0)]
        public DhcpIpAddress DataIpAddress;
        [FieldOffset(0)]
        public IntPtr DataString;
        [FieldOffset(0)]
        public DhcpBinaryDataManaged DataBinary;
        [FieldOffset(0)]
        public DhcpBinaryDataManaged DataEncapsulated;
        [FieldOffset(0)]
        public IntPtr DataIpv6Address;
    }
}
