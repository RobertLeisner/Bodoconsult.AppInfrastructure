// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.WinForms.Interfaces;

// ReSharper disable LocalizableElement

namespace WinFormsApp1;

public sealed partial class Form1 : Form
{
    private IMainWindowViewModel _mainWindowViewModel;

    public Form1()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Inject the view model
    /// </summary>
    /// <param name="mainWindowViewModel"></param>
    public void InjectViewModel(IMainWindowViewModel mainWindowViewModel)
    {
        _mainWindowViewModel = mainWindowViewModel;
        Text = $"{_mainWindowViewModel.AppBuilder.AppGlobals.AppStartParameter.AppName} {_mainWindowViewModel.AppVersion}";

        // Binding to indexer TranslationService["contains"] is possible in WinForms
        // Added property TranslabelText to viwemodel instead
        TranslationLabel.DataBindings.Add("Text", _mainWindowViewModel, "TranslationLabelText");
    }

    private void button1_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Do something here 1");
    }

    private void button2_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Do something here 2");
    }

    /// <summary>
    /// Implement this event to shutdown your application correctly as required by your demands
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Form1_FormClosed(object sender, FormClosedEventArgs e)
    {
        _mainWindowViewModel.ShutDown();
    }
}