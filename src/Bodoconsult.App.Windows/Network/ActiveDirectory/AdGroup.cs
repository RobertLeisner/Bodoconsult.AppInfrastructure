﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System.Collections.Generic;
using System.Runtime.Versioning;

namespace Bodoconsult.App.Windows.Network.ActiveDirectory;

/// <summary>
/// Represents a AD groups
/// </summary>
[SupportedOSPlatform("windows")]
public class AdGroup:  IAdObject
{
    /// <summary>
    /// default ctor
    /// </summary>
    public AdGroup()
    {
        Members = new List<IAdObject>();
    }

    /// <summary>
    /// the distinguished name of the group
    /// </summary>
    public string DistinguishedName { get; set; }


    /// <summary>
    /// LDAP path to the group
    /// </summary>
    public string Path { get; set; }

    /// <summary>
    /// Name of the group
    /// </summary>
    public string Name { get; set; }


    /// <summary>
    /// Members of the group
    /// </summary>
    public IList<IAdObject> Members { get; set; }

    /// <summary>
    /// Type of the current AD group
    /// </summary>
    public AdGroupType GroupType { get; set; }



}