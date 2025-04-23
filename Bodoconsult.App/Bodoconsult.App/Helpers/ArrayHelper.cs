﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System.Buffers;
using System.Text;

namespace Bodoconsult.App.Helpers;

/// <summary>
/// Tools for array handling
/// </summary>
public static class ArrayHelper
{
    /// <summary>
    /// Compare two allocation arrays
    /// </summary>
    /// <param name="array1">Allocation array 1</param>
    /// <param name="array2">Allocation array 2</param>
    /// <returns>True if both arrays have the same values, else false.</returns>
    public static bool ArrayCompare(int[,,] array1, int[,,] array2)
    {

        var stackLen = array1.GetLength(0);
        var rowLen = array1.GetLength(1);
        var subindexLen = array1.GetLength(2);

        if (stackLen != array2.GetLength(0))
        {
            return false;
        }

        if (rowLen != array2.GetLength(1))
        {
            return false;
        }

        if (subindexLen != array2.GetLength(2))
        {
            return false;
        }

        for (var stack = 0; stack < stackLen; stack++)
        {
            for (var row = 0; row < rowLen; row++)
            { 
                for (var subindex = 0; subindex < subindexLen; subindex++)
                {
                    if (array1[stack, row, subindex] != array2[stack, row, subindex])
                    {
                        return false;
                    }
                }
            }
        }

        return true;
    }

    /// <summary>
    /// Get a string from a byte array
    /// </summary>
    /// <param name="data">Byte array as <see cref="ReadOnlySequence{T}"/></param>
    /// <returns>Byte array as string</returns>
    public static string GetStringFromArray(ref ReadOnlySequence<byte> data)
    {
        var value = new StringBuilder();
        foreach (var b in data.ToArray())
        {
            if (b <= 33 || b >= 127)
            {
                value.Append($"[{b:X2}]");
            }
            else
            {
                value.Append(Convert.ToChar(b));
            }
        }
        return value.ToString();
    }

    /// <summary>
    /// Get a string from a byte array
    /// </summary>
    /// <param name="data">Byte array</param>
    /// <returns>Byte array as string</returns>
    public static string GetStringFromArray(byte[] data)
    {
        var value = new StringBuilder();
        foreach (var b in data)
        {
            if (b <= 33 || b >= 127)
            {
                value.Append($"[{b:X2}]");
            }
            else
            {
                value.Append(Convert.ToChar(b));
            }
        }
        return value.ToString();
    }


    /// <summary>
    /// Get a string from a byte array
    /// </summary>
    /// <param name="data">Byte array</param>
    /// <returns>Byte array as string</returns>
    public static string GetStringFromArray(ReadOnlyMemory<byte> data)
    {
        var value = new StringBuilder();
        byte b;

        for (var i = 0; i < data.Length; i++)
        {
            b = data.Slice(i, 1).Span[0];
            if (b <= 33 || b >= 127)
            {
                value.Append($"[{b:X2}]");
            }
            else
            {
                value.Append(Convert.ToChar(b));
            }
        }
        return value.ToString();
    }

    ///// <summary>
    ///// Get a string from a byte array
    ///// </summary>
    ///// <param name="data">Byte array</param>
    ///// <returns>Byte array as string</returns>
    //public static string GetStringFromArray(ReadOnlySequence<byte> data)
    //{
    //    var value = new StringBuilder();
    //    byte b;

    //    for (var i = 0; i < data.Length; i++)
    //    {
    //        b = data.Slice(i, 1).FirstSpan[0];
    //        if (b <= 33 || b >= 127)
    //        {
    //            value.Append($"[{b:X2}]");
    //        }
    //        else
    //        {
    //            value.Append(Convert.ToChar(b));
    //        }
    //    }
    //    return value.ToString();
    //}

    /// <summary>
    /// Get a string from a byte array
    /// </summary>
    /// <param name="data">Byte array</param>
    /// <returns>Byte array as string</returns>
    public static string GetStringFromArray(Memory<byte> data)
    {
        var value = new StringBuilder();
        byte b;

        for (var i = 0; i < data.Length; i++)
        {
            b = data.Slice(i, 1).Span[0];
            if (b <= 33 || b >= 127)
            {
                value.Append($"[{b:X2}]");
            }
            else
            {
                value.Append(Convert.ToChar(b));
            }
        }
        return value.ToString();
    }

    ///// <summary>
    ///// Get a string from a byte array
    ///// </summary>
    ///// <param name="data">Byte array</param>
    ///// <returns>Byte array as string</returns>
    //public static string GetStringFromArray(ref Span<byte> data)
    //{
    //    var value = new StringBuilder();
    //    byte b;

    //    for (var i = 0; i < data.Length; i++)
    //    {
    //        b = data.Slice(i, 1)[0];
    //        if (b <= 33 || b >= 127)
    //        {
    //            value.Append($"[{b:X2}]");
    //        }
    //        else
    //        {
    //            value.Append(Convert.ToChar(b));
    //        }
    //    }
    //    return value.ToString();
    //}

    /// <summary>
    /// Get a string from a byte array in C# style (for copying it to unit tests)
    /// </summary>
    /// <param name="data">Byte array</param>
    /// <returns>Byte array as string</returns>
    public static string GetStringFromArrayCsharpStyle(byte[] data)
    {

        var result = new StringBuilder();

        result.AppendLine(GetStringFromArray(data));

        result.Append("{ ");

        foreach (var b in data)
        {
            result.Append($"0x{b:x}, ");
        }

        var s = result.ToString();

        return s.EndsWith(", ", StringComparison.OrdinalIgnoreCase) ?
            $"{s[..^2]} }}" :
            $"{s} }}";
    }

    public static string GetStringFromArrayCsharpStyle(ReadOnlyMemory<byte> data)
    {

        var result = new StringBuilder();

        result.Append(GetStringFromArray(data));

        result.Append("  { ");

        for (var i = 0; i < data.Length; i++)
        {
            result.Append($"0x{data.Slice(i, 1).Span[0]:x}, ");
        }

        var s = result.ToString();

        return s.EndsWith(", ", StringComparison.OrdinalIgnoreCase) ?
            $"{s[..^2]} }}" :
            $"{s} }}";
    }


    //public static string GetStringFromArrayCsharpStyle(ref Span<byte> data)
    //{

    //    var result = new StringBuilder();

    //    result.AppendLine(GetStringFromArray(ref data));

    //    result.Append("{ ");

    //    for (var i = 0; i < data.Length; i++)
    //    {
    //        result.Append($"0x{data.Slice(i, 1)[0]:x}, ");
    //    }

    //    var s = result.ToString();

    //    return s.EndsWith(", ", StringComparison.OrdinalIgnoreCase) ?
    //        $"{s[..^2]} }}" :
    //        $"{s} }}";
    //}

    //public static string GetStringFromArrayCsharpStyle(ReadOnlySequence<byte> data)
    //{

    //    var result = new StringBuilder();

    //    result.AppendLine(GetStringFromArray(data));

    //    result.Append("{ ");

    //    for (var i = 0; i < data.Length; i++)
    //    {
    //        result.Append($"0x{data.Slice(i, 1).FirstSpan[0]:x}, ");
    //    }

    //    var s = result.ToString();

    //    return s.EndsWith(", ", StringComparison.OrdinalIgnoreCase) ?
    //        $"{s[..^2]} }}" :
    //        $"{s} }}";
    //}


    /// <summary>
    /// Get a string from a byte array in C# style (for copying it to unit tests)
    /// </summary>
    /// <param name="data">Byte array as readonly span</param>
    /// <returns>Byte array as string</returns>
    public static string GetStringFromArrayCsharpStyle(ref ReadOnlySequence<byte> data)
    {

        var result = new StringBuilder();

        result.Append("{ ");

        for (var i = 0; i < data.Length; i++)
        {
            var b = data.Slice(i, 1).FirstSpan[0];
            result.Append($"0x{b:x}, ");
        }

        var s = result.ToString();

        return s.EndsWith(", ", StringComparison.OrdinalIgnoreCase) ?
            $"{s[..^2]} }}" :
            $"{s} }}";

    }
}