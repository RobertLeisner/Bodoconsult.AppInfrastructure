// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

namespace Bodoconsult.App.Wpf.Documents.Utilities;

/// <summary>
/// Helper class for getting xml for inline paragraph elements of a WPFD flowdocument
/// </summary>
public class WpfDocumentTextUtility
{
    /// <summary>
    /// Get the XAML for a bold text
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static string Bold(string content)
    {
        return $"<Run FontWeight='bold'>{content}</Run>";
    }

    /// <summary>
    /// Get the XAML for a italic text
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static string Italic(string content)
    {
        return $"<Run FontStyle='italic'>{content}</Run>";
    }

    /// <summary>
    /// Get the XAML for a colored text
    /// </summary>
    /// <param name="content"></param>
    /// <param name="brushName">Name of one the WPF default brushes like blue, red, green, yellow</param>
    /// <returns></returns>
    public static string ColoredText(string content, string brushName)
    {
        return string.Format("<Span Foreground='{1}'>{0}</Span>", content, brushName);
    }


    /// <summary>
    /// Get the XAML for a text with a colored background
    /// </summary>
    /// <param name="content"></param>
    /// <param name="brushName">Name of one the WPF default brushes like blue, red, green, yellow</param>
    /// <returns></returns>
    public static string BackgroundedText(string content, string brushName)
    {
        return string.Format("<Span Background='{1}'>{0}</Span>", content, brushName);
    }


    /// <summary>
    /// Get the XAML for a superscripted text
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static string Superscript(string content)
    {
        return $"<Run Typography.Variants='Superscript'>{content}</Run>";
    }


    /// <summary>
    /// Get the XAML for a subscripted text
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static string Subscript(string content)
    {
        return $"<Run Typography.Variants='Subscript'>{content}</Run>";
    }


    /// <summary>
    /// Get the XAML for a line break
    /// </summary>
    /// <returns></returns>
    public static string LineBreak()
    {
        return "<LineBreak/>";
    }
}