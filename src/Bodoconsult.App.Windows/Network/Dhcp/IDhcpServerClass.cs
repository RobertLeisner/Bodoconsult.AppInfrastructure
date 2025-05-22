// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System.Collections.Generic;

namespace Bodoconsult.App.Windows.Network.Dhcp;

public interface IDhcpServerClass
{
    string Comment { get; }
    byte[] Data { get; }
    string DataText { get; }
    IEnumerable<IDhcpServerOptionValue> GlobalOptionValues { get; }
    bool IsUserClass { get; }
    bool IsVendorClass { get; }
    string Name { get; }
    IEnumerable<IDhcpServerOption> Options { get; }
    IDhcpServer Server { get; }
}