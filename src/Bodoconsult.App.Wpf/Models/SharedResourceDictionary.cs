﻿using System.ComponentModel;
using System.Windows;

namespace Bodoconsult.App.Wpf.Models
{

    /// <summary>
    /// Resource dictionary which loads each resource key only once
    /// </summary>
    public class SharedResourceDictionary : ResourceDictionary
    {
        /// <summary>
        /// Internal cache of loaded dictionaries 
        /// </summary>
        public static Dictionary<Uri, ResourceDictionary> SharedDictinaries = new Dictionary<Uri, ResourceDictionary>();

        /// <summary>
        /// Local member of the source uri
        /// </summary>
        private Uri _sourceUri;

        private static bool IsInDesignMode
        {
            get
            {
                return (bool)DependencyPropertyDescriptor.FromProperty(DesignerProperties.IsInDesignModeProperty,
                                                                       typeof(DependencyObject)).Metadata.DefaultValue;
            }
        }

        /// <summary>
        /// Gets or sets the uniform resource identifier (URI) to load resources from.
        /// </summary>
        public new Uri Source
        {
            get
            {
                return IsInDesignMode ? base.Source : _sourceUri;
            }
            set
            {
                if (!IsInDesignMode)
                {
                    //try
                    //{
                        base.Source = value;
                    //}
                    //catch
                    //{
                    //    // ignored
                    //}

                    return;
                }
                _sourceUri = value;
                if (!SharedDictinaries.ContainsKey(value))
                {
                    try
                    {
                        //If the dictionary is not yet loaded, load it by setting
                        //the source of the base class
                        base.Source = value;
                    }
                    catch
                    {
                        //only throw exception @runtime to avoid "Exception has been 
                        //thrown by the target of an invocation."-Error@DesignTime
                        if (!IsInDesignMode)
                            throw;
                    }
                    SharedDictinaries.Add(value, this);
                }
                else
                {
                    MergedDictionaries.Add(SharedDictinaries[value]);
                }
            }
        }
    }



}
