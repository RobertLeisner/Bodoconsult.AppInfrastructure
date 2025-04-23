// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

namespace Bodoconsult.App.Test.ClientCommunication.FakeImpls;

/// <summary>
/// Sample object to transfer to the client via any transportation technology like GRPC etc.
/// </summary>
public class TestTransportLayerObject
{
    /// <summary>
    /// Any message to transfer to the client
    /// </summary>
    public string Message { get; set; }
}