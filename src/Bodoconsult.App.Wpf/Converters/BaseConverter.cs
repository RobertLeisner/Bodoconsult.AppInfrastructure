// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System.Windows.Markup;

namespace Bodoconsult.App.Wpf.Converters
{
    /// <summary>
    /// Base class for converters to make it useable as markup extension
    /// Use derived converters like shown the sample below. 
    /// </summary>
    /// <example>Text={Binding Time, Converter={x:MyConverter}} </example>
    public abstract class BaseConverter : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }

}
