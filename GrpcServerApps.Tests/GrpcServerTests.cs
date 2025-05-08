// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Grpc.Net.Client;
using System.Diagnostics;

namespace GrpcServerApps.Tests
{
    public class GrpcServerTests
    {
        private readonly GrpcChannel _channel;

        public GrpcServerTests()
        {
            // Start the server
            string[] args = [];

            // Run GRPC in a separate thread
            var thread = new Thread(() =>
            {
                try
                {
                    GrpcServerApp.Program.Main(args);
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

            Task.Delay(5000);

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
                GrpcServerApp.Program.Shutdown();
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
        public void StartTransaction_RunTransaction1DoSomething_Sucess()
        {
            // Arrange 
            var client = new BusinessTransactionService.BusinessTransactionServiceClient(_channel);

            var requestData = new EmptyRequest();

            var request = new BusinessTransactionRequest
            {
                TransactionId = 1,
                RequestData = Google.Protobuf.WellKnownTypes.Any.Pack(requestData)
            };

            // Act  
            var reply = client.StartTransaction(request);

            // Assert
            Assert.That(reply.ErrorCode, Is.EqualTo(0));

        }

        [Test]
        public void StartTransaction_RunTransaction2DoSomethingElse_Sucess()
        {
            // Arrange 
            var client = new BusinessTransactionService.BusinessTransactionServiceClient(_channel);
            const int id = 999;

            var requestData = new ObjectIdRequest
            {
                ObjectId = id
            };

            var request = new BusinessTransactionRequest
            {
                TransactionId = 2,
                RequestData = Google.Protobuf.WellKnownTypes.Any.Pack(requestData)
            };

            // Act  
            var reply = client.StartTransaction(request);

            // Assert
            Assert.That(reply.ErrorCode, Is.EqualTo(0));

            var success = reply.ReplyData.TryUnpack<ObjectIdReply>(out var oReply);

            Assert.That(success, Is.EqualTo(true));
            Assert.That(oReply.ObjectId, Is.EqualTo(id));
        }

    }
}