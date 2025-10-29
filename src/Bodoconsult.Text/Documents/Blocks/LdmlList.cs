// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Bodoconsult.Text.Documents;

/// <summary>
/// List for LDML text elements
/// </summary>
/// <typeparam name="T"></typeparam>
public class LdmlList<T> : List<T> where T : DocumentElement
{
    private readonly object _parent;

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="parent">Parent text element</param>
    public LdmlList(object parent)
    {
        _parent = parent;
    }

    /// <summary>
    /// Add an item to the list
    /// </summary>
    /// <param name="item"></param>
    public new void Add(T item)
    {
        item.Parent = (DocumentElement)_parent;
        base.Add(item);
    }

    /// <summary>
    /// Copy instance to a new instance
    /// </summary>
    /// <returns>Returns copied list</returns>
    public ReadOnlyLdmlList<T> ToList()
    {
        var result = new ReadOnlyLdmlList<T>(_parent);
        result.AddRange(this);
        return result;
    }

    /// <summary>
    /// Copy instance to a new instance
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns>Returns copied list</returns>
    public ReadOnlyLdmlList<T> ToList(Func<T, bool> predicate)
    {
        var result = new ReadOnlyLdmlList<T>(_parent);
        result.AddRange(this.Where(predicate));
        return result;
    }

    /// <summary>
    /// Copy instance to a new instance
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns>Returns copied list</returns>
    public ReadOnlyLdmlList<TTarget> ToList<TTarget>(Func<T, bool> predicate) where TTarget : DocumentElement
    {
        var result = new ReadOnlyLdmlList<TTarget>(_parent);

        foreach (var item in this.Where(predicate))
        {
            if (item is TTarget target)
            {
                result.AddInternal(target);
            }
        }
        return result;
    }
}