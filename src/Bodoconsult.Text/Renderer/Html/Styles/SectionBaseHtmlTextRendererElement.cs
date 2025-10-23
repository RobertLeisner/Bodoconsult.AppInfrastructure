using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="SectionBase"/> instances
/// </summary>
public abstract class SectionBaseHtmlTextRendererElement : HtmlTextRendererElementBase
{
    private readonly SectionBase _sectionBase;

    /// <summary>
    /// Default ctor
    /// </summary>
    protected SectionBaseHtmlTextRendererElement(SectionBase sectionBase) : base(sectionBase)
    {
        _sectionBase = sectionBase;
        ClassName = sectionBase.StyleName;
    }
}