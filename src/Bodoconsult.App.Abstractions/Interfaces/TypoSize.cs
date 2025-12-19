namespace Bodoconsult.App.Abstractions.Interfaces;

/// <summary>
/// Defines a size of an element with width and height
/// </summary>
public class TypoSize
{
    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="width">Width in cm</param>
    /// <param name="height">Height in cm</param>
    public TypoSize(double width, double height)
    {
        Width = width; 
        Height = height;
    }

    /// <summary>
    /// Width in cm
    /// </summary>
    public double Width { get; }

    /// <summary>
    /// Height in cm
    /// </summary>
    public double Height { get;  }

}