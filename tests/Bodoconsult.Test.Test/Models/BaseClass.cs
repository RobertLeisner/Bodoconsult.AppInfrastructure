// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

namespace Bodoconsult.Test.Test.Models;

/// <summary>
/// Base class
/// </summary>
internal class BaseClass : IBaseClass
{
    /// <inheritdoc />
    public string Property1 { get; set; }

    /// <summary>
    /// Base class field 1
    /// </summary>
    public string Field1;
}