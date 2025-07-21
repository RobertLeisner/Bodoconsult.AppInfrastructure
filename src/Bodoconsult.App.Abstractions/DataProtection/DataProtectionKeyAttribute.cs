// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.App.Abstractions.DataProtection;

/// <summary>
/// Attribute to mark a property as key property for entity identification used by entity data protection
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public class DataProtectionKeyAttribute : Attribute
{ }