// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Abstractions.Delegates;
using Bodoconsult.App.Abstractions.Interfaces;

namespace Bodoconsult.App.Test.ClientCommunication.FakeImpls;

/// <summary>
/// Sample implementation of <see cref="IClientMessagingService"/>
/// </summary>
public class FakeClientMessagingService : IClientMessagingService
{

    /// <summary>
    /// Default ctor: should load all required conversion rules
    /// </summary>
    public FakeClientMessagingService()
    {
        ConversionRules.Add(nameof(TestNotification), ConvertToTestTransportLayerObject);
    }

    /// <summary>
    /// Converts a <see cref="TestNotification"/> to a <see cref="TestTransportLayerObject"/>
    /// </summary>
    /// <param name="notification">Notifications</param>
    /// <returns>A <see cref="TestTransportLayerObject"/> instance</returns>
    /// <remarks>Method should be public for unit testing</remarks>
    /// <exception cref="ArgumentException">Throws if the type of notification is not <see cref="TestNotification"/></exception>
    public object ConvertToTestTransportLayerObject(IClientNotification notification)
    {
        if (notification is not TestNotification testNotification)
        {
            throw new ArgumentException("Wrong type of exeception. TestNotification is expected.");
        }

        return new TestTransportLayerObject
        {
            Message = testNotification.Message
        };
    }

    /// <summary>
    /// All conversion rules for notifications event args to client transport level target object
    /// </summary>
    public Dictionary<string, NotificationToTargetTransferObjectDelegate> ConversionRules { get; } = new();


    /// <summary>
    /// Convert a notification into a client transport level target object
    /// </summary>
    /// <param name="notification">Current notification to send</param>
    /// <returns>Object to transfer to the client on transport level</returns>
    public object Convert(IClientNotification notification)
    {
        var typeName = notification.GetType().Name;

        var success = ConversionRules.TryGetValue(typeName, out var result);

        if (!success)
        {
            throw new ArgumentException($"Type not found: {typeName}");
        }

        return result(notification);
    }
}