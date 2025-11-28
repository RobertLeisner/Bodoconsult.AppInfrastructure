// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Abstractions.Interfaces;
using Bodoconsult.App.WinForms.AppStarter.Forms.ViewModel;

namespace WinFormsApp1.App;

/// <summary>
/// ViewModel for alternative main window Form1
/// </summary>
public class WinFormsApp1MainWindowViewModel : MainWindowViewModel
{
    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="listener">Current event listener</param>
    /// <param name="translationService">Translation service</param>
    public WinFormsApp1MainWindowViewModel(IAppEventListener listener,  II18N translationService) : base(listener, translationService)
    { }
    
    /// <summary>
    /// Create the main form of the application
    /// </summary>
    /// <returns></returns>
    public override Form CreateForm()
    {
        var f = new Form1
        {
            Visible = true,
            WindowState = FormWindowState.Normal
        };
        f.InjectViewModel(this);
        return f;
    }

    /// <summary>
    /// Property for binding to Text prop of label TranslationLabel
    /// </summary>
    public string TranslationLabelText => TranslationService.Translate("Contains");
}

