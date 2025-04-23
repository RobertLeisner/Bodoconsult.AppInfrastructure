// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System.Collections.Generic;

namespace Bodoconsult.App.Windows.Network.Dhcp;

public interface IDhcpServerClassCollection : IEnumerable<IDhcpServerClass>
{
    IDhcpServer Server { get; }

    IDhcpServerClass GetClass(string name);
}