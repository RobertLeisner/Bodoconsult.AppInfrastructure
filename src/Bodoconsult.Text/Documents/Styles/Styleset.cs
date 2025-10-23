﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bodoconsult.App.Abstractions.Interfaces;
using Bodoconsult.Text.Extensions;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Styleset for a document
/// </summary>
public class Styleset : Block
{
    /// <summary>
    ///  Default font name
    /// </summary>
    public const string DefaultFontName = "Calibri";

    /// <summary>
    ///  Default font name
    /// </summary>
    public const string DefaultFontNameMonoSpaced = "Courier New";

    /// <summary>
    /// Default color for borders and fonts
    /// </summary>
    public static Color DefaultColor = TypoColors.Black.ToLdmlColor();

    /// <summary>
    /// Default border width in pt
    /// </summary>
    public const int DefaultBorderWidth = 1;

    /// <summary>
    /// Default padding width in pt
    /// </summary>
    public const int DefaultPaddingWidth = 6;

    /// <summary>
    /// Default padding width in pt
    /// </summary>
    public const int DefaultTablePaddingWidth = 2;

    /// <summary>
    /// Default font size in pt
    /// </summary>
    public const int DefaultFontSize = 12;

    /// <summary>
    /// Default margin left. Default 1cm = 28.3pt
    /// </summary>
    public static double DefaultMarginLeft { get; set; } = 28.3;

    /// <summary>
    /// Default margin right. Default 1cm = 28.3pt
    /// </summary>
    public static double DefaultMarginRight { get; set; } = 28.3;

    private List<string> _keys;

    /// <summary>
    /// Current style dictionary. Do not use directly. Public for testing only
    /// </summary>
    public readonly Dictionary<string, StyleBase> StyleDictionary = new();

    /// <summary>
    /// Default ctor
    /// </summary>
    public Styleset()
    {
        IsSingleton = true;
    }

    /// <summary>
    /// Fonts list used i.e. for RTF rendering. Filled by the renderer instance
    /// </summary>
    [DoNotSerialize]
    public List<string> Fonts { get;  }= new();


    /// <summary>
    /// List of all colors i.e. for RTF rendering. Filled by the renderer instance
    /// </summary>
    [DoNotSerialize]
    public List<Color> Colors { get; } = new();

    /// <summary>
    /// Get the index of the stylename
    /// </summary>
    /// <param name="styleName">Stylename</param>
    /// <returns>Index of the stylename</returns>
    public int GetIndexOfStyle(string styleName)
    {
        _keys ??= StyleDictionary.Keys.ToList();
        var index = _keys.IndexOf(styleName);
        return index;
    }

    /// <summary>
    /// Get the index of a color in the color table
    /// </summary>
    /// <param name="color">Color</param>
    /// <returns>Index of the color in the color table</returns>
    public int GetIndexOfColor(Color color)
    {
        var c = Colors.FirstOrDefault(x => x.R == color.R &&
                                           x.G == color.G &&
                                           x.B == color.B &&
                                           x.A == color.A);

        if (c == null)
        {
            return 0;
        }

        var index = Colors.IndexOf(color);
        return index;
    }

    /// <summary>
    /// Add the current element to a document defined in LDML (Logical document markup language)
    /// </summary>
    /// <param name="stringBuilder">StringBuilder instance to create the LDML in</param>
    /// <param name="indent">Current indent</param>
    public override void ToLdmlString(StringBuilder stringBuilder, string indent)
    {
        AddTagWithAttributes(indent, "Styleset", stringBuilder);

        // Add the blocks now
        foreach (var block in Blocks)
        {
            block.ToLdmlString(stringBuilder, $"{indent}{Indentation}");
        }

        stringBuilder.AppendLine($"{indent}</Styleset>");
    }

    /// <summary>
    /// Add a block element
    /// </summary>
    /// <param name="block">Block element to add</param>
    public override void AddBlock(Block block)
    {
        var type = block.GetType();

        if (block is not StyleBase sb)
        {
            throw new ArgumentException($"Type {type.Name} not allowed to be added to a styleset");
        }

        Blocks.Add(block);
        block.Parent = this;

        StyleDictionary.Add(block.GetType().Name, sb);
    }

    /// <summary>
    /// Find a style
    /// </summary>
    /// <param name="name">Nme of the style to find</param>
    /// <returns>Found style or null</returns>
    public StyleBase FindStyle(string name)
    {
        var result = StyleDictionary.TryGetValue(name, out var sb);
        return result ? sb : null;
    }
}