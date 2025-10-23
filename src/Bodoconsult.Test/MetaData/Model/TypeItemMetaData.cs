// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using Bodoconsult.Test.Interfaces;
using System;

namespace Bodoconsult.Test.MetaData.Model;

/// <summary>
/// Meta data for a type item
/// </summary>
public class TypeItemMetaData : IMetaData
{
    /// <summary>
    /// default ctor
    /// </summary>
    public TypeItemMetaData()
    {
        Type = 'P';
    }

    /// <summary>
    /// Current type
    /// </summary>
    public Type CurrentType { get; set; }

    /// <summary>
    /// Type of item: M method, P property, E event
    /// </summary>
    public char Type { get; set; }



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
}