// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Reflection;

namespace Bodoconsult.App.Abstractions.Helpers;

/// <summary>
/// Helper class for <see cref="Type "/> handling
/// </summary>
public static class TypeHelper
{
    /// <summary>
    /// Tolerated difference value for numeric values being equal as decimal
    /// </summary>
    public static decimal ToleranceValueComparisons { get; set; } = new(0.00000000000001);

    /// <summary>
    /// Tolerated difference value for numeric values being equal as double
    /// </summary>
    public static double ToleranceValueComparisonsDouble { get; set; } = 0.00000000000001;

    /// <summary>
    /// Default ctor
    /// </summary>
    static TypeHelper()
    {
        CurrentAssembly = typeof(TypeHelper).Assembly;
    }

    /// <summary>
    /// The assembly the <see cref="TypeHelper"/> instance is defined in
    /// </summary>
    public static Assembly CurrentAssembly { get; }

    /// <summary>
    /// Get all types in an assembly derived from a base type or interface
    /// </summary>
    /// <param name="assembly">Assembly to check</param>
    /// <param name="baseType">Base class or interface</param>
    /// <returns>List of types derived from a base type or interface</returns>
    public static List<Type> GetTypesDerivedFrom(Assembly assembly, Type baseType)
    {
        var result = new List<Type>();

        foreach (var type in assembly.GetTypes())
        {
            if (baseType.IsAssignableFrom(type))
            {
                result.Add(type);
            }
        }

        return result;
    }

    /// <summary>
    /// Get all types in the current assembly derived from a base type or interface
    /// </summary>
    /// <param name="baseType">Base class or interface</param>
    /// <returns>List of types derived from a base type or interface</returns>
    public static List<Type> GetTypesDerivedFromCurrentAssembly(Type baseType)
    {
        return GetTypesDerivedFrom(CurrentAssembly, baseType);
    }

}