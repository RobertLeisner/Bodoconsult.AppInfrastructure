// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

namespace Bodoconsult.App.Interfaces;

/// <summary>
/// Interface for Client LoginData
/// </summary>
/// 
public interface IClientLoginData
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