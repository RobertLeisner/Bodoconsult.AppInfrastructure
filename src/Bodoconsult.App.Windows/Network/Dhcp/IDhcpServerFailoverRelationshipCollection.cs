// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System.Collections.Generic;

namespace Bodoconsult.App.Windows.Network.Dhcp;

public interface IDhcpServerFailoverRelationshipCollection : IEnumerable<IDhcpServerFailoverRelationship>
{
    IDhcpServer Server { get; }

    IDhcpServerFailoverRelationship GetRelationship(string relationshipName);
    void RemoveRelationship(IDhcpServerFailoverRelationship relationship);
}