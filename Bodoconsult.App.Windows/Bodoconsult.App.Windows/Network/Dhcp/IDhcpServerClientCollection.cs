// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System.Collections.Generic;

namespace Bodoconsult.App.Windows.Network.Dhcp;

public interface IDhcpServerClientCollection : IEnumerable<IDhcpServerClient>
{
    IDhcpServer Server { get; }

    void RemoveClient(IDhcpServerClient client);
}