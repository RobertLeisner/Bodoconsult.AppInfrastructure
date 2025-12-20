// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Abstractions.Delegates;
using Bodoconsult.App.Abstractions.Interfaces;
using Bodoconsult.App.GrpcBackgroundService;
using Google.Protobuf.WellKnownTypes;
using GrpcServerApp.BusinessLogic.Notifications;

namespace GrpcServerApp.Grpc.MappingServices;

/// <summary>
/// Converts internal notificatiosn to GRPC messages
/// </summary>
public class GrpcClientMessagingService: IClientMessagingService
{
    /// <summary>
    /// All conversion rules for notifications event args to client transport level target object
    /// </summary>
    public Dictionary<string, NotificationToTargetTransferObjectDelegate> ConversionRules { get; } = new();


    public GrpcClientMessagingService()
    {
        ConversionRules.Add(nameof(SimpleClientNotification), GetSimpleClientNotificationMessageDtoMessage);
    }

    /// <summary>
    /// Convert a notification into a client transport level target object
    /// </summary>
    /// <param name="notification">Current notification to send</param>
    /// <returns>Object to transfer to the client on transport level</returns>
    public object Convert(IClientNotification notification)
    {
        var notiType = notification.GetType().Name;

        var success = ConversionRules.TryGetValue(notiType, out var del);

        return !success ? null : del(notification);
    }

    /// <summary>
    /// Convert SimpleClientNotification into a SimpleClientNotificationMessage proto message. Public for unit tests
    /// </summary>
    /// <param name="notification"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public object GetSimpleClientNotificationMessageDtoMessage(IClientNotification notification)
    {
        if (notification is not SimpleClientNotification noti)
        {
            throw new ArgumentException($"{nameof(notification)} does NOT have the expected type of {nameof(SimpleClientNotification)}");
        }

        var data= new SimpleClientNotificationMessage
        {
            Message = noti.Message
        };

        var message = new ClientNotificationMessage
        {
            Dto = Any.Pack(data)
        };

        return message;
    }
}