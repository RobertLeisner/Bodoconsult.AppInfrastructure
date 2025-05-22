﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System;

namespace Bodoconsult.App.Windows.Network.Dhcp;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public class DhcpServerOptionIdTypeAttribute : Attribute
{
    public DhcpServerOptionIdTypes Type;

    public DhcpServerOptionIdTypeAttribute(DhcpServerOptionIdTypes type)
    {
        Type = type;
    }
}