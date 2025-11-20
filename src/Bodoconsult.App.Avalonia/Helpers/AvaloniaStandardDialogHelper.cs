// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Avalonia.Threading;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using System;
using System.Diagnostics;
using Tmds.DBus.Protocol;

namespace Bodoconsult.App.Avalonia.Helpers;

/// <summary>
/// Helper class for OS standard dialogs for WPF
/// </summary>
public static class AvaloniaStandardDialogHelper
{
    /// <summary>
    /// Shows a MessageBox with an OK button
    /// </summary>
    /// <param name="caption">Caption to show</param>
    /// <param name="message">Message to show</param>
    /// <returns>Task</returns>
    public static async Task ShowOkMessageBox(string caption, string message)
    {
        await Dispatcher.UIThread.InvokeAsync(async () =>
        {
            try
            {
                var box = MessageBoxManager.GetMessageBoxStandard(caption, message, ButtonEnum.Ok, Icon.Info);
                await box.ShowAsync();
            }
            catch (Exception e)
            {
                //Debug.Print(e.ToString());
            }

        });
    }

    /// <summary>
    /// Show a info message box to the user to answer with yes or no
    /// </summary>
    /// <param name="caption">dialog title</param>
    /// <param name="question">Question to ask the user. User must answer with yes or no</param>
    /// <returns></returns>
    public static async Task<ButtonResult> ShowInfo(string caption, string question)
    {
        var result = await Dispatcher.UIThread.InvokeAsync(async () =>
        {
            try
            {
                var box = MessageBoxManager.GetMessageBoxStandard(caption, question, ButtonEnum.YesNo, Icon.Info);
                return await box.ShowAsync();
            }
            catch (Exception e)
            {
                Debug.Print(e.ToString());
                return ButtonResult.None;
            }

        });

        return result;
    }

    //    /// <summary>
    //    /// Select a folder and returns the path to the selected folder
    //    /// </summary>
    //    /// <returns>null or path to the selected folder</returns>
    //    public static string OpenFolder()
    //    {
    //        var dialog = new CommonOpenFileDialog { IsFolderPicker = true };
    //        return dialog.ShowDialog() == CommonFileDialogResult.Ok ? dialog.FileNames.FirstOrDefault() : null;
    //    }


    //    /// <summary>
    //    /// Select a file and returns the path to the selected file
    //    /// </summary>
    //    /// <param name="extensions">List of all extensions to be listed in the dialog *.jpg, *.png</param>
    //    /// <returns>null or path to the selected file</returns>
    //    public static string OpenFile(string extensions)
    //    {
    //        var dialog = new CommonOpenFileDialog { IsFolderPicker = false };

    //        dialog.Filters.Add(new CommonFileDialogFilter(extensions, extensions));

    //        return dialog.ShowDialog() == CommonFileDialogResult.Ok ? dialog.FileNames.FirstOrDefault() : null;
    //    }


    //    /// <summary>
    //    /// Select a file and returns the path to the selected file
    //    /// </summary>
    //    /// <param name="displayName">Display name of all file extension for all listed files in the dialog, i.e. "Images"</param>
    //    /// <param name="extensions">List of all extensions to be listed in the dialog *.jpg, *.png</param>
    //    /// <returns>null or path to the selected file</returns>
    //    public static string OpenFile(string displayName, string extensions)
    //    {
    //        var dialog = new CommonOpenFileDialog { IsFolderPicker = false };

    //        dialog.Filters.Add(new CommonFileDialogFilter(displayName, extensions));

    //        return dialog.ShowDialog() == CommonFileDialogResult.Ok ? dialog.FileNames.FirstOrDefault() : null;
    //    }



    //    /// <summary>
    //    /// Select a file and returns the path to the selected file
    //    /// </summary>
    //    /// <returns>null or path to the selected file</returns>
    //    public static string OpenFile()
    //    {
    //        var dialog = new CommonOpenFileDialog { IsFolderPicker = false };
    //        return dialog.ShowDialog() == CommonFileDialogResult.Ok ? dialog.FileNames.FirstOrDefault() : null;
    //    }

    //    /// <summary>
    //    /// Select multiple files and return the paths to the selected files
    //    /// </summary>
    //    /// <returns>null or path to the selected files</returns>
    //    public static IEnumerable<string> OpenMultipleFiles()
    //    {
    //        var dialog = new CommonOpenFileDialog { IsFolderPicker = false };
    //        return dialog.ShowDialog() == CommonFileDialogResult.Ok ? dialog.FileNames : null;
    //    }


    //    /// <summary>
    //    /// Select a path to save a file
    //    /// </summary>
    //    /// <returns>null or path to the selected file</returns>
    //    public static string SaveFile()
    //    {
    //        var dialog = new CommonSaveFileDialog();
    //        return dialog.ShowDialog() == CommonFileDialogResult.Ok ? dialog.FileName : null;
    //    }


    //    /// <summary>
    //    /// Select a path to save a file
    //    /// </summary>
    //    /// <param name="extensions">List of all extensions to be listed in the dialog *.jpg, *.png</param>
    //    /// <returns>null or path to the selected file</returns>
    //    public static string SaveFile(string extensions)
    //    {
    //        var dialog = new CommonSaveFileDialog();
    //        dialog.Filters.Add(new CommonFileDialogFilter(extensions, extensions));
    //        return dialog.ShowDialog() == CommonFileDialogResult.Ok ? dialog.FileName : null;
    //    }


    //    /// <summary>
    //    /// Select a path to save a file
    //    /// </summary>
    //    /// <param name="displayName">Display name of all file extension for all listed files in the dialog, i.e. "Images"</param>
    //    /// <param name="extensions">List of all extensions to be listed in the dialog i.e. "*.jpg, *.png"</param>
    //    /// <returns>null or path to the selected file</returns>
    //    public static string SaveFile(string displayName, string extensions)
    //    {
    //        var dialog = new CommonSaveFileDialog();
    //        dialog.Filters.Add(new CommonFileDialogFilter(extensions, extensions));
    //        return dialog.ShowDialog() == CommonFileDialogResult.Ok ? dialog.FileName : null;
    //    }

    //    /// <summary>
    //    /// Show a warning message box
    //    /// </summary>
    //    /// <param name="title">dialog title</param>
    //    /// <param name="question">Question to ask the user. User must answer with yes or no</param>
    //    /// <returns></returns>
    //    public static MessageBoxResult ShowWarning(string title, string question)
    //    {
    //        return MessageBox.Show(question, title, MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
    //    }

    //    /// <summary>
    //    /// Show a question message box to the user to answer with yes or no
    //    /// </summary>
    //    /// <param name="title">dialog title</param>
    //    /// <param name="question">Question to ask the user. User must answer with yes or no</param>
    //    /// <returns></returns>
    //    public static MessageBoxResult ShowQuestion(string title, string question)
    //    {
    //        return MessageBox.Show(question, title, MessageBoxButton.YesNo, MessageBoxImage.Question);
    //    }


    //    /// <summary>
    //    /// Show a info message box to the user to answer with yes or no
    //    /// </summary>
    //    /// <param name="title">dialog title</param>
    //    /// <param name="question">Question to ask the user. User must answer with yes or no</param>
    //    /// <returns></returns>
    //    public static MessageBoxResult ShowInfo(string title, string question)
    //    {
    //        return MessageBox.Show(question, title, MessageBoxButton.YesNo, MessageBoxImage.Information);
    //    }

}