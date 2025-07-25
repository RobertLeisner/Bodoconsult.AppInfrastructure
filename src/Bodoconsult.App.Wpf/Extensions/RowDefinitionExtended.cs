// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Windows;
using System.Windows.Controls;

namespace Bodoconsult.App.Wpf.Extensions;

/// <summary>
/// Extended row definition regarding visibility
/// </summary>
public class RowDefinitionExtended : RowDefinition
{
    /// <summary>
    /// Visibility dependency property
    /// </summary>
    public static DependencyProperty VisibilityProperty;

    /// <summary>
    /// Visibility
    /// </summary>
    public Visibility Visibility
    {
        get => (Visibility)GetValue(VisibilityProperty);
        set => SetValue(VisibilityProperty, value);
    }

    /// <summary>
    /// Default ctor
    /// </summary>
    static RowDefinitionExtended()
    {
        VisibilityProperty = DependencyProperty.Register("Visibility",
            typeof(Visibility),
            typeof(RowDefinitionExtended),
            new PropertyMetadata(true, OnVisibleChanged));

        HeightProperty.OverrideMetadata(typeof(RowDefinitionExtended),
            new FrameworkPropertyMetadata(new GridLength(1, GridUnitType.Star), null,
                CoerceHeight));

        MinHeightProperty.OverrideMetadata(typeof(RowDefinitionExtended),
            new FrameworkPropertyMetadata((double)0, null,
                CoerceMinHeight));
    }

    /// <summary>
    /// Set visibility
    /// </summary>
    /// <param name="obj">Dependecy object</param>
    /// <param name="isVisible">Is visible? True or false</param>
    public static void SetVisible(DependencyObject obj, bool isVisible)
    {
        obj.SetValue(VisibilityProperty, isVisible);
    }

    /// <summary>
    /// Get visibility
    /// </summary>
    /// <param name="obj">Dependecy object</param>
    /// <returns>Is visible? True or false</returns>
    public static Visibility GetVisible(DependencyObject obj)
    {
        return (Visibility)obj.GetValue(VisibilityProperty);
    }

    private static void OnVisibleChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
    {
        obj.CoerceValue(HeightProperty);
        obj.CoerceValue(MinHeightProperty);
    }

    /// <summary>
    /// Coerce height
    /// </summary>
    /// <param name="obj">Dependecy object</param>
    /// <param name="nValue">Height</param>
    /// <returns>RowDefinitionExtended instance</returns>
    public static object CoerceHeight(DependencyObject obj, object nValue)
    {
        return ((RowDefinitionExtended)obj).Visibility == Visibility.Visible ? nValue : new GridLength(0);
    }

    /// <summary>
    /// Coerce minimum height
    /// </summary>
    /// <param name="obj">Dependecy object</param>
    /// <param name="nValue">Height</param>
    /// <returns>RowDefinitionExtended instance</returns>
    public static object CoerceMinHeight(DependencyObject obj, object nValue)
    {
        return ((RowDefinitionExtended)obj).Visibility == Visibility.Visible ? nValue : (double)0;
    }
}