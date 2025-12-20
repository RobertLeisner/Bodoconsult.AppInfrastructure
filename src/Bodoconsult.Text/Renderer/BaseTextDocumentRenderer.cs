// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.IO;
using System.Text;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer;

/// <summary>
/// Base implementation of a <see cref="IDocumentRenderer"/> for text based output like TXT, MD or HTML
/// </summary>
public class BaseTextDocumentRenderer : BaseDocumentRenderer, ITextDocumentRenderer
{

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="document">Document to render</param>
    public BaseTextDocumentRenderer(Document document) : base(document)
    { }

    /// <summary>
    /// Is the rendering of the styles required
    /// </summary>
    public bool IsRenderingStylesRequired { get; set; } = true;

    /// <summary>
    /// Template to place the structered text. Must contain placeholder {0} for the structured text
    /// </summary>
    public string Template { get; set; } = "{0}";

    /// <summary>
    /// The current content
    /// </summary>

    public StringBuilder Content { get; set; } = new();

    /// <summary>
    /// Current text renderer element factory
    /// </summary>
    public ITextRendererElementFactory TextRendererElementFactory { get; protected set; }

    /// <summary>
    /// Render the document
    /// </summary>
    public override void RenderIt()
    {
        var rendererElement = TextRendererElementFactory.CreateInstance(Document);
        rendererElement.RenderIt(this);
    }

    /// <summary>
    /// Get the fully rendered text
    /// </summary>
    /// <returns>Rendered text</returns>
    public virtual string GetRenderedText()
    {
        var content = Template.Replace("{0}", Content.ToString());
        return content;
    }



    /// <summary>
    /// Save the rendered document as file
    /// </summary>
    /// <param name="fileName">Full file path. Existing file will be overwritten</param>
    public override void SaveAsFile(string fileName)
    {
        File.WriteAllText(fileName, GetRenderedText());
    }
}