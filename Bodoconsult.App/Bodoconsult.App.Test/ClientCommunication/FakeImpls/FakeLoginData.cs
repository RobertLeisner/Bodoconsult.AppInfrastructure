// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Interfaces;

namespace Bodoconsult.App.Test.ClientCommunication.FakeImpls;

/// <summary>
/// Fake implementation of <see cref="IClientLoginData"/>
/// </summary>
internal class FakeLoginData : IClientLoginData
{
    /// <summary>
    /// Id of the Client
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Type of the client. 
    /// </summary>
    /// <remarks>Int data type was choosen to stay independent from an unflexible enum.</remarks>
    public int Type { get; set; }
}