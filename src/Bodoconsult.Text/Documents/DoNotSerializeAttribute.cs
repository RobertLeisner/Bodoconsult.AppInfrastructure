// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Do not serialize property to LDML attribute
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
    
public class DoNotSerializeAttribute : Attribute
{
}