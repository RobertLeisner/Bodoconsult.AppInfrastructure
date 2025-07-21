// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Abstractions.Interfaces;

namespace Bodoconsult.App.ClientNotifications;

/// <summary>
/// Fake implementation of <see cref="IClientLoginData"/>
/// </summary>
public class FakeLoginData : IClientLoginData
{
    /// <summary>
    /// Id of the Client
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Type of the client. 
    /// </summary>
    /// <remarks>Int data type was choosen to stay independent of an unflexible enum</remarks>
    public int Type { get; set; }
}