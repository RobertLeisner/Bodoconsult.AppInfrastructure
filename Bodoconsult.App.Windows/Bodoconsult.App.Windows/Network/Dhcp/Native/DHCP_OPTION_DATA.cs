// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Bodoconsult.App.Windows.Network.Dhcp.Native;

/// <summary>
/// The DHCP_OPTION_DATA structure defines a data container for one or more data elements associated with a DHCP option.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
internal readonly struct DhcpOptionData : IDisposable
{
    /// <summary>
    /// Specifies the number of option data elements listed in Elements.
    /// </summary>
    public readonly int NumElements;
    /// <summary>
    /// Pointer to a list of <see cref="DhcpOptionDataElement"/> structures that contain the data elements associated with this particular option element.
    /// </summary>
    private readonly IntPtr ElementsPointer;

    /// <summary>
    /// Pointer to a list of <see cref="DhcpOptionDataElement"/> structures that contain the data elements associated with this particular option element.
    /// </summary>
    public IEnumerable<DhcpOptionDataElement> Elements
    {
        get
        {
            if (NumElements == 0 || ElementsPointer == IntPtr.Zero)
                yield break;

            var elementSize = IntPtr.Size * 3;
            var iter = ElementsPointer;
            for (var i = 0; i < NumElements; i++)
            {
                yield return new DhcpOptionDataElement(optionType: (DhcpOptionDataType)Marshal.ReadInt32(iter),
                    dataOffset: iter + IntPtr.Size);

                iter += elementSize;
            }
        }
    }

    public void Dispose()
    {
        foreach (var element in Elements)
            element.Dispose();

        Api.FreePointer(ElementsPointer);
    }
}

/// <summary>
/// The DHCP_OPTION_DATA structure defines a data container for one or more data elements associated with a DHCP option.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
internal readonly struct DhcpOptionDataManaged : IDisposable
{
    /// <summary>
    /// Specifies the number of option data elements listed in Elements.
    /// </summary>
    public readonly int NumElements;
    /// <summary>
    /// Pointer to a list of <see cref="DhcpOptionDataElement"/> structures that contain the data elements associated with this particular option element.
    /// </summary>
    private readonly IntPtr ElementsPointer;

    public DhcpOptionDataManaged(DhcpOptionDataElementManaged[] elements)
    {
        NumElements = elements?.Length ?? 0;
        if (NumElements == 0)
        {
            ElementsPointer = IntPtr.Zero;
        }
        else
        {
            var elementsSize = Marshal.SizeOf(typeof(DhcpOptionDataElementManaged));
            var elementsPointer = Marshal.AllocHGlobal(elementsSize * elements.Length);
            ElementsPointer = elementsPointer;
            for (var i = 0; i < elements.Length; i++)
            {
                Marshal.StructureToPtr(elements[i], elementsPointer, false);
                elementsPointer += elementsSize;
            }
        }
    }

    public IEnumerable<DhcpOptionDataElementManaged> Elements
    {
        get
        {
            if (ElementsPointer != IntPtr.Zero && NumElements > 0)
            {
                var elementSize = Marshal.SizeOf(typeof(DhcpOptionDataElementManaged));
                var iter = ElementsPointer;
                for (var i = 0; i < NumElements; i++)
                {
                    yield return iter.MarshalToStructure<DhcpOptionDataElementManaged>();
                    iter += elementSize;
                }
            }
        }
    }

    public void Dispose()
    {
        if (ElementsPointer != IntPtr.Zero)
        {
            foreach (var item in Elements)
                item.Dispose();

            Marshal.FreeHGlobal(ElementsPointer);
        }
    }
}