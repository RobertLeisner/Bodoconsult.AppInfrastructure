// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using Bodoconsult.Test.Interfaces;
using System.IO;

namespace Bodoconsult.Test;

/// <summary>
/// TestHelperBase base class for <see cref="ITestDocuHelper"/> impls
/// </summary>
public class TestHelperBase : ITestDocuHelper
{
    /// <summary>
    /// default ctor
    /// </summary>
    public TestHelperBase()
    {
        Company = "Bodoconsult GmbH";
    }


    internal string DirPath;

    /// <summary>
    /// Name of the company run the tests
    /// </summary>
    public string Company { get; set; }

    /// <summary>
    /// Path to a logo image file (JPEG or PNG)
    /// </summary>
    public string LogoPath { get; set; }

    /// <summary>
    /// Path to save the output (not used in TestHelperBase class)
    /// </summary>
    public string TargetPath
    {
        get => _targetPath;
        set
        {
            _targetPath = value;
            DirPath = new FileInfo(_targetPath).DirectoryName;
        }
    }


    /// <summary>
    /// Divider
    /// </summary>
    public const string Divider = "**************************************************************************";

    /// <summary>
    /// Divider 1
    /// </summary>
    public const string Divider1 = "__________________________________________________________________________";


    /// <summary>
    /// Short divider
    /// </summary>
    public const string ShortDivider = "*****************";

    /// <summary>
    /// Initialize helper class
    /// </summary>
    public virtual void HelperInitialize()
    {

    }

    /// <summary>
    /// Finalize helper class
    /// </summary>
    public virtual void HelperFinalize()
    {

    }

    /// <summary>
    /// Print a message in the debug window and the output file
    /// </summary>
    /// <param name="inputString"></param>
    /// <param name="array"></param>
    public virtual void PrintIt(string inputString, params object[] array)
    {

    }



    /// <summary>
    /// Print a header for the output of unit testing
    /// </summary>
    public virtual void PrintHeader(string message)
    {

    }

    /// <summary>
    /// Print divider
    /// </summary>
    public virtual void PrintDivider()
    {
 
    }

    /// <summary>
    /// Print divider 1
    /// </summary>
    public virtual void PrintDivider1()
    {

    }


    /// <summary>
    /// Print divider
    /// </summary>
    public virtual void PrintShortDivider()
    {

    }

    /// <summary>
    /// Print an empty row
    /// </summary>
    public virtual void PrintRow()
    {

    }


    /// <summary>
    /// Print a message header level 1
    /// </summary>
    /// <param name="message">message to print</param>
    /// <param name="typeName">name of the type</param>
    /// <param name="methodName">name of the calling method</param>
    public virtual void PrintMethodHeader(string message, string typeName, string methodName)
    {

    }

    /// <inheritdoc />
    public virtual void PrintMethodHeader2(string title)
    {

    }

    /// <inheritdoc />
    public virtual void PrintMethodHeader3(string message)
    {
            
    }

    /// <inheritdoc />
    public virtual void PrintClassHeader(string message, string className)
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="fileNameWithoutPath"></param>
    public virtual void PrintImage(string fileNameWithoutPath)
    {
            
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    public virtual void PrintTable(string[,] data)
    {

    }



    /// <summary>
    /// 
    /// </summary>
    public string CurrentClass { get; set; }

    /// <inheritdoc />
    public virtual void SetDefaults()
    {
            
    }

    /// <inheritdoc />
    public virtual void PrintLink(string url, string title)
    {
        var msg = $"See {title} ({url})";
        PrintIt(msg);
    }


    private string _targetPath;





}