namespace Bodoconsult.App.Abstractions.Interfaces;

/// <summary>
/// Paper size
/// </summary>
public class TypoPaperSize
{
    /// <summary>
    /// A name for the papersize like A4. Default A4
    /// </summary>
    public string PaperFormatName { get; set; } = "A4";

    /// <summary>
    /// Size of the paper. Default: width 21 cm height 29,7 cm (=A4 portrait)
    /// </summary>
    public TypoSize Size { get; set; } = new(21, 29.7);
}