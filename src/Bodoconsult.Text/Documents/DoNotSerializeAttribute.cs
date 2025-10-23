// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Do not serialize property to LDML attribute
/// </summary>
[System.AttributeUsage(System.AttributeTargets.Property)]
    
public class DoNotSerializeAttribute : System.Attribute
{
}