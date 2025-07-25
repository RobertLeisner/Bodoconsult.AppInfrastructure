namespace Bodoconsult.App.Wpf.Documents.General;

/// <summary>
/// Types of table to be print in the document
/// </summary>
public enum TableTypes
{

    /// <summary>
    /// Normal table with borders and normal font size
    /// </summary>
    Normal,

    /// <summary>
    /// Table with no borders and normal font size
    /// </summary>
    NormalUnbordered,

    /// <summary>
    /// Table with no table header
    /// </summary>
    NormalNoHeader,

    /// <summary>
    /// Table with no table header and no borders
    /// </summary>
    NormalNoHeaderUnbordered,

    /// <summary>
    /// Table with border and smaller font size
    /// </summary>
    Small,


    /// <summary>
    /// Table with no border and smaller font size
    /// </summary>
    SmallUnbordered,


    /// <summary>
    /// Table with border, smaller font size and no table header
    /// </summary>
    SmallNoHeader,

    /// <summary>
    /// Table with no border, smaller font size and no table header
    /// </summary>
    SmallNoHeaderUnbordered,


    /// <summary>
    /// Table with border and extra small font size
    /// </summary>
    ExtraSmall,

    /// <summary>
    /// Table with no border and extra small font size
    /// </summary>
    ExtraSmallUnbordered,

    /// <summary>
    /// Table with border and extra small font size, but no table header
    /// </summary>
    ExtraSmallNoHeader,


    /// <summary>
    /// Table with no border and extra small font size and no table header
    /// </summary>
    ExtraSmallNoHeaderUnbordered
}