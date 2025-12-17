// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


namespace Bodoconsult.App.Windows.Crypto.Hashing;

/// <summary>
/// Hashing options
/// </summary>
public sealed class HashingOptions
{
    /// <summary>
    /// Number of hashing iterations
    /// </summary>
    public int Iterations { get; set; } = 10000;
}