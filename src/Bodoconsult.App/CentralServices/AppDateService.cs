// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Abstractions.Interfaces;

namespace Bodoconsult.App.CentralServices;

/// <summary>
/// Current implementation of <see cref="IAppDateService"/> based on DateTime.Now()
/// </summary>
public class AppDateService: IAppDateService
{
    /// <summary>
    /// Deliver the current date the app is running on
    /// </summary>
    public DateTime Now => DateTime.Now;
}