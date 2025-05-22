// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Interfaces;

namespace Bodoconsult.App.CentralServices;

/// <summary>
/// Fake implementation of <see cref="IAppDateService"/> for unit testing time dependent tasks
/// </summary>
public class FakeAppDateService : IAppDateService
{
    /// <summary>
    /// The date to be delivered by the date
    /// </summary>
    public DateTime DateTimeToDeliver { get; set; }

    /// <summary>
    /// Deliver the current date the app is running on
    /// </summary>
    public DateTime Now => DateTimeToDeliver;
}