// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Diagnostics;
using Grpc.Net.Client;
using GrpcServerApp;

namespace GrpcServerApps.Tests;

public class GrpcServerServerStreamingTests
{
    private readonly GrpcChannel _channel;

    public GrpcServerServerStreamingTests()
    {
        // Start the server
        string[] args = [];

        // ToDo replace starting Main() with TestServer from Microsoft.AspNetCore
        // Run GRPC in a separate thread
        var thread = new Thread(() =>
        {
            try
            {
                Program.Main(args);
            }
            catch (Exception e)
            {
                Debug.Print(e.ToString());
            }

        })
        {
            IsBackground = true
        };
        thread.Start();

        Task.Delay(5000).Wait();

        _channel = GrpcChannel.ForAddress("http://localhost:50051");

    }

    [OneTimeTearDown]
    public void Cleanup()
    {
        try
        {
            _channel.ShutdownAsync().Wait(5000);
            _channel.Dispose();
        }
        catch (Exception e)
        {
            Debug.Print(e.ToString());
        }

        try
        {
            Program.Shutdown();
        }
        catch (Exception e)
        {
            Debug.Print(e.ToString());
        }

    }


    [SetUp]
    public void Setup()
    {
    }


    [Test]
    public void StartClientNotificationChannel_ReceiveNotifications_Sucess()
    {
        // Arrange 

        var sc = new ServerStreamingServerChannel(_channel);

        Task.Run(() =>
        {
            Task.Delay(15000).Wait();
            sc.CancellationTokenSource.Cancel(true);
        });

        // Act  
        sc.StartClientNotificationChannel();

        // Assert
        Assert.That(sc.Counter, Is.Not.EqualTo(0));

    }
}