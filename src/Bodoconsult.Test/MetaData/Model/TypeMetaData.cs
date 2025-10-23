// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using Bodoconsult.Test.Interfaces;
using System;
using System.Collections.Generic;

namespace Bodoconsult.Test.MetaData.Model;

/// <summary>
/// Meta data for a type
/// </summary>
public class TypeMetaData : IMetaData
{
    /// <summary>
    /// default ctor
    /// </summary>
    public TypeMetaData()
    {
        TypeItemMetaDatas = new List<TypeItemMetaData>();         
    }



    /// <summary>
    /// Fully qualified name of the type (needed for classes, properties, fields and methods)
    /// </summary>
    public string FullName { get; set; }


    /// <summary>
    /// Fully qualified name of the base type
    /// </summary>
    public string BaseTypeFullName { get; set; }

    /// <summary>
    /// Fully qualified name of the base type level 2
    /// </summary>
    public string BaseTypeFullName2 { get; set; }



    /// <summary>
    /// Current type
    /// </summary>
    public Type CurrentType { get; set; }


    /// <summary>
    /// Name of the type
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Summary of the type
    /// </summary>
    public string Summary { get; set; }

    /// <inheritdoc />
    public string Remarks { get; set; }

    /// <summary>
    /// Example for the type
    /// </summary>
    public string Example { get; set; }

    /// <inheritdoc />
    public string DataType { get; set; }

    /// <inheritdoc />
    public string Code { get; set; }

    /// <summary>
    /// Item of the type like methods, events and properties
    /// </summary>
    public IList<TypeItemMetaData> TypeItemMetaDatas { get; set; }

    /// <summary>
    /// File name of a JSON sample object file
    /// </summary>
    public string JsonContentFilename { get; set; }
}