// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System.Xml;

namespace Bodoconsult.Test.MetaData.Model;

/// <summary>
/// Contains the XML documentaion for an assembly
/// </summary>
public class AssemblyDocumentation
{
    /// <summary>
    /// File name of the assembly
    /// </summary>
    public string AssemblyFileName { get; set; }


    /// <summary>
    /// The loaded XML documentation
    /// </summary>
    public XmlDocument Documentation { get; set; }



}