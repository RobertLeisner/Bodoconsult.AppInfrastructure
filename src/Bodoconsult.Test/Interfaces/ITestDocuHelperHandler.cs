// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System.Collections.Generic;
using System.Data;

namespace Bodoconsult.Test.Interfaces;

/// <summary>
/// Interface for printing test handler output to different targets
/// </summary>
public interface ITestDocuHelperHandler
{


    /// <summary>
    /// Name of the company run the tests
    /// </summary>
    string Company { get; set; }

    /// <summary>
    /// Path to a logo image file (JPEG or PNG)
    /// </summary>
    string LogoPath { get; set; }

    /// <summary>
    /// Namespaces ignored for getting class and method names via reflection
    /// </summary>
    IList<string> IgnoredNamespaces { get; set; }

    /// <summary>
    /// Types ignored for getting class and method names via reflection
    /// </summary>
    IList<string> IgnoredTypes { get; set; }

    /// <summary>
    /// Path to save the output (not used in TestHelperBase class)
    /// </summary>
    string TargetPath { get; set; }


    /// <summary>
    /// Work do be done before tests run
    /// </summary>
    void HelperInitialize();

    /// <summary>
    /// Final work to be done in the testhelper class
    /// </summary>
    void HelperFinalize();


    /// <summary>
    /// Print a message in the debug window and the output file
    /// </summary>
    /// <param name="inputString"></param>
    /// <param name="array"></param>
    void PrintIt(string inputString, params object[] array);

    /// <summary>
    /// Print a header for the output of unit testing
    /// </summary>
    void PrintHeader(string message);

    /// <summary>
    /// Print a header for the output of unit testing
    /// </summary>
    /// <param name="message"></param>
    /// <param name="array"></param>
    void PrintHeader(string message, params object[] array);

    /// <summary>
    /// Print divider
    /// </summary>
    void PrintDivider();

    /// <summary>
    /// Print divider 1
    /// </summary>
    void PrintDivider1();

    /// <summary>
    /// Print divider
    /// </summary>
    void PrintShortDivider();

    /// <summary>
    /// Print an empty row
    /// </summary>
    void PrintRow();

    /// <summary>
    /// Print a method headerlevel 1
    /// </summary>
    /// <param name="message">message to print</param>
    void PrintMethodHeader(string message);

    /// <summary>
    /// Print a method headerlevel 2
    /// </summary>
    /// <param name="message">message to print</param>
    /// <param name="array"></param>
    void PrintMethodHeader(string message, params object[] array);

    /// <summary>
    /// Print a method headerlevel 2
    /// </summary>
    /// <param name="message">message to print</param>
    void PrintMethodHeader2(string message);

    /// <summary>
    /// Print a method headerlevel 2
    /// </summary>
    /// <param name="message">message to print</param>
    /// <param name="array"></param>
    void PrintMethodHeader2(string message, params object[] array);

    /// <summary>
    /// Print a method headerlevel 3
    /// </summary>
    /// <param name="message">message to print</param>
    void PrintMethodHeader3(string message);

    /// <summary>
    /// Print a method headerlevel 3
    /// </summary>
    /// <param name="message">message to print</param>
    /// <param name="array"></param>
    void PrintMethodHeader3(string message, params object[] array);


    /// <summary>
    /// Print a header for a testing class
    /// </summary>
    /// <param name="message">message to print</param>
    void PrintClassHeader(string message);

    /// <summary>
    /// Print a header for a testing class
    /// </summary>
    /// <param name="message">message to print</param>
    /// <param name="array"></param>
    void PrintClassHeader(string message, params object[] array);

    /// <summary>
    /// Print all fields and properties with current values
    /// </summary>
    /// <param name="data"></param>
    /// <param name="message"></param>
    void PrintObjectData(object data, string message);

    /// <summary>
    /// Print objects in a list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    /// <param name="message"></param>
    void PrintListData<T>(IList<T> data, string message);

    /// <summary>
    /// Start watch
    /// </summary>
    void StartWatch();

    /// <summary>
    /// Stop watch and print needed time to output
    /// </summary>
    void StopWatch();

    /// <summary>
    /// Add a image to the output. Image itselft has to be created at the returned path separately.
    /// </summary>
    /// <returns>path of the new image</returns>
    string PrintImage();

    /// <summary>
    /// Add a debug window output
    /// </summary>
    void AddDebugWindowOutput();


    /// <summary>
    /// Add a HTML file output
    /// </summary>
    /// <param name="outputFileName">target filename for the HTML file</param>
    void AddHtmlOutput(string outputFileName);

    ///// <summary>
    ///// Add a XPS file output
    ///// </summary>
    ///// <param name="outputFileName"></param>
    //void AddXpsOutput(string outputFileName);

    ///// <summary>
    ///// Add a Pdf file output
    ///// </summary>
    ///// <param name="outputFileName"></param>
    //void AddPdfOutput(string outputFileName);


    /// <summary>
    /// Print a table to the output
    /// </summary>
    /// <param name="data">data to print</param>
    void PrintTable(string[,] data);


    /// <summary>
    /// Print a double array as table to the output
    /// </summary>
    /// <param name="data">array to print</param>
    void PrintTable(double[,] data);


    /// <summary>
    /// Print a double array as table to the output
    /// </summary>
    /// <param name="data">array to print</param>
    void PrintTable(DataTable data);


    /// <summary>
    /// Print a vector to the ouputs
    /// </summary>
    /// <param name="vector">double array with values to print</param>
    void PrintVector(double[] vector);

    /// <summary>
    /// Print a link to the default
    /// </summary>
    /// <param name="url"></param>
    /// <param name="title"></param>
    void PrintLink(string url, string title);

    /// <summary>
    /// Get or set the current styling class (used only for HTML / CSS output)
    /// </summary>
    string CurrentClass { set; }

    /// <summary>
    /// Set formatting back to default
    /// </summary>
    void SetDefaults();

    /// <summary>
    /// Remove all PNG images in the target directory
    /// </summary>
    void ClearTargetDirectoryImages();

    /// <summary>
    /// Get the path for the next image
    /// </summary>
    /// <returns></returns>
    string GetNextImageName();

}