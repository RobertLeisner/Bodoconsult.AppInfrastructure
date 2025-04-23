// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System;

namespace Bodoconsult.App.Windows.Network.Dhcp;

public interface IDhcpServerOptionElement : IEquatable<IDhcpServerOptionElement>
{
    DhcpServerOptionElementType Type { get; }
    object Value { get; }
    string ValueFormatted { get; }
}