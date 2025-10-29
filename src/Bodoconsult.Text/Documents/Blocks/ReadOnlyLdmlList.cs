// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System;
using System.Collections.Generic;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// List for LDML text elements
/// </summary>
/// <typeparam name="T"></typeparam>
public class ReadOnlyLdmlList<T> : List<T> where T : DocumentElement
{
    private readonly object _parent;

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="parent">Parent text element</param>
    public ReadOnlyLdmlList(object parent)
    {
        _parent = parent;
    }

    /// <summary>
    /// Add an item to the list
    /// </summary>
    /// <param name="item"></param>
    public new void Add(T item)
    {
        throw new NotSupportedException("Not allowed to add items to this readonly list");
    }

    /// <summary>
    /// Add an item to the list
    /// </summary>
    /// <param name="item"></param>
    public void AddInternal(T item)
    {
        base.Add(item);
    }
}