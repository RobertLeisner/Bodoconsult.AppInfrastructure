// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Rtf.Blocks;

/// <summary>
/// Rtf rendering element for <see cref="Toe"/> instances
/// </summary>
public class ToeRtfTextRendererElement : ToxRtfTextRendererElementBase
{
    private readonly Toe _toe;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ToeRtfTextRendererElement(Toe toe) : base(toe)
    {
        _toe = toe;
        ClassName = toe.StyleName;
    }

    ///// <summary>
    ///// Render the element
    ///// </summary>
    ///// <param name="renderer">Current renderer</param>
    //public override void RenderIt(ITextDocumentRender renderer)
    //{
    //    // Get the content of all inlines as string
    //    var sb = new StringBuilder();

    //    var style = (ParagraphStyleBase)renderer.Styleset.FindStyle(_toe.StyleName);
    //    renderer.Content.Append($"\\pard\\plain\\q{renderer.Styleset.GetIndexOfStyle(Block.StyleName)}{RtfHelper.GetFormatSettings(style, renderer.Styleset)}{{");

    //    DocumentRendererHelper.RenderInlineChildsToRtf(renderer, sb, Block.ChildInlines);

    //    CleanRtfString(sb);

    //    renderer.Content.Append($"{{\\field{{\\*\\fldinst HYPERLINK \"#{_toe.TagName}\"}}{{\\{sb}}}}}");
    //    renderer.Content.Append($"\\par}}{Environment.NewLine}");
    //}
}