// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

// Copyright (c) 2020 Widauer Patrick. All rights reserved.

namespace Bodoconsult.App.Abstractions.Interfaces;

/// <summary>
/// Credential type
/// </summary>
public class CredentialType
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public CredentialType(int id, string name)
    {
        Id = id;
        Name = name;
    }

    /// <summary>
    /// The ID of the credential type
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// The cleartext name of the credential type
    /// </summary>
    public string Name { get; set; }


    /// <summary>Returns a string that represents the current object.</summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString() => $"{Id} {Name}";

    /// <summary>
    /// Generic credential type
    /// </summary>
    public static CredentialType Generic = new(0, "Generic");
}