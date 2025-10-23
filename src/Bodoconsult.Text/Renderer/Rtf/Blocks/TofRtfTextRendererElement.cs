// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Blocks;

/// <summary>
/// Rtf rendering element for <see cref="Tof"/> instances
/// </summary>
public class TofRtfTextRendererElement : ToxRtfTextRendererElementBase
{
    private readonly Tof _tof;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TofRtfTextRendererElement(Tof tof) : base(tof)
    {
        _tof = tof;
        ClassName = tof.StyleName;
    }

    ///// <summary>
    ///// Render the element
    ///// </summary>
    ///// <param name="renderer">Current renderer</param>
    //public override void RenderIt(ITextDocumentRender renderer)
    //{
    //    // Get the content of all inlines as string
    //    var sb = new StringBuilder();

    //    var style = (ParagraphStyleBase)renderer.Styleset.FindStyle(_tof.StyleName);
    //    renderer.Content.Append($"\\pard\\plain\\q{renderer.Styleset.GetIndexOfStyle(Block.StyleName)}{RtfHelper.GetFormatSettings(style, renderer.Styleset)}{{");

    //    DocumentRendererHelper.RenderInlineChildsToRtf(renderer, sb, Block.ChildInlines);

    //    CleanRtfString(sb);

    //    renderer.Content.Append($"{{\\field{{\\*\\fldinst HYPERLINK \"#{_tof.TagName}\"}}{{\\{sb}}}}}");
    //    renderer.Content.Append($"\\par}}{Environment.NewLine}");
    //}
}